
$(document).ready(function () {
    var message = $("#Message").text();
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
    //handle bootstrap modal
    $('.js-render-modal').on('click', function () {
        var btn = $(this);
        var buttonModel = $('#Modal');
        buttonModel.find('#ModalLabel').text(btn.data('title')); 
        $.get({
            url: btn.data('url'),
            success: function (form) {
                buttonModel.find('.modal-body').html(form);
                $.validator.unobtrusive.parse(modal);
            },
            error: function (xhr) {
                swal.fire({
                    title: "Error",
                    text: "An error occurred while loading the modal content.",
                    icon: "error",
                    customClass: {
                        confirmButton: 'btn btn-outline  btn-outline-dashed btn-outline-primary- btn-active-light-primary'
                    }
                });
            }

        });
        buttonModel.modal('show');
    });
}); 