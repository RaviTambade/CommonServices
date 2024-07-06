$(document).ready(function () {
    $("#btnsubmit").click(function () {
      var oldPassword = $("#oldPass").val();
      var newPassword = $("#newPass").val();

      var update = {
        "oldPassword": oldPassword,
        "newPassword": newPassword
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
          console.error(xhr.responseText);
        }
      });
    });
  });