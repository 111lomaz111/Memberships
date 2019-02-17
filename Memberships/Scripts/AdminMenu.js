$(function () {
    $('[data-admin-menu]').hover(function () {
        //adding/removing class to/from element with attribut 'data-admin-menu'
        $('[data-admin-menu]').toggleClass('open');
    });
}); 