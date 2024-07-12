$(document).ready(function () {
    console.log("Document.Ready");
    $("#lob").change(function () {

        var lob = $("#lob").val();
        console.log(lob)

        $.ajax({
            url: `http://localhost:5000/api/roles/getUserAndRoles/lob/` + lob,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                console.log(data)
                /* data.foreach(function (data) {
                    var fullName = data.firstName + " " + data.lastName;
                    $("#name").text(fullName);
                    $("#id").text(data.userId);
                    $("#role").text(data.roleName);
                }) */
                    $("#id").text(data.userId);

            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                alert("An error occurred while fetching the LOBs. Please try again.");
            }
        });
    });


});