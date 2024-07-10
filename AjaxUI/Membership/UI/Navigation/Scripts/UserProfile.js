$(document).ready(function () {
    console.log("Inside userProfile.js");
    var userId = parseInt(sessionStorage.getItem("userid"));
    console.log("User Id = " + userId);
    document.getElementById("uid").innerHTML = userId;

    $.ajax({
        url: "http://localhost:5000/api/users/userdetails/" + userId,
        type: 'GET',
        contentType: 'application/json',

        success: function (data) {
            $("#profilePhoto").attr("src", data.imageUrl); // Update profile photo
            $("#userName").text(data.firstName + " " + data.lastName);
            $("#userEmail").text(data.email);
            $("#userRole").text(data.role); // Assuming you have a role field in your data

            $("#pfname").text(data.firstName);
            $("#plname").text(data.lastName);
            $("#pemail").text(data.email);
            $("#paadharid").text(data.aadharId);
            $("#pdob").text(data.birthDate);
            $("#pcontact").text(data.contactNumber);
            $("#pgender").text(data.gender);
            $("#pid").text(data.id);
            // $("#pcreatedon").text(data.createdOn);
            // $("#pmodifiedon").text(data.modifiedOn);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });

    $("#btnShowDetails").click(function () {
        $("#additionalDetails").toggleClass("hidden");
    });
});
