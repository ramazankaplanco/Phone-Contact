let isAuthorized = false;

$(document).ready(function () {

    isAuthorized = $("#authorized").data("authorized") !== "False";

    getPublicUI();
});

$(document).on("click", "#employeeTable button.editEmployee", function () {

    let tr = $(this).closest('tr');

    let id = tr.find('.employeeId').text();
    let employerId = tr.find('.employerId').text();
    let departmentId = tr.find('.departmentId').text();
    let name = tr.find('.employeeName').text();
    let lastName = tr.find('.employeeLastName').text();
    let phone = tr.find('.employeePhone').text();
    let note = tr.find('.employeeNote').text();

    $("#Id").val(id);
    $("#EmployerId").val(employerId);
    $("#DepartmentId").val(departmentId);
    $("#EmployeeName").val(name);
    $("#EmployeeLastName").val(lastName);
    $("#EmployeePhone").val(phone);
    $("#EmployeeNote").val(note);

    //$("#submitForm").attr("method", "post");
    //$("#submitForm").attr("action", "/PublicUI/Post");
});

$(document).on("click", "#employeeTable button.newEmployee", function () {

    $("#employeeEditModal").modal("show");

    setTimeout(function () {

        $("#Id").val('');

        clearForm($("#employeeForm"));
    }, 500);
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

    if (result) {
        let tr = $(this).closest('tr');
        let id = tr.find('.employeeId').text();

        if (parseInt(id) > 0)
            deletePublicUI(id);
    }
});

$("#saveChanges").click(function () {

    if (isValidForm($("#employeeForm"))) {

        let employee = $("#employeeForm").serializeObject();

        parseInt(employee.Id) > 0 ? putPublicUI(employee) : postPublicUI(employee);
    }
});

function postPublicUI(employee) {
    request("/PublicUI/Post", employee, "POST").done(function (result, data) {
        if (result && data.Success) {

            $("#employeeEditModal").modal("hide");

            getPublicUI();

        } else alert(data.Message);
    });
}

function putPublicUI(employee) {
    request("/PublicUI/Put", { id: employee.Id, employee: employee }, "PUT").done(function (result, data) {
        if (result && data.Success) {

            $("#employeeEditModal").modal("hide");

            getPublicUI();

        } else alert(data.Message);
    });
}

function deletePublicUI(id) {
    request("/PublicUI/Delete", { id: id }, "DELETE").done(function (result, data) {
        if (result && data.Success) {

            $("#employeeEditModal").modal("hide");

            getPublicUI();

        } else alert(data.Message);
    });
}

function getPublicUI() {
    request("/PublicUI/Get").done(function (result, data) {
        if (result && data.Success) {

            let body = "";

            data.Data.forEach(function (employee) {
                body +=
                    '<tr>' +
                    '<td class="employeeId">' + employee.Id + '</td>' +
                    '<td class="employerId" hidden>' + employee.EmployerId + '</td>' +
                    '<td class="employerFullName">' + employee.EmployerFullName + '</td>' +
                    '<td class="employeeName">' + employee.EmployeeName + '</td>' +
                    '<td class="employeeLastName">' + employee.EmployeeLastName + '</td>' +
                    '<td class="employeePhone">' + employee.EmployeePhone + '</td>' +
                    '<td class="departmentId" hidden>' + employee.DepartmentId + '</td>' +
                    '<td class="departmentName">' + employee.DepartmentName + '</td>' +
                    '<td class="employeeNote">' + employee.EmployeeNote + '</td>';
                body += isAuthorized
                    ?
                    '<td>' +
                    '<button type="button" class="editEmployee btn btn-info small" data-toggle="modal" data-target="#employeeEditModal"><i class="fa fa-edit"></i>' +
                    '</button>' +
                    '<button type="button"class="deleteEmployee btn btn-danger small ml-1"><i class="fa fa-trash"></i>' +
                    '</button' +
                    '</td' +
                    '</tr>'
                    :
                    '<td>' +
                    '<button type="button" class="detailEmployee btn btn-info small" data-toggle="modal" data-target="#employeeDetailModal"><i class="fa fa-info-circle"></i>' +
                    '</button>' +
                    '</td' +
                    '</tr>';
            });

            $("#employeeTable tbody").html(body);

        } else alert(data.Message);
    });
}