$(document).ready(function () {
    var table = $('#carriersTable').DataTable({
        dom: '<<"dataTables_customToolbar">lf<rt>ip>',
        ajax: {
            url: '/api/carriers',
            dataSrc: ''
        },
        columns: [
            {
                data: 'id',
                render: function (data, type, carrier) {
                    return '<a href="/carriers/edit/' + carrier.id + '">' + carrier.name + '</a>';
                }
            },
            { data: 'baseRate' },
            { data: 'statesCoveredString' }
        ],
        pageLength: 25
    });

    $('div.dataTables_customToolbar')
        .html('<a href="/carriers/new" class="btn btn-sm btn-info text-capitalize font-weight-bold"><i class="fas fa-plus pr-1" />New Carrier</a>');
    $('.dataTables_customToolbar').addClass('col-sm-auto text-center mb-2 p-0 dt_topbar_element');
    $('.dataTables_length').addClass('col-sm-auto dt_topbar_element ml-2');
    $('.dataTables_filter').addClass('col-sm-auto ml-md-auto dt_topbar_element');
    $('.dt_topbar_element')
        .wrapAll('<div class="dt_topbar container"><div class="row"></div></div>');
});