$(document).ready(function() {

  $("#btnsubmit").click(function () {
    var contactNo = $("#contactNo").val();
    var pass = $("#pass").val();
    var lob = $("#lob").val();

    var claimData = {
      "ContactNumber": contactNo,
      "password": pass,
      "lob": lob
    };

   
    $.ajax({
      url: "http://localhost:5000/api/auth/signin",
      type: 'POST',
      data: JSON.stringify(claimData),
      contentType: 'application/json',
      success: function (data) {
        console.log("Token:", data.token);
        localStorage.setItem('token', data.token); 
        
      
        $.ajax({
          url: "http://localhost:5000/api/users/contact/" + contactNo,
          type: 'GET',
          contentType: 'application/json',
          success: function (userData) {
            console.log("User's Data:", userData.id);
            window.sessionStorage.setItem("userid", userData.id);
            var userId = userData.id;
            
            // Now fetch roles based on user ID
            $.ajax({
              url: "http://localhost:5000/api/roles/" + userId,
              type: 'GET',
              contentType: 'application/json',
              success: function (rolesData) {
                console.log("Roles:", rolesData);
               
                rolesData.forEach(function(role) {
                  console.log("Role:", role.name);
                  // Redirect based on role name
                  if (role.name === "Director") 
                  {
                    window.location.href = 'http://127.0.0.1:5500/AjaxUI/Membership/UI/Navigation/DirectorDashboard.html';
                  } 
                  else if (role.name === "HR Manager") 
                  {
                    window.location.href = 'http://127.0.0.1:5500/AjaxUI/Membership/UI/Navigation/ManagerDashboard.html';
                  }
                });
              },
              error: function (xhr, status, error) {
                console.error("Error fetching roles:", xhr.responseText);
              }
            });
          },
          error: function (xhr, status, error) {
            console.error("Error fetching user data:", xhr.responseText);
          }
        });
      },
      error: function (xhr, status, error) {
        console.error("Error authenticating user:", xhr.responseText);
       
      }
    });
  });

});
