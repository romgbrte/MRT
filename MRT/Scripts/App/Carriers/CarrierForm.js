$(document).ready(function () {
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

    $('.covered, .not-covered').click(function (e) {
        e.preventDefault();
        var stateListItemLink = $(this);
        var modelCarrierId = $('#carrier-form').data('carrier-id');
        stateListItemLink.toggleClass('covered not-covered').children().toggleClass('fa-plus fa-minus');
        var destinationList = '', sourceList = '', ajaxMethod = '', urlOptArg = '';
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
                if ($(destinationList + ' li').length == 0) { }

                stateListItemLink.parent().appendTo(destinationList);

                $(destinationList + ' > li').sort(function (a, b) {
                    var aStr = $(a).data('state-id'), bStr = $(b).data('state-id');
                    return aStr > bStr ? 1 : aStr < bStr ? -1 : 0;
                }).appendTo(destinationList);

                if ($(sourceList + ' li').length == 0) { }
            })
            .fail(function (e) {
                alert('State coverage could not be altered, please contact the administrator');
            });
    });

    $('#states-covered-collapse').on('hidden.bs.collapse shown.bs.collapse', function () {
        $('#states-covered-collapse-icon').toggleClass('fa-arrow-circle-down fa-arrow-circle-up');
    });
    $('#new-state-collapse').on('hidden.bs.collapse shown.bs.collapse', function () {
        $('#new-state-collapse-icon').toggleClass('fa-arrow-circle-down fa-arrow-circle-up');
    });
});