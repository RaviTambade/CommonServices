$(document).ready(function() {
    $('#addressForm').submit(function(event) {
        event.preventDefault(); // Prevent form submission

        // Get form data
        var formData = {
            UserId: $('#userId').val(),
            Area: $('#area').val(),
            LandMark: $('#landmark').val(),
            State: $('#state').val(),
            City: $('#city').val(),
            PinCode: $('#pincode').val(),
            Name: $('#name').val(),
            ContactNumber: $('#contactNumber').val(),
            AddressType: $('#addressType').val()
        };

        // Send AJAX request
        $.ajax({
            url: 'http://localhost:5000/api/addresses', 
            method: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(formData),
            success: function(response) {
                $('#message').text('Address inserted successfully.');
                $('#addressForm')[0].reset(); // Clear form fields
            },
            error: function(xhr, status, error) {
                var errorMessage = xhr.status + ': ' + xhr.statusText;
                $('#message').text('Error inserting address: ' + errorMessage);
            }
        });
    });
});