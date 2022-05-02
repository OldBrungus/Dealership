$(document).ready(function () {
    getModels();
})

function getModels() {
    $.ajax({
        url: 'http://localhost:55282/Admin/GetModels',
        type: 'GET',
        success: function (models) {
            buildTable(models);
        }
    })
}

function buildTable(models) {
    models.forEach(function (model) {
        $('#model-table').append(`
<tr>
    <td>
        ${model.Make.DisplayName}
    </td>

    <td>
        ${model.DisplayName}
    </td>
</tr>`)
    })
}