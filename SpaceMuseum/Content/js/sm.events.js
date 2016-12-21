$(function () {
    // subscribe to UI events
    $(window).on('resize', updateCardImgHeight);
    $('#search').on('change paste keyup', search);

    // update card images height to be equal to width
    updateCardLinks();
    updateCardImgHeight();

    function updateCardImgHeight() {
        $('.card-img').each(function () {
            let $img = $(this);
            $img.css({ 'height': $img.width() + 'px' });
        });
    }
    function updateCardLinks() {
        $('.card[id^="event-"]').on('click', openDetails);
    }

    function openDetails() {
        window.location.href = window.location.href + '/details/' + $(this).attr('id').substring(6);
    }

    function search() {
        $.get(window.location.href + '/search/?value=' + encodeURI($(this).val()),
            function (response) {
                if (!response) return;
                var items = JSON.parse(response);
                var $items = $('#items');

                // remove old items
                $items.empty();

                // insert new items
                for(item of items) {
                    var box = $(
                    '<div class="col-lg-3 col-md-4 col-sm-6 col-xs-12">' +
                     '<div id="event- ' + item.EventID + '" class="card">' +
                      '<div class="card-img clickable" style="background-image:url('+ item.Images[0] + ');">' +
                        '<div class="card-desc">' + item.Name + '</div>' +
                      '</div>' +
                     '</div>' +
                    '</div>');
                    $items.append(box);
                }

                // update height for new exhibits
                updateCardLinks();
                updateCardImgHeight();
            });
    }
});