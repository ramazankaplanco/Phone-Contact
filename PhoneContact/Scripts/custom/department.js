$(document).ready(function () {

    getDepartment();
});

$(document).on("click", "#departmentTable button.editDepartment", function () {

    let tr = $(this).closest('tr');

    let id = tr.find('.departmentId').text();
    let name = tr.find('.departmentName').text();
    let code = tr.find('.departmentCode').text();
    let note = tr.find('.departmentNote').text();

    $("#Id").val(id);
    $("#DepartmentName").val(name);
    $("#DepartmentCode").val(code);
    $("#DepartmentNote").val(note);
});

$(document).on("click", "#departmentTable button.newDepartment", function () {

    $("#departmentEditModal").modal("show");

    setTimeout(function () {
        $("#Id").val('');

        clearForm($("#departmentForm"));
    }, 500);
});

$(document).on("click", "#departmentTable button.deleteDepartment", function () {

    var result = confirm("Are you sure?");

    if (result) {
        let tr = $(this).closest('tr');
        let id = tr.find('.departmentId').text();

        if (parseInt(id) > 0)
            deleteDepartment(id);
    }
});

$("#saveChanges").click(function () {

    if (isValidForm($("#departmentForm"))) {

        let department = $("#departmentForm").serializeObject();

        parseInt(department.Id) > 0 ? putDepartment(department) : postDepartment(department);
    }
});

function postDepartment(department) {
    request("/Department/Post", department, "POST").done(function (result, data) {
        if (result && data.Success) {

            $("#departmentEditModal").modal("hide");

            getDepartment();

        } else alert(data.Message);
    });
}

function putDepartment(department) {
    request("/Department/Put", { id: department.Id, department: department }, "PUT").done(function (result, data) {
        if (result && data.Success) {

            $("#departmentEditModal").modal("hide");

            getDepartment();

        } else alert(data.Message);
    });
}

function deleteDepartment(id) {
    request("/Department/Delete", { id: id }, "DELETE").done(function (result, data) {
        if (result && data.Success) {

            $("#departmentEditModal").modal("hide");

            getDepartment();

        } else alert(data.Message);
    });
}

function getDepartment() {
    request("/Department/Get").done(function (result, data) {
        if (result && data.Success) {

            let body = "";

            data.Data.forEach(function (department) {
                body +=
                    '<tr>' +
                    '<td class="departmentId">' + department.Id + '</td>' +
                    '<td class="departmentName">' + department.DepartmentName + '</td>' +
                    '<td class="departmentCode">' + department.DepartmentCode + '</td>' +
                    '<td class="departmentNote">' + department.DepartmentNote + '</td>' +
                    '<td>' +
                    '<button type="button" class="editDepartment btn btn-info small" data-toggle="modal" data-target="#departmentEditModal">' +
                    '<i class="fa fa-edit"></i>' +
                    '</button>' +
                    '<button type="button" class="deleteDepartment btn btn-danger small ml-1">' +
                    '<i class="fa fa-trash"></i>' +
                    '</button>' +
                    '</td>' +
                    '</tr>';
            });

            $("#departmentTable tbody").html(body);

        } else alert(data.Message);
    });
}