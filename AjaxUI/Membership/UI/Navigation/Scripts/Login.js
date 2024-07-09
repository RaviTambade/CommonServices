$(document).ready(function() {
   var rolesInfo;
   var userId;

   $("#contactNo").change(function(){
    
      var contactNo = $("#contactNo").val();
      console.log("Contact " + contactNo);
      $.ajax({
        url: "http://localhost:5000/api/users/contact/" + contactNo,
        type: 'GET',
        contentType: 'application/json',
        success: function (userData) {
          console.log("User's Data:", userData.id);
          window.sessionStorage.setItem("userid", userData.id);
          
        },
          error: function (xhr, status, error) {
            console.error("Error authenticating user:", xhr.responseText);
           
          }
          
        });
        
         userId = window.sessionStorage.getItem("userid");
        $.ajax({
          url: "http://localhost:5000/api/roles/" + userId,
          type: 'GET',
          contentType: 'application/json',
          success: function (rolesData) {
            
            rolesInfo = rolesData;
            $("#lob").empty().append('<option value="">Select LOB</option>');
            rolesData.forEach(function(LOB) {    
              
              var option = $('<option></option>').attr("value", LOB.lob).text(LOB.lob);
              $("#lob").append(option);
          
            });

            $("#lob").change(function(){

              var selectedLob = $("#lob").val()
              console.log(selectedLob);
              //var role = rolesInfo.name;
              //console.log(role);

          });
           
          },
          error: function (xhr, status, error) {
            console.error("Error fetching roles:", xhr.responseText);
          }
        });

   });
   

   //After click on Sign In button
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
                var role = rolesData;

                rolesData.forEach(function(role) {
                  console.log("Role:", role.name);
                  // Redirect based on role name
                  if (role.name === "Director" ) 
                  {
                    
                    window.location.href = 'http://127.0.0.1:5500/Membership/UI/Navigation/DirectorDashboard.html';
                  } 
                  else if (role.name === "HR Manager" ) 
                  {
                    console.log("Role:", role.name);
                    window.location.href = 'http://127.0.0.1:5500/Membership/UI/Navigation/ManagerDashboard.html';
                  }
                  else
                  {
                    window.location.href = 'http://127.0.0.1:5500/Membership/UI/Navigation/UserProfile.html';
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
