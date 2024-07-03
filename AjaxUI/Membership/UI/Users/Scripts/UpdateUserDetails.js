$(document).ready(function () {
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
                alert("User details updated successfully.");
            } else {
                alert("Failed to update user details.");
            }
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("Error updating user details: " + xhr.responseText);
        }
    });
}
