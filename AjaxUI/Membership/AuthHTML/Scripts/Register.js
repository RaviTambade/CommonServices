$(document).ready(function() {
    $("#btnsubmit").click(function () {    
        var user = {
            ImageUrl: $("#imageurl").val(),
            AadharId: $("#aadharid").val(),
            FirstName: $("#firstname").val(),
            LastName: $("#lastname").val(),
            BirthDate: $("#birthdate").val(),
            Gender: $("#gender").val(),
            Email: $("#email").val(),
            ContactNumber: $("#contactnumber").val(),
            Password: $("#password").val()
        };

        $.ajax({
            url: "http://localhost:5000/api/users",
            type: 'POST',
            data: JSON.stringify(user),
            contentType: 'application/json',
            success: function (data) {
                alert("Registration successful!");
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                alert("Registration failed. Please try again.");
            }
        });
    });
});