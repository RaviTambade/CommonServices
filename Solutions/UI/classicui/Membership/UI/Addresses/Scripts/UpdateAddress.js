$(document).ready(function () {

    var userId = parseInt(sessionStorage.getItem("userid"));
    $.ajax({
        url: `http://localhost:5000/api/addresses/users/${userId}`,
        method: 'GET',
        success: function (data) {
            console.log(data);
            $("#existingId").val(data[0].id);
            $("#userId").val(data[0].userId);
            $("#area").val(data[0].area);
            $("#landmark").val(data[0].landMark);
            $("#state").val(data[0].state);
            $("#city").val(data[0].city);
            $("#pincode").val(data[0].pinCode);
        },
        error: function () {
            console.error('There was a problem with the fetch operation.');
        }
    });
    $('#updateAddressForm').submit(function (event) {
        event.preventDefault();
        var existingId = $('#existingId').val();
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
        console.log(existingId);
        console.log(addressData);
        $.ajax({
            url: 'http://localhost:5000/api/addresses/' + existingId,
            method: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(addressData),
            success: function () {
                $('#message').text('Address updated successfully.').removeClass('text-red-500').addClass('text-green-500');
                $('#updateAddressForm')[0].reset();
                alert('Updated Successfully');
                window.location.href = '../Users/UserProfileDetails.html';
            },
            error: function () {
                $('#message').text('There was a problem with the update operation.').removeClass('text-green-500').addClass('text-red-500');
            }
        });
    });
});