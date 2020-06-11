$(document).ready(function () {

    getUser();
});

$(document).on("click", "#userTable button.editUser", function () {

    let tr = $(this).closest('tr');

    let id = tr.find('.userId').text();
    let name = tr.find('.userName').text();
    let lastName = tr.find('.userLastName').text();
    let nickName = tr.find('.userNickName').text();
    let password = tr.find('.userPassword').text();
    let note = tr.find('.userNote').text();


    $("#Id").val(id);
    $("#UserName").val(name);
    $("#UserLastName").val(lastName);
    $("#UserNickName").val(nickName);
    $("#UserPassword").val(password);
    $("#UserNote").val(note);
});

$("#saveChanges").click(function () {

    if (isValidForm($("#userForm"))) {

        let user = $("#userForm").serializeObject();

        parseInt(user.Id) > 0 ? postUser(user) : putUser(user);
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
                    '<td class="userId">' + user.Id + '</td>' +
                    '<td class="userName">' + user.UserName + '</td>' +
                    '<td class="userLastName">' + user.UserLastName + '</td>' +
                    '<td class="userNickName">' + user.UserNickName + '</td>' +
                    '<td class="userPassword" hidden>' + user.UserPassword + '</td>' +
                    '<td class="userNote">' + user.UserNote + '</td>' +
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