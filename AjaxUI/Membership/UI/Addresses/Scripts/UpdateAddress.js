$(document).ready(function () {
    $('#updateAddressForm').submit(function (event) {
        event.preventDefault();
        var existingId =  $('#existingId').val();
        var addressData = {
            id: $('#existingId').val(),
            userid: $('#userId').val(),
            area: $('#area').val(),
            landMark: $('#landmark').val(),
            state: $('#state').val(),
            city: $('#city').val(),
            pincode: $('#pincode').val(),
            addresstype: $('#addressType').val()
        };

        $.ajax({
            url: 'http://localhost:5000/api/addresses/'+existingId,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(addressData),
            success: function () {
                $('#message').text('Address updated successfully.').removeClass('text-red-500').addClass('text-green-500');
                $('#updateAddressForm')[0].reset();
            },
            error: function () {
                $('#message').text('There was a problem with the update operation.').removeClass('text-green-500').addClass('text-red-500');
            }
        });
    });
});
