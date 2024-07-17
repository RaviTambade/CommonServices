$(document).ready(function () {
    console.log("Inside Manager DashBoard.js");
    var userId = parseInt(sessionStorage.getItem("userid"));

    console.log("User Id = " + userId);
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
            $("#user-name").text(data.firstName + " " + data.lastName);

        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });

    const dropdownButton = document.querySelector('.relative button');
    const dropdownMenu = document.querySelector('.relative .absolute');


    dropdownButton.addEventListener('click', function () {
        dropdownMenu.classList.toggle('hidden');
    });
});