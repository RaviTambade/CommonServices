$(document).ready(function() {
    // Event handler for checkboxes
          $("#btnsubmit").click(function () {    
  
          var contactNo = $("#contactNo").val();
          var pass = $("#pass").val();
          var lob = $("#lob").val();
  
          var Claim = {"ContactNumber":contactNo, "password":pass,"lob":lob}
        
          $.ajax({
          url: "http://localhost:5000/api/auth/signin",
          type: 'POST',
          data: JSON.stringify(Claim),
          contentType: 'application/json',
  
          success: function (data) {
              console.log(data.token);
              //var tokenData = JSON.stringify(data);
              localStorage.setItem('token',data.token);
          },
          error: function (xhr, status, error) {
              console.error(xhr.responseText);
          }
      });
     });
  });
  