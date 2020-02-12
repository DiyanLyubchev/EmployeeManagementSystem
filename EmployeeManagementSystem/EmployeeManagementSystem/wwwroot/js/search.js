//1.

//$('#load-button').on('click', function () {
//    const search = $('#search-text').val();

//    $.ajax({
//        url: '/Company/Search',
//        data: { searchData: search },
//        type: 'Post',
//        dataType: 'json',
//    });

//    window.location.reload(true);
//});

//2.

//$('#search-button').on('click', function () {
//    const searchText = $('#search-text').val();

//    $.ajax({
//        url: '/Company/Search?searchData=' + searchText,
//        type: 'GET',
//        success: function (serverData) {
//            console.log(serverData);

//        }

//    });
//});

//3.


$('#search-button').on('click', function () {
    const searchText = $('#search-text').val();

    $.ajax({
        url: '/Company/Search?searchData=' + searchText,
        type: 'GET',
        success: function (serverData) {
            console.log(serverData);

            $('#info-table').remove();
            $('.info-massege').remove();

            const companyContainer = $('#showcompany');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">Name</th><th scope="col">Creation Date</th></tr>`;
            const tableEnd = `</table>`;
            const massege = `<div  style="color:#ff6a00" class="info-massege"> We don't have company with this name!</div>`

            if (serverData === null) {
                companyContainer.append(massege);
            }
            else {
                companyContainer.append(tableStart)
                const emailTable = $('#info-table');
                serverData
                    .map(company => $(`<tr scope="row"><td>${company.name}</td><td>${company.creationDate}</td></tr>`))
                    .forEach(companyElement => {
                        emailTable.append(companyElement);
                    });
                companyContainer.append(tableEnd);
            }
        }
    });
});
