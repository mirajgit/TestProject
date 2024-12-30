function getEmployeeFunction(EmpId) {
    var param = {};
    param.EmpId = EmpId;

    $.get("/Employee/EditEmployee", param, function (res) {
        if (!res.Success) {
            toastr.warning(res.Message);
        }
        else {
            $("#EmpId").val(res.Record.EmpId);
            $("#RoleId").val(res.Record.RoleId);
            $("#EmpContact").val(res.Record.EmpContact);
            $("#EmpName").val(res.Record.EmpName);
            $("#EmpAddress").val(res.Record.EmpAddress);
            $('#Status').prop('checked', res.Record.Status);
            $("#btnSave").html('Update');
            $("#btnSave").removeClass("btn btn-md btn-primary").addClass('btn btn-md btn-success');
        }
    });
}


function GetDataOnPageLoad() {
    $("#EmployeeList").html("");
    $.ajax({
        type: "POST",
        url: "/Employee/EmployeeList",
        success: function (response) {
            $("#EmployeeList").html(response);
        //    getDataTableProperty("tblModule", "Ten");
        }
    })
}
function ClearUI() {
    $("#EmpId").val('0');
    $("#RoleId").val('0');
    $("#EmpName").val('');
    $("#EmpContact").val('');
    $("#EmpAddress").val('');
    $("#Status").prop('checked', false);
    $("#btnSave").html('Submit');
    $("#btnSave").removeClass("btn btn-md btn-success").addClass('btn btn-md btn-primary');
}
$(document).ready(function () {
    GetDataOnPageLoad();
    $("#btnSave").click(function () {
        var isValid = true;
        isValid = RequiredSubmitFunction();
        if (isValid) {
            var EmpId = $("#EmpId").val();
            var RoleId = $("#RoleId").val();
            var EmpName = $("#EmpName").val();
            var EmpContact = $("#EmpContact").val();
            var EmpAddress = $("#EmpAddress").val();
            var Status = $("#Status").prop('checked');

            var data = {
                EmpId: EmpId,
                RoleId: RoleId,
                EmpName: EmpName,
                EmpContact: EmpContact,
                EmpAddress: EmpAddress,
                Status: Status,
            };
            $.ajax({
                type: "POST",
                url: "/Employee/SaveEmployee",
                data: data,
                success: function (data) {
                    if (!data.Success) {
                        toastr.warning(data.Message);
                    }
                    else {
                        ClearUI();
                        GetDataOnPageLoad();
                        toastr.success(data.Message);
                    }
                }
            })
        }
    })
});