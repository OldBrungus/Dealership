$(document).ready(function () {
    getPurchaseResources();
});

function getPurchaseResources() {
    var VehicleID = $('#vehicleID').val();

    $.ajax({
        url: 'http://localhost:55282/Sales/GetPurchaseInfoResources',
        type: 'GET',
        data: {
            vehicleID: VehicleID
        },
        success: function (result) {
            displayVehicle(result.Vehicle);
            listStates(result.States);
            listPurchaseTypes(result.PurchaseTypes);
        }
    })
}

function displayVehicle(vehicle) {
    $('#vehicleTitle')[0].innerText = `${vehicle.Year} ${vehicle.Make.DisplayName} ${vehicle.Model.DisplayName}`;
    $('#bodyStyle')[0].innerText = `Body Style: ${vehicle.BodyStyle.DisplayName}`;
    $('#interior')[0].innerText = `Interior: ${vehicle.Interior.DisplayName}`;
    $('#salePrice')[0].innerText = `Sale Price: $ ${vehicle.SalePrice}`;
    $('#transmissionType')[0].innerText = `Transmission: ${vehicle.TransmissionType.DisplayName}`;
    $('#mileage')[0].innerText = `Mileage: ${vehicle.Mileage}`;
    $('#msrp')[0].innerText = `MSRP: $ ${vehicle.MSRP}`;
    $('#color')[0].innerText = `Color: ${vehicle.Color.DisplayName}`;
    $('#vin')[0].innerText = `VIN: ${vehicle.VIN}`;
    $('#description')[0].innerText = `Description: ${vehicle.Description}`;
    $('#vehiclePicture').attr('src', `data:image/*;base64,${vehicle.PictureBase64String}`);
    $('#sale-price').val(vehicle.SalePrice);
}

function listStates(states) {
    states.forEach(function (state) {
        $('#states').append(`
        <option value = "${state.ID}">${state.StateAbbreviation}</option>`)
    });
}

function listPurchaseTypes(purchaseTypes) {
    purchaseTypes.forEach(function (purchaseType) {
        $('#purchaseTypes').append(`
        <option value = "${purchaseType.ID}">${purchaseType.PurchaseTypeName}</option>`)
    });
}
