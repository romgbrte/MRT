$(document).ready(function () {
    $('.dropdown').on('show.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown('fast');
    });

    $('.dropdown').on('hide.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).slideUp('fast');
    });

    $('input.form-control').focusin(function () {
        this.select();
    });
});