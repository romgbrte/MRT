$(document).ready(function () {
    $('#policy-popover-carrier').popover({
        title: 'Carrier this Policy is assigned to',
        content: 'The assigned Carrier cannot be changed.',
        placement: 'right',
        trigger: 'hover click'
    });
    $('#policy-popover-number').popover({
        title: 'Policy Number in the format XX-##-###',
        content: '<div class="row">'
            + '<div class="col-12"><strong>XX</strong> -- the Carrier\'s initials (ex. GBW for Great Big West).</div>'
            + '<div class="col-12"><strong>##</strong> -- the last two digits of the Start Date year (ex. 18 for 2018).</div>'
            + '<div class="col-12"><strong>###</strong> -- the number policy for the assigned Carrier (ex. 003 if it is the carrier\'s third policy this calendar year).</div>'
            + '</div>',
        placement: 'right',
        trigger: 'hover click',
        html: true
    });
    $('#policy-popover-startdate').popover({
        title: 'Initial date of Policy coverage',
        content: 'Start Date cannot be prior to today, and cannot be further than one year into the future.',
        placement: 'right',
        trigger: 'hover click'
    });
    $('#policy-popover-enddate').popover({
        title: 'Final date of Policy coverage',
        content: 'End Date cannot be prior to the Start Date, and cannot be further than two years into the future.',
        placement: 'right',
        trigger: 'hover click'
    });
    $('[id^=policy-popover-rate]').popover({
        title: 'Rate percentage value',
        content: 'Decimal value of the rate percentage (ex. 5.75); maximum three decimal places.',
        placement: 'right',
        trigger: 'hover click'
    });

    var modelPolicyId = $('#policy-form').data('policy-id');
    if (modelPolicyId != 0) {
        $.ajax({
            url: '/api/policyassignments/' + modelPolicyId,
            method: 'get'
        })
            .done(function (policyAssignmentDto) {
                $('#assigned-carrier-text').html(policyAssignmentDto != null ? policyAssignmentDto.carrier.name : '');
            })
            .fail(function (e) {
                console.log('Policy assignment could not be retrieved, please contact the administrator');
            });
    }
});