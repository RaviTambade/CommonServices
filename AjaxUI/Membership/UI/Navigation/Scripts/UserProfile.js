$(document).ready(function () {
    console.log("Inside userProfile.js");
    var userId = parseInt(sessionStorage.getItem("userid"));
    console.log("User Id = " + userId);
    //$("#txtUserId").text = userId;
    document.getElementById("uid").innerHTML = userId;

    $("#btnShow").click(function () {
        // var userId = $("#txtUserId").val();

        $.ajax({
            url: "http://localhost:5000/api/users/userdetails/" + userId,
            type: 'GET',
            contentType: 'application/json',

            success: function (data) {
                $("#pfname").text(data.firstName);
                $("#plname").text(data.lastName);
                $("#pemail").text(data.email);
                $("#paadharid").text(data.aadharId);
                $("#pdob").text(data.birthDate);
                $("#pcontact").text(data.contactNumber);
                $("#pgender").text(data.gender);
                // $("#pid").text(data.id);
                // $("#pimgurl").text(data.imageUrl);
                // $("#pcreatedon").text(data.createdOn);
                // $("#pmodifiedon").text(data.modifiedOn);
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});