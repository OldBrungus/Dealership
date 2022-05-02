$(document).ready(function () {
    getMakes()
})

function getMakes() {
    $.ajax({
        url: 'http://localhost:55282/Admin/GetMakes',
        type: 'GET',
        success: function (makes) {
            fillTable(makes)
        }
    })
}

function fillTable(makes) {
    makes.forEach(function (make) {
        $('#make-table').append(`
            <tr>
                <td>
                    ${make.DisplayName}
                </td>
            </tr>`)
    })
}