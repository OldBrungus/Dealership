/* global variables */
var formatter = new Intl.NumberFormat('en-US', {
    style: 'currency',
    currency: 'USD'
});

$(document).ready(function () {
    $('#sales-search-btn').click(function () {
        search();
    });
});

function search() {
    var url = 'http://localhost:55282/Sales/SalesSearch';


    var minPrice = $('#minPrice').val();
    var maxPrice = $('#maxPrice').val();
    var minYear = $('#minYear').val();
    var maxYear = $('#maxYear').val();
    var searchTerm = $('#searchBox').val();

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
    $('.inventory-list').empty();

    vehicles.forEach(function (vehicle) {
        $('.inventory-list').append(`
    <div class="row inventory-item">
        <div class="col-md">
            <div class="row">
                ${vehicle.Year} ${vehicle.Make.DisplayName} ${vehicle.Model.DisplayName}
            </div>
        </div>
        <div class="col-sm-3">
            <img style="max-width: 100%" src="data:image/*;base64,${vehicle.PictureBase64String}" />
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
                    <a class="a-button" href="/Sales/Purchase?vehicleID=${vehicle.ID}">Purchase</a>
                </div>
            </div>
        </div>
    </div>
`)
    });
}