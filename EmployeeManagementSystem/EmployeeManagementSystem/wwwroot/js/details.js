$('#details-search-button').on('click', function () {

    let companyId = $('#details-search-button').val();

    $.ajax({
        url: '/Company/Details?id=' + companyId,
        type: 'GET',
    });

});