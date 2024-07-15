$(document).ready(function () {
    console.log("Inside userProfile.js");
    var userId = parseInt(sessionStorage.getItem("userid"));
    console.log("User Id = " + userId);
   
    $.ajax({
        url: "http://localhost:5000/api/users/userdetails/" + userId,
        type: 'GET',
        contentType: 'application/json',

        success: function (data) {

            console.log("User Profile Data : "+data);
            var fullname = data.firstName+" "+data.lastName;
            $("#fullname").text(fullname);
            $("#pemail").text(data.email);
            $("#paadharid").text(data.aadharId);
            $("#pdob").text(data.birthDate);
            $("#pcontact").text(data.contactNumber);
            $("#pgender").text(data.gender);
            $("#pimgurl").attr("src",data.imageUrl);
            $("#pcreatedon").text(data.createdOn);
            $("#pmodifiedon").text(data.modifiedOn);
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
