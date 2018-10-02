$(document).ready(function () {
    var table = $('#policyAssignmentsTable').DataTable({
        dom: '<<"dataTables_customToolbar">lf<rt>ip>',
        responsive: true,
        ajax: {
            url: '/api/policyassignments',
            dataSrc: ''
        },
        columns: [
            {
                data: 'policy',
                render: function (data, type, policyAssignment) {
                    return '<a href="/policies/edit/' + policyAssignment.policy.id + '">' + policyAssignment.policy.number + '</a>';
                }
            },
            { data: 'carrier.name' },
            {
                data: 'isActive',
                render: function (data, type, policy) {
                    return policy.isActive ? '<i class="fas fa-check active-policy"></i>' : '--';
                }
            }
        ],
        pageLength: 25
    });

    $('div.dataTables_customToolbar')
        .html('<a href="/policies/new" class="btn btn-sm btn-info text-capitalize font-weight-bold"><i class="fas fa-plus pr-1" />New Policy</a>');
    $('.dataTables_customToolbar').addClass('col-sm-auto text-center mb-2 p-0 dt_topbar_element');
    $('.dataTables_length').addClass('col-sm-auto dt_topbar_element ml-2');
    $('.dataTables_filter').addClass('col-sm-auto ml-md-auto dt_topbar_element');
    $('.dt_topbar_element')
        .wrapAll('<div class="dt_topbar container"><div class="row"></div></div>');
});