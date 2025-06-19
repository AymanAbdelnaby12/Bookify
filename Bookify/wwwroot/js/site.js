

$(document).ready(function () {
    var message = $("#message").text().trim();
if (message !== '') {
    swal.fire({
        title: "Success",
        text: "Category status updated successfully!",
        icon: "success",
        customClass: {
            confirmButton: 'btn btn-outline  btn-outline-dashed btn-outline-primary- btn-active-light-primary'
        }
    });
}
}); 