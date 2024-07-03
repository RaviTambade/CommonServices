$(document).ready(function () {
    $('#deleteAddressForm').submit(function (event) {
        event.preventDefault();

        const existingId = $('#existingId').val();

        $.ajax({
            url: `http://localhost:5000/api/addresses/${existingId}`,
            method: 'DELETE',
            success: function () {
                $('#message').text('Address deleted successfully.').addClass('text-green-500');
                $('#deleteAddressForm')[0].reset();
            },
            error: function () {
                $('#message').text('There was a problem with the delete operation.').addClass('text-red-500');
            }
        });
    });
});
