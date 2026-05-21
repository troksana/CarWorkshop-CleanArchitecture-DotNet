$(document).ready(function () {

    LoadCarWorkshopServices();

    $(document).on('submit', '#createCarWorkshopServiceModal form', function (event) {
        event.preventDefault();

        $.ajax({
            url: $(this).attr('action'),
            type: $(this).attr('method'),
            data: $(this).serialize(),
            success: function (data) {
                toastr["success"]("Created CarWorkshop Service");
                LoadCarWorkshopServices();  // Zwróć uwagę na wielką literę S
                $('#createCarWorkshopServiceModal').modal('hide');
                $('#createCarWorkshopServiceModal form')[0].reset();
            },
            error: function () {
                toastr["error"]("Something went wrong");
            }
        });
    });
});