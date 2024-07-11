$(document).ready(function() {
    var rolesInfo;
    var userId;

    $("#contactNo").change(function() {
        var contactNo = $("#contactNo").val();
        console.log("Contact " + contactNo);

        $.ajax({
            url: "http://localhost:5000/api/users/contact/" + contactNo,
            type: 'GET',
            contentType: 'application/json',
            success: function(userData) {
                console.log("User's Data:", userData.id);
                window.sessionStorage.setItem("userid", userData.id);
                userId = userData.id;

                $.ajax({
                    url: "http://localhost:5000/api/roles/" + userId,
                    type: 'GET',
                    contentType: 'application/json',
                    success: function(rolesData) {
                        rolesInfo = rolesData;
                        console.log(rolesInfo);
                        $("#lob").empty().append('<option value="">Select LOB</option>');
                        rolesData.forEach(function(LOB) {
                            var option = $('<option></option>').attr("value", LOB.lob).text(LOB.lob);
                            $("#lob").append(option);
                        });

                        $("#lob").change(function() {
                            var selectedLob = $("#lob").val();
                            console.log("Selected LOB: " + selectedLob);

                            var selectedLOB = rolesData.find(role => role.lob === selectedLob);
                            if (selectedLOB) {
                                var selectedLOBId = selectedLOB.id;
                                var selectedLOBRole = selectedLOB.name;
                                console.log("Selected LOB ID: " + selectedLOBId);
                                console.log("Selected LOB Role: " + selectedLOBRole);
                            }
                        });
                    },
                    error: function(xhr, status, error) {
                        console.error("Error fetching roles:", xhr.responseText);
                    }
                });
            },
            error: function(xhr, status, error) {
                console.error("Error fetching user data:", xhr.responseText);
            }
        });
    });

    $("#btnsubmit").click(function() {
        var contactNo = $("#contactNo").val();
        var pass = $("#pass").val();
        var lob = $("#lob").val();

        var claimData = {   
            "ContactNumber": contactNo,
            "password": pass,
            "lob": lob
        };

        $.ajax({
            url: "http://localhost:5000/api/auth/signin",
            type: 'POST',
            data: JSON.stringify(claimData),
            contentType: 'application/json',
            success: function(data) {
                console.log("Token:", data.token);
                localStorage.setItem('token', data.token);


                $.ajax({
                    url: "http://localhost:5000/api/users/contact/" + contactNo,
                    type: 'GET',
                    contentType: 'application/json',
                    success: function(userData) {
                        console.log("User's Data:", userData.id);
                        window.sessionStorage.setItem("userid", userData.id);
                        var userId = userData.id;

                        $.ajax({
                            url: "http://localhost:5000/api/roles/" + userId,
                            type: 'GET',
                            contentType: 'application/json',
                            success: function(rolesData) {
                                console.log("Roles:", rolesData);

                                var roleFound = false;
                                for (var i = 0; i < rolesData.length; i++) {
                                    var role = rolesData[i];
                                    console.log("Role:", role.name);
                                    if (role.name === "Director") {
                                        window.location.href = 'DirectorDashboard.html';
                                        roleFound = true;
                                        break;
                                    } else if (role.name === "HR Manager") {
                                        window.location.href = 'ManagerDashboard.html';
                                        roleFound = true;
                                        break;
                                    }
                                }

                                if (!roleFound) {
                                    window.location.href = 'UserProfile.html';
                                }
                            },
                            error: function(xhr, status, error) {
                                console.error("Error fetching roles:", xhr.responseText);
                            }
                        });
                    },
                    error: function(xhr, status, error) {
                        console.error("Error fetching user data:", xhr.responseText);
                    }
                });
            },
            error: function(xhr, status, error) {
                console.error("Error authenticating user:", xhr.responseText);
            }
        });
    });
});
