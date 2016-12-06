using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpaceMuseum.Tests.Base.Factories
{
    using SpaceMuseum.Data;

    public class DbEntityFactory
    {
        private static readonly Dictionary<Type, Action<object>> _defaults = new Dictionary<Type, Action<object>>();

        public static void Define<T>(Action<T> setters)
        {
            _defaults[typeof(T)] = (obj) => setters((T)obj);
        }

        private readonly DatabaseContext _db;
        
        public DbEntityFactory(DatabaseContext db)
        {
            _db = db;
        }

        public T Create<T>(Action<T> overrides = null) where T : class, new()
        {
            var r = new T();
            try
            {
                Action<object> defaultSetter;
                if (_defaults.TryGetValue(typeof(T), out defaultSetter))
                    defaultSetter.Invoke(r);

                overrides?.Invoke(r);
                
                _db.Entry(r).State = System.Data.Entity.EntityState.Added;
                _db.SaveChanges();
            }
            catch (Exception ex)
            {
                throw;
            }
            return r;
        }
    }
}
