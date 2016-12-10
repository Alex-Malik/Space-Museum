$(function () {
    $('.card[id^="event-"]').bind('click', function () {
        window.location.href = window.location.href + 'events/details/' + $(this).attr('id').substring(6);
    });

    $('.card-img').each(function () {
        let $img = $(this);
        $img.css({ 'height': $img.width() + 'px' });
    });
});