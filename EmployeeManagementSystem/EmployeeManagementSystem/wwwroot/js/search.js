//search company

$('#search-company-button').on('click', function () {
    const searchText = $('#search-company-text').val();

    $.ajax({
        url: '/Search/SearchCompany?searchData=' + searchText,
        type: 'GET',
        success: function (serverData) {


            $('#info-table').remove();

            const companyContainer = $('#showitems');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">Name</th><th scope="col">Creation Date</th><th scope="col">Offices</th><th scope="col">Employees</th><th></th></tr>`;
            const tableEnd = `</table>`;

            if (serverData !== null) {
                companyContainer.append(tableStart)
                const companyTable = $('#info-table');
                serverData
                    .map(company => $(`<tr scope="row"><td>${company.name}</td><td>${formatDate(company.creationDate)}</td><td>${company.countOffices}</td><td>${company.countEmployees}</td></tr>`))
                    .forEach(companyElement => {
                        companyTable.append(companyElement);
                    });
                companyContainer.append(tableEnd);
            }
        }
    });
}); 


//search office by city

$('#search-office-button').on('click', function () {
    const searchText = $('#search-office-text').val();

    $.ajax({
        url: '/Search/SearchOffice?searchData=' + searchText,
        type: 'GET',
        success: function (serverData) {

            $('#info-table').remove();

            const officeContainer = $('#showitems');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">Company</th><th scope="col">Country</th><th scope="col">City</th><th scope="col">Street</th><th></th></tr>`;
            const tableEnd = `</table>`;

            if (serverData !== null) {
                officeContainer.append(tableStart)
                const officeTable = $('#info-table');
                serverData
                    .map(office => $(`<tr scope="row"><td>${office.companyName}</td><td>${office.countryName}</td><td>${office.cityName}</td><td>${office.street}, ${office.streetNumber}</td></tr>`))
                    .forEach(officeElement => {
                        officeTable.append(officeElement);
                    });
                officeContainer.append(tableEnd);
            }
        }
    });
});

//search employee

$('#search-employee-button').on('click', function () {
    const searchText = $('#search-employee-text').val();
    $.ajax({
        url: '/Search/SearchEmployee?searchData=' + searchText,
        type: 'GET',
        success: function (serverData) {

            $('#info-table').remove();

            const employeeContainer = $('#showitems');

            const tableStart =
                `<table class="table table-bordered" id="info-table"><tr><th scope="col">First Name</th><th scope="col">Last Name</th><th scope="col">Experience level</th><th scope="col">Starting date</th><th scope="col">Vacation days</th><th scope="col">Salary</th><th scope="col">Company</th><th scope="col">Location</th><th></th></tr>`;
            const tableEnd = `</table>`;

            if (serverData !== null) {
                employeeContainer.append(tableStart)
                const employeeTable = $('#info-table');
                serverData
                    .map(employee => $(`<tr scope="row"><td>${employee.firstName}</td><td>${employee.lastName}</td><td>${checkExperienceId(employee.experienceEmployeeId)}</td><td>${formatDate(employee.startingDate)}</td><td>${employee.vacationDays}</td><td>${employee.salary}</td><td>${employee.companyName}</td><td>${employee.countryName}, ${employee.cityName}</td></tr>`))
                    .forEach(employeeElement => {
                        employeeTable.append(employeeElement);
                    });
                employeeContainer.append(tableEnd);
            }
        }
    });
});

function formatDate(date) {
    let monthArray = ['January', 'February', 'March', 'April', 'May', 'June', 'July', 'August'
        , 'September', 'October', 'November', 'December'];

    let formatDate = new Date(date);
    let month = formatDate.getMonth();
    let newDateFormat = monthArray[month] + '/' + formatDate.getDate() + '/' + formatDate.getFullYear()

    return newDateFormat;
}


function checkExperienceId(id) {
    if (id === 1) {
        return "Junior";
    }
    else if (id === 2) {
        return "Middle";
    }
    else if (id === 3) {
        return "Senior";
    }
}


