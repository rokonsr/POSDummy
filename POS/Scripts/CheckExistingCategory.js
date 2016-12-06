﻿//Auto Complete User Name From Database

$(function () {
    $('#txtCategoryName').autocomplete({
        source: function (request, response) {
            $.ajax({
                url: "CheckExistingCategory.asmx/CheckCategory",
                data: "{'categoryName': '" + request.term + "'}",
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
