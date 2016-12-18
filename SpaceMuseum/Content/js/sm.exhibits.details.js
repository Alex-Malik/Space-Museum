$(function () {
    // subscribe to UI events
    $('.card[id^="exhibit-"]').bind('click', openDetails);
    $(window).bind('resize', updateCardImgHeight);

    // update card images height to be equal to width
    updateCardImgHeight();

    function updateCardImgHeight() {
        $('.card-img').each(function () {
            let $img = $(this);
            $img.css({ 'height': $img.width() + 'px' });
        });
    }

    function openDetails() {
        window.location.href = window.location.href + '/details/' + $(this).attr('id').substring(8);
    }
});