function RequiredSubmitFunction() {
    var isValid = true;
    $('input[type="text"],select,textarea').each(function () {   // Loop thru all the elements    
        if (this.required) {
            var name = $(this).val();
            if (this.type.match(/select.*/) && name == "0") {
                name = "";
            }
            if (name == "") {  // If not empty do nothing
                RequiredFieldValidate(this.id);
                isValid = false;
                return isValid;
            } else {
                isValid = true;
                return isValid;
            }
        }
    });
    return isValid;
}
function RequiredFieldValidate(el) {
    var name = document.getElementById(el).value;
    if (document.getElementById(el).type.match(/select.*/) && name == "0") {
        name = "";
    }
    if (name == "") {
        document.getElementById(el).style.borderColor = '#e52213';
        var elment = document.getElementsByClassName("select2-selection");
        if (elment.length > 0) {
            document.getElementsByClassName("select2-selection")[0].style.borderColor = '#e52213';
        }
        //toastr.warning("" + el + " can not be Empty");
        return false;
    } else {
        document.getElementById(el).style.borderColor = '#ced4da';
        var elment = document.getElementsByClassName("select2-selection");
        if (elment.length > 0) {
            document.getElementsByClassName("select2-selection")[0].style.borderColor = '#ced4da';
        }
        return true;
    }
}

function getDataTableProperty(tableName, length) {
    if (length == "Gen") {
        $('#' + tableName).DataTable({
            "paging": true,
            "pageLength": 10,
            "lengthChange": true,
            "searching": true,
            "ordering": false,
            "info": true,
            "autoWidth": false,
            "responsive": true,
        });
    }
    if (length == "Five") {
        $('#' + tableName).DataTable({
            "paging": true,
            "pageLength": 5,
            "lengthChange": true,
            "searching": true,
            "ordering": false,
            "info": true,
            "autoWidth": false,
            "responsive": true,
        });
    }
    if (length == "Ten") {
        $('#' + tableName).DataTable({
            "paging": true,
            "pageLength": 10,
            "lengthChange": true,
            "searching": true,
            "ordering": true,
            "info": true,
            "autoWidth": false,
            "responsive": true,
        });
    }
}