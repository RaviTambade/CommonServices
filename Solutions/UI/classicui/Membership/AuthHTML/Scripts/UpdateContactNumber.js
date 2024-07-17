$(document).ready(function () {
    $("#btnsubmit").click(function () {
        var newContact = $("#newContact").val();
        var password = $("#pass").val();

        var update = {
            "newContactNumber": newContact,
            "password": password
        }

        function getToken() {
            return localStorage.getItem('token');
        }

        $.ajax({
            url: "http://localhost:5000/api/auth/updatecontactnumber",
            type: 'PUT',
            headers: {
                'Authorization': 'Bearer ' + getToken()
            },
            data: JSON.stringify(update),
            contentType: 'application/json',

            success: function (data) {
                if (data == true)
                    alert("Number Changed Successfully")
                else
                    alert("Failed To Change Number")
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});