$(document).ready(function (){
   
    $.ajax({
        url: "http://localhost:5000/api/roles/" + userId,
        type: 'GET',
        contentType: 'application/json',
        success: function (rolesData) {
          console.log("Roles:", rolesData);
          var userId = localStorage.getItem('userid');
          console.log(userId); 
        },
        error: function (xhr, status, error) {
          console.error("Error fetching roles:", xhr.responseText);
        }
      });





});