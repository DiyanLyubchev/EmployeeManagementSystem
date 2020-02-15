
// Write your JavaScript code.

function populateCities(countryId, targetSelectId) {
    $.getJSON(`/home/getCities?countryId=${countryId}`)
        .then(cities => {
            const select = $(`#${targetSelectId}`);
            let options = '<option>Select City</option>';
            cities.forEach(city => {
                options += `<option value="${city.id}">${city.name}</option>`;
            });
            select.html(options);
        });
};

function populateOffices(OfficeId, targetSelectId) {
    $.getJSON(`/home/getOffices?companyId=${OfficeId}`)
        .then(offices => {
            const select = $(`#${targetSelectId}`);
            let options = '<option>Select Office</option>';
            offices.forEach(office => {
                options += `<option value="${office.id}">${office.street}</option>`;
            });
            select.html(options);
        });
};

function onBack() {
    href = "javascript:history.go(-1)";
};

function AddEmployee() {
    window.location.href = "/Employee/Add";
};

function AddCompany() {
    window.location.href = "/Company/Add";
};

function AddOffice() {
    window.location.href = "/Office/Add";
};

function ExportEmployee() {
    window.location.href = "/Employee/Export";
}

function ExportCompany() {
    window.location.href = "/Company/Export";
}

function ExportOffice() {
    window.location.href = "/Office/Export";
}