$(document).ready(function () {

    getUser();
});

$(document).on("click", "#userTable button.editUser", function () {

    let tr = $(this).closest('tr');

    let id = tr.find('.userId').text();
    let userName = tr.find('.userName').text();
    let firstName = tr.find('.userFirstName').text();
    let lastName = tr.find('.userLastName').text();
    let phoneNumber = tr.find('.userPhoneNumber').text();
    let note = tr.find('.userNote').text();


    $("#Id").val(id);
    $("#UserName").val(userName);
    $("#UserFirstName").val(firstName);
    $("#UserLastName").val(lastName);
    $("#UserPhoneNumber").val(phoneNumber);
    $("#UserNote").val(note);
});

$("#newUser").click(function () {

    $("#userEditModal").modal("show");

    setTimeout(function () {
        $("#Id").val('');

        clearForm($("#userForm"));
    }, 500);
});

$("#saveChanges").click(function () {

    if (isValidForm($("#userForm"))) {

        let user = $("#userForm").serializeObject();

        user.UserEmail = user.UserName;

        parseInt(user.Id) > 0 ? putUser(user) : postUser(user);
    }
});

function postUser(user) {
    request("/User/Post", user, "POST").done(function (result, data) {
        if (result && data.Success) {

            $("#userEditModal").modal("hide");

            clearForm($("#userForm"));

            getUser();

        } else alert(data.Message);
    });
}

function putUser(user) {
    request("/User/Put", { id: user.Id, user: user }, "PUT").done(function (result, data) {
        if (result && data.Success) {

            $("#userEditModal").modal("hide");

            clearForm($("#userForm"));

            getUser();

        } else alert(data.Message);
    });
}

function getUser() {
    request("/User/Get").done(function (result, data) {
        if (result && data.Success) {

            let body = "";

            data.Data.forEach(function (user) {
                body +=
                    '<tr>' +
                    '<td class="userId">' +
                    user.Id +
                    '</td>' +
                    '<td class="userName">' +
                    user.UserName +
                    '</td>' +
                    '<td class="userFirstName">' +
                    user.UserFirstName +
                    '</td>' +
                    '<td class="userLastName">' +
                    user.UserLastName +
                    '</td>' +
                    '<td class="userPhoneNumber">' +
                    user.UserPhoneNumber +
                    '</td>' +
                    '<td class="userNote">' +
                    user.UserNote +
                    '</td>' +
                    '<td>' +
                    '<button type="button" class="editUser btn btn-primary" data-toggle="modal" data-target="#userEditModal">' +
                    '<i class="fa fa-edit"></i>' +
                    '</button>' +
                    '</td>' +
                    '</tr>';
            });

            $("#userTable tbody").html(body);

        } else alert(data.Message);
    });
}