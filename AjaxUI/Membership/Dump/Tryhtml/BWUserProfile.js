$(document).ready(function () {
   
    var userId = 1;//parseInt(sessionStorage.getItem("userid")); 
    $.ajax({
        url: "http://localhost:5000/api/users/userdetails/"+userId,
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

    $.ajax({
        url: "http://localhost:5000/api/addresses/users/"+userId,
        type: 'GET',
        contentType: 'application/json',
        success: function (addressData) {
            $("#parea").text(addressData[0].area);
            $("#plandmark").text(addressData[0].landMark);
            $("#pcity").text(addressData[0].city);
            $("#pstate").text(addressData[0].state);
            $("#ppincode").text(addressData[0].pinCode);
            $("#ptype").text(addressData[0].addressType);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });
});

