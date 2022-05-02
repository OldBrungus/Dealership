﻿/* global variables */
var formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD'
});

$(document).ready(function () {
    $('#new-search-btn').click(function () {
        search(true);
    });
    $('#used-search-btn').click(function () {
        search(true);
    });
});

function search(isNew) {
    var url = 'http://localhost:55282/Inventory/NewSearch';

    if (!isNew) {
        url = 'http://localhost:55282/Inventory/UsedSearch'
    }

    var minPrice = $('#minPrice').val();
    var maxPrice = $('#maxPrice').val();
    var minYear = $('#minYear').val();
    var maxYear = $('#maxYear').val();
    var searchTerm = ''; //todo

    $.ajax({
        url: url,
        type: 'GET',
        data: {
            minPrice: minPrice,
            maxPrice: maxPrice,
            minYear: minYear,
            maxYear: maxYear,
            searchTerm: searchTerm
        },
        success: function (vehicles) {
            createRow(vehicles);
        }
    })
}

function createRow(vehicles) {
    vehicles.forEach(function (vehicle) {
        $('.inventory-list').append(`
    <div class="row inventory-item">
        <div class="col-sm-3">
            <img />
        </div>
        <div class="col-sm-8 col-sm-offset-1">
            <div class="row">
                <div class="col-sm-4">
                    Body Style: ${vehicle.BodyStyle.DisplayName}
                </div>
                <div class="col-sm-4">
                    Interior: ${vehicle.Interior.DisplayName}
                </div>
                <div class="col-sm-4">
                    Sale Price: ${formatter.format(vehicle.SalePrice)}
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    Trans: ${vehicle.TransmissionType.DisplayName}
                </div>
                <div class="col-sm-4">
                    Mileage: ${vehicle.Mileage}
                </div>
                <div class="col-sm-4">
                    MSRP: ${formatter.format(vehicle.MSRP)}
                </div>
            </div>
            <div class="row">
                <div class="col-sm-4">
                    Color: ${vehicle.Color.DisplayName}
                </div>
                <div class="col-sm-4">
                    VIN #: ${vehicle.VIN}
                </div>
                <div class="col-sm-4">
                    <a href="/Inventory/Details?vehicleID=${vehicle.ID}">Details</a>
                </div>
            </div>
        </div>
    </div>
`)
    });
}