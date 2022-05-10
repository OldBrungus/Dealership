$(document).ready(function () {
    $('#search-btn').click(function () {
        search();
    });
});

function search() {
    var startDate = $('#startDate').val();
    var endDate = $('#endDate').val();

    $.ajax({
        url: `http://localhost:55282/Reports/SalesReportSearch?startDate=${startDate}&endDate=${endDate}`,
        type: 'GET',
        success: function (data) {
            updateSales(data);
        }
    });
}

function updateSales(data) {
    $('#totalSalesAmount')[0].innerText = data.TotalSalesAmount;
    $('#totalSalesCount')[0].innerText = data.TotalSalesCount;
}