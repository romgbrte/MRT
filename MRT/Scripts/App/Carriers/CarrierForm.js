$(document).ready(function () {

    // Help icon content
    $('#carrier-popover-name').popover({
        title: 'Name of the Carrier',
        content: 'The full name of the carrier -- no abbreviations.',
        placement: 'right',
        trigger: 'hover click'
    });
    $('#carrier-popover-baserate').popover({
        title: 'Rate percentage value',
        content: 'Decimal value of the rate percentage (ex. 5.75); maximum three decimal places.',
        placement: 'right',
        trigger: 'hover click'
    });

    // This handles switching States between the covered/not covered lists
    $('.covered, .not-covered').click(function (e) {
        e.preventDefault();
        var stateListItemLink = $(this);
        var modelCarrierId = $('#carrier-form').data('carrier-id');

        // Whichever list the clicked State is in - based on its class - toggle to the other
        stateListItemLink.toggleClass('covered not-covered').children().toggleClass('fa-plus fa-minus');
        var destinationList = '', sourceList = '', ajaxMethod = '', urlOptArg = '';

        // Depending on which class was toggled *to*, set up the corresponding api call arguments
        stateListItemLink.hasClass('covered')
            ? (destinationList = '#covered-list', sourceList = '#not-covered-list', ajaxMethod = 'post')
            : (destinationList = '#not-covered-list', sourceList = '#covered-list', ajaxMethod = 'delete', urlOptArg = '/' + modelCarrierId);

        var stateCoverageDto = {
            carrierId: modelCarrierId,
            stateId: stateListItemLink.parent().data('state-id')
        };

        $.ajax({
            url: '/api/statescovered' + urlOptArg,
            method: ajaxMethod,
            data: stateCoverageDto
        })
            .done(function (result) {
                // Attempt to remove the empty list message
                if ($(destinationList + ' li').length == 1) {
                    $(destinationList).children('.empty-list-notification').remove();
                }

                stateListItemLink.parent().appendTo(destinationList);

                // Sort the State into its new list
                $(destinationList + ' > li').sort(function (a, b) {
                    var aStr = $(a).data('state-id'), bStr = $(b).data('state-id');
                    return aStr > bStr ? 1 : (aStr < bStr ? -1 : 0);
                }).appendTo(destinationList);

                // If the source list is empty, append the empty list message
                if ($(sourceList + ' li').length == 0) {
                    $('<li class="empty-list-notification list-group-item">No state coverages</li>')
                        .appendTo(sourceList);
                }

                // success message
                var actionTaken = (ajaxMethod == 'post') ? 'added' : 'removed';
                toastr.success('State coverage successfully ' + actionTaken);
            })
            .fail(function (e) {
                // failure message
                toastr.error('State coverage could not be altered, please contact an administrator');
            });
    });

    // Toggle the up/down arrows on the State Coverage lists when they're expanded/collapsed
    $('#states-covered-collapse').on('hidden.bs.collapse shown.bs.collapse', function () {
        $('#states-covered-collapse-icon').toggleClass('fa-arrow-circle-down fa-arrow-circle-up');
    });
    $('#new-state-collapse').on('hidden.bs.collapse shown.bs.collapse', function () {
        $('#new-state-collapse-icon').toggleClass('fa-arrow-circle-down fa-arrow-circle-up');
    });
});