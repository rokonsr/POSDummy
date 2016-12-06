//Auto Complete User Name From Database

$(function () {
    $('#txtMeasurementName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "CheckExistingMeasurement.asmx/CheckMeasurement",
                data: "{'measurementName': '" + request.term + "'}",
                type: "POST",
                dataType: "Json",
                contentType: "application/json;charset=utf-8",
                success: function (data) {
                    response(data.d);
                },
                error: function (result) {
                    alert('Not Match');
                }
            });
        }
    });
});
