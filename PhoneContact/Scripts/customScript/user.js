$(document).ready(function () {
});

$(document).on("click", "#userTable button.editUser", function () {

    let tr = $(this).closest('tr');

    let id = tr.find('.userId').text();
    let name = tr.find('.userName').text();
    let lastName = tr.find('.userLastName').text();
    let nickName = tr.find('.userNickName').text();
    let password = tr.find('.userPassword').text();
    let note = tr.find('.userNote').text();


    $("#Id").val(parseInt(id));
    $("#UserName").val(name);
    $("#UserLastName").val(lastName);
    $("#UserNickName").val(nickName);
    $("#UserPassword").val(password);
    $("#UserNote").val(note);
});