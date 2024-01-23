window.ShowToastr = (type, message) => {
    if (type === "success") {
        toastr.success(message, "operation successed");
    }
    if (type === "error") {
        toastr.error(message, "operation failed");
    }
}

function ShowDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('show');
}
function HideDeleteConfirmationModal() {
    $('#deleteConfirmationModal').modal('hide');
}