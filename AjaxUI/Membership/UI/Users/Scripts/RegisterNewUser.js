$(document).ready(function() {
    $('#frm_applicant').submit(function(event) {
        event.preventDefault(); // Prevent default form submission

        // Get values from form fields
        var firstName = $('#first_name').val();
        var lastName = $('#last_name').val();
        var birthDate = $('#birthdate').val();
        var gender = $("input[name='gender']:checked").val();
        var email = $('#email').val();
        var contact = $('#contact').val();
        var aadharId = $('#aadharid').val();

        // Create data object to send via AJAX
        var newData = {
            "firstName": firstName,
            "lastName": lastName,
            "birthDate": birthDate,
            "gender": gender,
            "email": email,
            "contactnumber": contact,
            "aadharId": aadharId
        };

        console.log(JSON.stringify(newData));

        // AJAX POST request to insert new data
        $.ajax({
            url: 'http://localhost:5000/api/users/add',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newData),
            success: function(data) {
                console.log('Data inserted:', data);
                alert("Successfully inserted...");
            },
            error: function(xhr, status, error) {
                console.error('Error:', status + ': ' + error);
                alert("Not inserted...");
            }
        });
    });
});
