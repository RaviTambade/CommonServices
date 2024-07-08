$(document).ready(function() {
    $("#btnsubmit").click(function () {    
      var contactNo = $("#contactNo").val();
      console.log(contactNo);
      var pass = $("#pass").val();
      var lob = $("#lob").val();

      var Claim = {"ContactNumber": contactNo, "password": pass, "lob": lob};

      $.ajax({
        url: "http://localhost:5000/api/auth/signin",
        type: 'POST',
        data: JSON.stringify(Claim),
        contentType: 'application/json',
        success: function (data) {
          console.log(data.token);
          localStorage.setItem('token', data.token); // Assuming 'token' is returned from API
        },
        error: function (xhr, status, error) {
          console.error(xhr.responseText);
        }
      });

      $.ajax({
        url: "http://localhost:5000/api/users/contact/"+ contactNo,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
          console.log("Use's Data : "+ data.id);
          //const Userdata = JSON.parse(data);
          //console.log(Userdata);
          window.sessionStorage.setItem("userid", data.id);
         // window.localStorage.setItem("userid",data);

         jQuery( document ).ajaxSuccess(function( event, xhr, settings ) {
          window.location.href = 'http://127.0.0.1:5500/Membership/UI/Navigation/UserProfile.html';
        });
        
          //localStorage.setItem('token', data.token); // Assuming 'token' is returned from API
        },
        error: function (xhr, status, error) {
          console.error(xhr.responseText);
        }
      });
     
    });

  });