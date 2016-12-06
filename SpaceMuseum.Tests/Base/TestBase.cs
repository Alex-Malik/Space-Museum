using System;
using System.Data.Entity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Autofac;

namespace SpaceMuseum.Tests.Base
{
    using Data;
    using Factories;
    using SpaceMuseum.Services;

    [TestClass]
    public abstract class TestBase
    {
        private readonly IContainer Container;

        public TestBase()
        {
            Container = BuildContainer();
        }

        protected ILifetimeScope Scope { get; private set; }
        
        protected DbEntityFactory DbFactory { get; private set; }

        [TestInitialize]
        public virtual void Initialize()
        {
            // Transaction will be used to rollback changes in db
            DbContextTransaction transaction = null;

            Scope = Container.BeginLifetimeScope(builder =>
            {
                builder.Register(ctx => { 
                        DatabaseContext d = new DatabaseContext();
                        if (transaction == null)
                            transaction = d.Database.BeginTransaction();
                        else
                            d.Database.UseTransaction(transaction.UnderlyingTransaction);
                        return d;
                    })
                    .AsSelf().InstancePerLifetimeScope();
            });
            
            // Resoleve database factory
            DbFactory = Scope.Resolve<DbEntityFactory>();

            // Register default definitions 
            DbEntityDefinitions.Define();

            // Rollback transaction when on test cleanup
            Scope.CurrentScopeEnding += (s, e) =>
            {
                if (transaction != null)
                    transaction.Rollback();
            };
        }

        [TestCleanup]
        public virtual void Cleanup()
        {
            Scope.Dispose();
        }

        private IContainer BuildContainer()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterType<EventsService>().AsSelf().InstancePerDependency();
            builder.RegisterType<ExhibitsService>().AsSelf().InstancePerDependency();
            builder.RegisterType<DbEntityFactory>().AsSelf().InstancePerLifetimeScope();

            return builder.Build();
        }
    }
}
