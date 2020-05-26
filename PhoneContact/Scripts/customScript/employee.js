$(document).ready(function () {
});

$(document).on("click", "#employeeTable button.editEmployee", function () {

    let tr = $(this).closest('tr');

    let id = tr.find('.employeeId').text();
    let name = tr.find('.employeeName').text();
    let lastName = tr.find('.employeeLastName').text();
    let phone = tr.find('.employeePhone').text();
    let note = tr.find('.employeeNote').text();

    $("#Id").val(parseInt(id));
    $("#EmployeeName").val(name);
    $("#EmployeeLastName").val(lastName);
    $("#EmployeePhone").val(phone);
    $("#EmployeeNote").val(note);

    //$("#submitForm").attr("method", "post");
    //$("#submitForm").attr("action", "/Department/Post");
});

$(document).on("click", "#employeeTable button.newEmployee", function () {

    $("#Id").val(0);
    $("#EmployeeName").val("");
    $("#EmployeeLastName").val("");
    $("#EmployeePhone").val("");
    $("#EmployeeNote").val("");
});


$(document).on("click", "#employeeTable button.detailEmployee", function () {

    let tr = $(this).closest('tr');
    let name = tr.find('.employeeName').text();
    let lastName = tr.find('.employeeLastName').text();
    let phone = tr.find('.employeePhone').text();
    let note = tr.find('.employeeNote').text();

    $("#name").val(name);
    $("#lastName").val(lastName);
    $("#phone").val(phone);
    $("#note").val(note);
});

$(document).on("click", "#employeeTable button.deleteEmployee", function () {

    var result = confirm("Are you sure?");

    if (result == true) {
        let tr = $(this).closest('tr');
        let id = tr.find('.employeeId').text();

        $("#Id").val(parseInt(id));

        var form = document.createElement("form");
        var elementId = document.createElement("input");

        form.method = "POST";
        form.action = "/PublicUI/Delete";

        elementId.value = id;
        elementId.name = "Id";
        form.appendChild(elementId);

        document.body.appendChild(form);

        form.submit();
    }
});