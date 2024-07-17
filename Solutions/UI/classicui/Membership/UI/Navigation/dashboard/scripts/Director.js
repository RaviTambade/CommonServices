$(document).ready(function () {
    console.log("Inside Director DashBoard.js");
    var userId = parseInt(sessionStorage.getItem("userid"));

    console.log("User Id = " + userId);
    $("#uid").text(userId);

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

    const dropdownButton = $('.relative button');
    const dropdownMenu = $('.relative .absolute');

    dropdownButton.on('click', function () {
        dropdownMenu.toggleClass('hidden');
    });
});
