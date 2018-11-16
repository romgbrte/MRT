$(document).ready(function () {

    // Controls the speed of select input menu expansion/collapse
    $('.dropdown').on('show.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).slideDown('fast');
    });
    $('.dropdown').on('hide.bs.dropdown', function () {
        $(this).find('.dropdown-menu').first().stop(true, true).slideUp('fast');
    });

    /* When a user brings focus to an input by clicking 
     * on it, this selects whatever populates that input */
    $('input.form-control').focusin(function () {
        this.select();
    });
});