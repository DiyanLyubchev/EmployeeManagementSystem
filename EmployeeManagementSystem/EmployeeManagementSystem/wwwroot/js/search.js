//search company

$('#search-company-button').on('click', function () {
    const searchText = $('#search-company-text').val();

    $.ajax({
        url: '/Search/SearchCompany?searchData=' + searchText,
        type: 'GET',
        success: function (serverData) {
            console.log( )
            $('#info-table').remove();
            console.log(serverData);

            const companyContainer = $('#showitems');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">Name</th><th scope="col">Creation Date</th><th></th></tr>`;
            const tableEnd = `</table>`;

            if (serverData !== null) {
                companyContainer.append(tableStart)
                const emailTable = $('#info-table');
                serverData
                    .map(company => $(`<tr scope="row"><td>${company.name}</td><td>${company.creationDate}</td><td>
                       <button id="details-search-button" value="${company.id}" type="submit" class="btn alert-success">Details</button></td></tr>`))
                    .forEach(companyElement => {
                        emailTable.append(companyElement);
                    });
                companyContainer.append(tableEnd);
            }
        }
    });
});

//search office by city

$('#search-office-button').on('click', function () {
    const searchText = $('#search-office-text').val();
    console.log(searchText);
    $.ajax({
        url: '/Search/SearchOffice?searchData=' + searchText,
        type: 'GET',
        success: function (serverData) {
            console.log(serverData);
            $('#info-table').remove();

            const officeContainer = $('#showitems');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">Company</th><th scope="col">Country</th><th scope="col">City</th><th scope="col">Street</th><th></th></tr>`;
            const tableEnd = `</table>`;

            if (serverData !== null) {
                officeContainer.append(tableStart)
                const emailTable = $('#info-table');
                serverData
                    .map(office => $(`<tr scope="row"><td>${office.companyName}</td><td>${office.countryName}</td><td>${office.cityName}</td><td>${office.street}</td><td>
                       <button id="details-search-button" value="${office.id}" type="submit" class="btn alert-success">Details</button></td></tr>`))
                    .forEach(officeElement => {
                        emailTable.append(officeElement);
                    });
                officeContainer.append(tableEnd);
            }
        }
    });
});