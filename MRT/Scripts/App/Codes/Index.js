$(document).ready(function () {
    $('#codesTable').DataTable({
        dom: '<lf<rt>ip>',
        ajax: {
            url: '/api/codes',
            dataSrc: ''
        },
        columns: [
            { data: 'number' },
            { data: 'jobDescription' }
        ],
        pageLength: 50
    });

    $('.dataTables_length').addClass('col-sm-auto dt_topbar_element');
    $('.dataTables_filter').addClass('col-sm-auto ml-md-auto dt_topbar_element');
    $('.dt_topbar_element')
        .wrapAll('<div class="dt_topbar container"><div class="row"></div></div>');
});