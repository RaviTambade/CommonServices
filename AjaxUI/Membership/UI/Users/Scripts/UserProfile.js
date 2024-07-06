$(document).ready(function () {
    $("#btnShow").click(function () {
        var userId = $("#txtUserId").val();
        $.ajax({
            url: "http://localhost:5000/api/users/userdetails/" + userId,
            type: 'GET',
            contentType: 'application/json',

            success: function (data) {
                $("#pid").text(data.id);
                $("#pfname").text(data.firstName);
                $("#plname").text(data.lastName);
                $("#pemail").text(data.email);
                $("#paadharid").text(data.aadharId);
                $("#pdob").text(data.birthDate);
                $("#pcontact").text(data.contactNumber);
                $("#pgender").text(data.gender);
                $("#pimgurl").text(data.imageUrl);
                $("#pcreatedon").text(data.createdOn);
                $("#pmodifiedon").text(data.modifiedOn);
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});