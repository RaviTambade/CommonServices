$(document).ready(function () {
    console.log("Inside ManagerDashBoard.js");
    var userId = parseInt(sessionStorage.getItem("userid"));

        console.log("User Id = " +userId);
        $("#uid").text = userId;
       
        //document.getElementById("uid").innerHTML = userId;

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

    });