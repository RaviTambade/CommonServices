$(document).ready(function () {
    var userLOB = sessionStorage.getItem("lob");
    var userId = sessionStorage.getItem("userId");
    console.log("LOB of logged User: " + userLOB);

    $("#btngetroles").on("click", function () {
        var rolesContainer = $("#roles");
        rolesContainer.empty();

        $.ajax({
            url: `http://localhost:5000/api/roles/lob/${userLOB}`,
            type: 'GET',
            dataType: 'json',
            success: function (data) {
                if (data.length > 0) {
                    console.log(data);
                    data.forEach(function (item, index) {
                        console.log(item.name);
                        var radiobox = $('<input>', {
                            type: 'radio',
                            id: `option${index}`,
                            name: 'options',
                            value: item.name
                        });
                        var label = $('<label>', {
                            htmlFor: `option${index}`,
                            text: item.name
                        });
                        rolesContainer.append(radiobox, label);

                        // Attach the click event handler to the newly created radio buttons
                        radiobox.on('click', function () {
                            if ($(this).is(':checked')) {
                                var selectedOption = $(this).val();
                                console.log("Selected Option: " + selectedOption);
                            }
                        });
                    });
                } else {
                    rolesContainer.text("No Roles Found");
                }
            },
            error: function (error) {
                console.error(error);
            }
        });
    });

    // Fetch user details and update the user's name
    if (userId) {
        $.ajax({
            url: `http://localhost:5000/api/users/userdetails/${userId}`,
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                console.log(data);
                $("#user-name").text(`${data.firstName} ${data.lastName}`);
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    } else {
        console.error("User ID not found in session storage");
    }
});
