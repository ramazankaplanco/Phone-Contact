function baseRequest(url, data, type, dataType, callback) {
    $.ajax({
        headers: {
            'anti-forgery-token': $('input[name="__RequestVerificationToken"]').val()
        },
        url: url,
        type: type,
        data: data,
        dataType: dataType,
        success: function (data) {
            callback(true, data);
        },
        error: function (error) {
            callback(false, error);
        },
        beforeSend: function () {
        },
        complete: function () {
        }
    });
}

function request(url, data = null, type = "GET", dataType = "JSON") {

    let deferred = $.Deferred();

    baseRequest(url,
        data,
        type,
        dataType,
        function (result, data) {
            deferred.resolve(result, data);
        });

    return deferred.promise();
}