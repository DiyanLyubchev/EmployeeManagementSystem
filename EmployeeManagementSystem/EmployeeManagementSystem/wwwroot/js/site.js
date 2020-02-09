// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

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
}

function populateOffices(officeId, targetSelectId) {
    $.getJSON(`/home/getCities?officeId=${officeId}`)
        .then(offices => {
            const select = $(`#${targetSelectId}`);
            let options = '<option>Select Office</option>';
            offices.forEach(office => {
                options += `<option value="${office.id}">${office.street}</option>`;
            });
            select.html(options);
        });
}