$(document).ready(function () {
    var userId = 1;

    $.ajax({
        url: "http://localhost:5000/api/users/userdetails/" + userId,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            var fullname = data.firstName + " " + data.lastName;
            $("#fullname").text(fullname);
            $("#pemail").text(data.email);
            $("#paadharid").text(data.aadharId);
            $("#pdob").text(data.birthDate);
            $("#pcontact").text(data.contactNumber);
            $("#pgender").text(data.gender);
            $("#pimgurl").attr("src", data.imageUrl);
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
        }
    });

    $.ajax({
        url: "http://localhost:5000/api/addresses/users/" + userId,
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

    $(document).on('click', '#btnarea', function () {
        var currentVal = $('#parea').text().trim();
        $('#parea').html('<input type="text" id="inputArea" value="' + currentVal + '">');
        $('#btnarea').text('Save').attr('id', 'savearea');
    });

   
    $(document).on('click', '#savearea', function () {
        var newArea = $('#inputArea').val().trim();
        var data ={
            userId: userId,
            area : newArea
        };
        $.ajax({
            url: 'http://localhost:5000/api/addresses/update/area',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                $('#parea').text(newArea);
                $('#savearea').text('Edit').attr('id', 'btnarea');
            },
            error: function (xhr, status, error) {
                console.error('Error updating area:', xhr.responseText);
            }
        });
    });

    $(document).on('click','#btnlandmark',function () {
        var currentVal = $('#plandmark').text().trim();
        $('#plandmark').html('<input type="text" id="inputLandmark" value="' + currentVal + '">');
        $('#btnlandmark').text('Save').attr('id', 'savelandmark');
    });

    $(document).on('click', '#savelandmark', function () {
        var newLandmark = $('#inputLandmark').val().trim();
        var data = {
            userId : userId,
            landmark : newLandmark
        };
        $.ajax({
            url: 'http://localhost:5000/api/addresses/update/landmark',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                $('#plandmark').text(newLandmark);
                $('#savelandmark').text('Edit').attr('id', 'btnlandmark');
            },
            error: function (error) {
                console.error('Error updating landmark:', error);
            }
        });
    });

    $(document).on('click','#btncity',function () {
        var currentVal = $('#pcity').text().trim();
        $('#pcity').html('<input type="text" id="inputCity" value="' + currentVal + '">');
        $('#btncity').text('Save').attr('id', 'savecity');
    });

    $(document).on('click', '#savecity', function () {
        var newCity = $('#inputCity').val().trim();
        var data = {
            userId : userId,
            city : newCity
        };
        $.ajax({
            url: 'http://localhost:5000/api/addresses/update/city',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                $('#pcity').text(newCity);
                $('#savecity').text('Edit').attr('id', 'btncity');
            },
            error: function (error) {
                console.error('Error updating city:', error);
            }
        });
    });

    $(document).on('click','#btnstate',function () {
        var currentVal = $('#pstate').text().trim();
        $('#pstate').html('<input type="text" id="inputState" value="' + currentVal + '">');
        $('#btnstate').text('Save').attr('id', 'savestate');
    });

    $(document).on('click', '#savestate', function () {
        var newState = $('#inputState').val().trim();
        var data = {
            userId : userId,
            state : newState
        };
        $.ajax({
            url: 'http://localhost:5000/api/addresses/update/state',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                $('#pstate').text(newState);
                $('#savestate').text('Edit').attr('id', 'btnstate');
            },
            error: function (error) {
                console.error('Error updating state:', error);
            }
        });
    });

    $(document).on('click','#btnpincode',function () {
        var currentVal = $('#ppincode').text().trim();
        $('#ppincode').html('<input type="text" id="inputPincode" value="' + currentVal + '">');
        $('#btnpincode').text('Save').attr('id', 'savepincode');
    });

    $(document).on('click', '#savepincode', function () {
        var newPincode = $('#inputPincode').val().trim();
        var data = {
            userId : userId,
            pincode : newPincode
        };
        $.ajax({
            url: 'http://localhost:5000/api/addresses/update/pincode',
            type: 'PUT',
            contentType: 'application/json',
            data: JSON.stringify(data),
            success: function (response) {
                $('#ppincode').text(newPincode);
                $('#savepincode').text('Edit').attr('id', 'btnpincode');
            },
            error: function (error) {
                console.error('Error updating pincode:', error);
            }
        });
    });

});



