//Auto Complete User Name From Database

$(function () {
    $('#txtSearchProduct').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "AutoCompleteProduct.asmx/GetSearchProduct",
                data: "{'productName': '" + request.term + "'}",
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

