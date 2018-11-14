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
        pageLength: 25,
        initComplete: function () {
            this.api().columns().every(function () {
                var col = this;
                var select = $('<select class="form-control form-control-sm"><option value="">[Filter]</option></select>')
                    .appendTo($(col.footer()).empty())
                    .on('change', function () {
                        var value = $.fn.dataTable.util.escapeRegex($(this).val());
                        col.search(value ? '^' + value + '$' : '', true, false).draw();
                    });
                col.data().unique().sort().each(function (d, j) {
                    select.append('<option value="'+d+'">'+d+'</option>')
                });
            });
        }
    });

    $('.dataTables_length').addClass('col-sm-auto dt_topbar_element');
    $('.dataTables_filter').addClass('col-sm-auto ml-md-auto dt_topbar_element');
    $('.dt_topbar_element')
        .wrapAll('<div class="dt_topbar container"><div class="row"></div></div>');
});