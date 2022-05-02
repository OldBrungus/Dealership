$(document).ready(function () {
    $('#submit-button').click(function () {
        submit();
    })
})

function submit() {
    var VehicleID = $('#vehicleID').val();
    var Name = $('#name').val();
    var Phone = $('#phone').val();
    var Email = $('#email').val();
    var Street1 = $('#street1').val();
    var Street2 = $('#street2').val();
    var City = $('#city').val();
    var State = $('#state').val();
    var Zip = $('#zip').val();
    var PurchasePrice = $('#purchase-price').val();
    var PurchaseType = $('#purchaseType').val();

    $.ajax({
        url: 'http://localhost:55282/Sales/Purchase',
        type: 'POST',
        data: {
            purchase: {
                VehicleID: VehicleID,
                Name: Name,
                Phone: Phone,
                Email: Email,
                Street1: Street1,
                Street2: Street2,
                City: City,
                State: State,
                Zip: Zip,
                PurchasePrice: PurchasePrice,
                PurchaseType: PurchaseType
            }
        },
        success: function () {
            //todo
        }
    })
}