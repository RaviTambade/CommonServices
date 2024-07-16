$(document).ready(function () {
  console.log("in update.password js file");
  var userId = parseInt(sessionStorage.getItem("userid")); 

  $.ajax({
    url: "http://localhost:5000/api/users/userdetails/" + userId,
    type: 'GET',
    contentType: 'application/json',

    success: function (data) {
       console.log(data);
       $("#fname").text(data.firstName);
       $("#lname").text(data.lastName);
        
    },
    error: function (xhr, status, error) {
        console.error(xhr.responseText);
    }
});


  $("#btnsubmit").click(function () {
    var oldPassword = $("#oldPass").val();
    var newPassword = $("#newPass").val();
    var confirmPassword = $("#confirmpass").val();

    var update = {
      "oldPassword": oldPassword,
      "newPassword": newPassword,
      "confirmPassword": confirmPassword
    };

    function getToken() {
      return localStorage.getItem('token');
    }

    $.ajax({
      url: "http://localhost:5000/api/auth/updatepassword",
      type: 'PUT',
      headers: {
        'Authorization': 'Bearer ' + getToken()
      },
      data: JSON.stringify(update),
      contentType: 'application/json',
      success: function (data) {
        if (data === true)
          alert("Password Changed Successfully");
        else
          alert("Failed To Change Password");
      },
      error: function (xhr, status, error) {
        console.error("Failed to change password:", xhr.responseText);
      }
    });
  });
});
