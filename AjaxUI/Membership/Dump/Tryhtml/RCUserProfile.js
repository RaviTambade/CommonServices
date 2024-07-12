$(document).ready(function () {
   
        var userId = parseInt(sessionStorage.getItem("userid")); 
        $.ajax({
            url: "http://localhost:5000/api/users/userdetails/" + userId,
            type: 'GET',
            contentType: 'application/json',

            success: function (data) {
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
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
