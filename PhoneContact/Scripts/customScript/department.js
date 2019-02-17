$(document).ready(function () {

    $(document).on("click", "#departmanTable button.editDepartment", function () {

        let tr = $(this).closest('tr');

        let id = tr.find('.departmentId').text();
        let name = tr.find('.departmentName').text();
        let code = tr.find('.departmentCode').text();
        let note = tr.find('.departmentNote').text();

        $("#Id").val(parseInt(id));
        $("#DepartmentName").val(name);
        $("#DepartmentCode").val(code);
        $("#DepartmentNote").val(note);
    });

    $(document).on("click", "#departmanTable button.newDepartment", function () {

        $("#DepartmentId").val(0);
        $("#DepartmentName").val("");
        $("#DepartmentCode").val("");
        $("#DepartmentNote").val("");
    });

    $(document).on("click", "#departmanTable button.deleteDepartment", function () {

        var result = confirm("Are you sure?");

        if (result == true) {
            let tr = $(this).closest('tr');
            let id = tr.find('.departmentId').text();

            $("#Id").val(parseInt(id));

            var form = document.createElement("form");
            var elementId = document.createElement("input");

            form.method = "POST";
            form.action = "/Department/Delete";

            elementId.value = id;
            elementId.name = "Id";
            form.appendChild(elementId);

            document.body.appendChild(form);

            form.submit();
        }
    });
});