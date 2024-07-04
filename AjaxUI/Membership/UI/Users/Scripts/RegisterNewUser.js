$(document).ready(function() {
    $('#frm_applicant').submit(function(event) {
        event.preventDefault(); // Prevent default form submission

        // Get values from form fields
        var imageUrl = $('#imgurl').val();
        var aadharId = $('#aadharid').val();
        var firstName = $('#fname').val();
        var lastName = $('#lname').val();
        var birthDate = $('#birthdate').val();
        var gender = $("input[type='radio'][name='gender']:checked").val();
        console.log(gender);
        var email = $('#email').val();
        var contact = $('#contact').val();

        var password = $('#password').val();

        // Create data object to send via AJAX
        var newData = {
            "imageUrl": imageUrl,
            "firstName": firstName,
            "lastName": lastName,
            "birthDate": birthDate,
            "aadharId": aadharId,
            "gender": gender,
            "email": email,
            "contactnumber": contact,
            "password": password
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
