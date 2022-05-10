$(document).ready(function () {
    GetSpecials();
});

function GetSpecials() {
    $.ajax({
        url: 'http://localhost:55282/Admin/GetSpecialsList',
        type: 'GET',
        success: function (results) {
            CreateSpecialsRows(results);
        }
    });
}

function CreateSpecialsRows(specials) {

    specials.forEach(function (special) {
        $('.specials-list').append(`
        <div class="row border-box">
            <div class="col-lg-12">
                <div class="row">
                    <div class="col-lg-3">
                        <h1>$</h1>
                    </div>
                    <div class="col-lg-6">
                        <h3>${special.SpecialTitle}</h3>
                    </div>
                    <div class="col-lg-1 col-lg-offset-2 specials-button">
                        <a class="btn btn-danger" href="/Admin/DeleteSpecial?specialID=${special.SpecialID}">Delete</a>
                    </div>
                </div>
                <div class="row">
                    <div class="col-lg-9 col-lg-offset-3">
                        ${special.Description}
                    </div>
                </div>
            </div>
        </div>
        `);
    });
}