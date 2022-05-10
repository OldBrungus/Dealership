var models = [];

$(document).ready(function () {
    getModels();

    $('#MakeID').change(function () {
        updateModels();
    });
});

function getModels() {
    $.ajax({
        url: 'http://localhost:55282/Admin/GetModels',
        type: 'GET',
        success: function (data) {
            models = data;
            updateModels();
        }
    });
}

function updateModels() {
    $('#ModelID').empty();

    var selected = $('#MakeID').val();

    models.forEach(function (model) {

        if (model.Make.MakeID.toString() === selected) {
            $('#ModelID').append(`
                <option value="${model.ModelID}">${model.DisplayName}</option>
            `);
        }
    });
}