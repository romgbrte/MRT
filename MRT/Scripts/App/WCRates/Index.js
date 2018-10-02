$(document).ready(function () {
    var table = $('#wcratesTable').DataTable({
        dom: '<lf<rt>ip>',
        ajax: {
            url: '/api/wcrates',
            dataSrc: ''
        },
        columns: [
            { data: 'carrierName' },
            { data: 'stateName' },
            { data: 'codeNumber' },
            { data: 'rate' }
        ],
        pageLength: 50
    });

    $('.dataTables_length').addClass('col-sm-auto dt_topbar_element');
    $('.dataTables_filter').addClass('col-sm-auto ml-md-auto dt_topbar_element');
    $('.dt_topbar_element')
        .wrapAll('<div class="dt_topbar container"><div class="row"></div></div>');
});