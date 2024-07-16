$(document).ready(function () {

    var userId = parseInt(sessionStorage.getItem("userid")); 
    $.ajax({
        url: "http://localhost:5000/api/users/userdetails/"+userId,
        type: 'GET',
        contentType: 'application/json',

        success: function (data) {
            $("#txtUserId").val(data.id);
            $("#txtFirstName").val(data.firstName);
            $("#txtLastName").val(data.lastName);
            $("#txtEmail").val(data.email);
            $("#txtAadharId").val(data.aadharId);
            $("#txtBirthDate").val(data.birthDate);
            $("#pgender").val(data.gender);
            $("#txtImageUrl").val(data.imageUrl);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });


    $('#btnUpdateUser').click(function () {
        updateUserDetails();
    });
});

function updateUserDetails() {
    var userId = $('#txtUserId').val();
    var user = {
        AadharId: $('#txtAadharId').val(),
        FirstName: $('#txtFirstName').val(),
        LastName: $('#txtLastName').val(),
        BirthDate: $('#txtBirthDate').val(),
        Gender: $('#txtGender').val(),
        Email: $('#txtEmail').val(),
        ImageUrl: $('#txtImageUrl').val()
    };

    $.ajax({
        url: `http://localhost:5000/api/users/${userId}`,
        type: 'PUT',
        contentType: 'application/json',
        data: JSON.stringify(user),
        success: function (result) {
            if (result) {
                alert("Updated Successfully.");
            } else {
                alert("Failed to update user details.");
            }
            window.location.href = 'UserProfileDetails.html';
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error updating user details: " + xhr.responseText);
        }
    });
}
