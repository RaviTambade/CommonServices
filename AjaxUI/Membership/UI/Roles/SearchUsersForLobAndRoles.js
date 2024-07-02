$(document).ready(function () {
    var selectedLob;
    var selectedRole;

    // Fetch and display LOBs
    $.ajax({
        url: `http://localhost:5000/api/roles/lobs`,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
            console.log("LOB: ", data);
            $('#lobs').empty();
            data.forEach(function (lob) {
                var radiobutton = $('<input>').attr({
                    type: 'radio',
                    value: lob,
                    name: 'lob',
                    class: 'mr-2'
                });
                var label = $('<label>').text(lob).prepend(radiobutton);
                $('#lobs').append($('<div>').addClass('mb-2').append(radiobutton).append(label));
            });

            $('input:radio[name="lob"]').change(function () {
                selectedLob = $("input[name='lob']:checked").val();
                console.log("Selected LOB: " + selectedLob);
                $('#rolesSection').removeClass('hidden');
                fetchRoles(selectedLob);
            });
        },
        error: function (xhr, status, error) {
            console.error(xhr.responseText);
            alert("An error occurred while fetching the LOBs. Please try again.");
        }
    });

    // Fetch and display roles based on selected LOB
    function fetchRoles(lob) {
        if (lob) {
            $.ajax({
                url: `http://localhost:5000/api/roles/lob/${lob}`,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    if (data.length > 0) {
                        addRoleRadioButtons(data);
                    } else {
                        alert("No Roles Found.");
                    }
                },
                error: function (xhr, status, error) {
                    console.error("Error fetching roles: " + xhr.responseText);
                }
            });
        } else {
            alert("Please select a LOB.");
        }
    }

    // Add role radio buttons
    function addRoleRadioButtons(roles) {
        $('#roles').empty();
        roles.forEach(function (role) {
            var radiobutton = $('<input>').attr({
                type: 'radio',
                value: role.name,
                name: 'roleName',
                class: 'mr-2'
            });
            var label = $('<label>').text(role.name).prepend(radiobutton);
            $('#roles').append($('<div>').addClass('mb-2').append(radiobutton).append(label));
        });

        $('input[name="roleName"]').change(function () {
            selectedRole = $("input[name='roleName']:checked").val();
            console.log("Selected role: " + selectedRole);
            $('#userSection').removeClass('hidden');
            fetchUsersByRoleAndLob(selectedRole, selectedLob);
        });
    }

    // Fetch and display users based on selected role and LOB
    function fetchUsersByRoleAndLob(role, lob) {
        if (role && lob) {
            $.ajax({
                url: `http://localhost:5000/api/roles/getuserbyroles/rolename/${role}/lob/${lob}`,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    console.log("Users: ", data);
                    $('#user').empty();
                    data.forEach(function (user) {
                        var option = $('<option>').attr('value', user.id).text(user.firstName);
                        $('#user').append(option);
                    });

                    $('#user').change(function () {
                        var userId = $(this).val();
                        displayUserDetails(data, userId);
                    });
                },
                error: function (xhr, status, error) {
                    console.error("Error fetching users: " + xhr.responseText);
                    alert("An error occurred while fetching the users. Please try again.");
                }
            });
        } else {
            alert("Please select a role.");
        }
    }

    // Display user details
    function displayUserDetails(users, userId) {
        var user = users.find(user => user.id == userId);
        if (user) {
            var htmlContent = '<div>';
            htmlContent += '<p>Id: ' + user.id + '</p>';
            htmlContent += '<p>First Name: ' + user.firstName + '</p>';
            htmlContent += '<p>Last Name: ' + user.lastName + '</p>';
            htmlContent += '<p>Gender: ' + user.gender + '</p>';
            htmlContent += '<p>Contact Number: ' + user.contactNumber + '</p>';
            htmlContent += '<p>Email: ' + user.email + '</p>';
            htmlContent += '<p>Birth Date: ' + user.birthDate + '</p>';
            htmlContent += '<p>Aadhar Id: ' + user.aadharId + '</p>';
            htmlContent += '</div>';
            $('#dataDisplay').html(htmlContent);
        }
    }
});