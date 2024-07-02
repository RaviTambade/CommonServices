$(document).ready(function () {
    $('#updateAddressForm').submit(function (event) {
        event.preventDefault();

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
        console.log(addressData);

        $.ajax({
            url: `http://localhost:5000/api/addresses`,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(addressData),
            success: function () {
                $('#message').text('Address updated successfully.').addClass('text-green-500');
                $('#updateAddressForm')[0].reset();
            },
            error: function () {
                $('#message').text('There was a problem with the update operation.').addClass('text-red-500');
            }
        });
    });
});
