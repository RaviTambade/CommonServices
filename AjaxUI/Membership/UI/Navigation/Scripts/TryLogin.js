$(document).ready(function () {
    var rolesInfo;
    var userId;

    $("#contactNo").change(function () {
        var contactNo = $("#contactNo").val();
        console.log("Contact " + contactNo);

        $.ajax({
            url: "http://localhost:5000/api/users/contact/" + contactNo,
            type: 'GET',
            contentType: 'application/json',
            success: function (userData) {
                console.log("User's ID:", userData.id);
                window.sessionStorage.setItem("userid", userData.id);
                userId = userData.id;

                $.ajax({
                    url: "http://localhost:5000/api/roles/" + userId,
                    type: 'GET',
                    contentType: 'application/json',
                    success: function (rolesData) {
                        rolesInfo = rolesData;
                        console.log(rolesInfo);
                        $("#lob").empty().append('<option value="">Select LOB</option>');
                        rolesData.forEach(function (LOB) {
                            var option = $('<option></option>').attr("value", LOB.lob).attr("id", LOB.id).text(LOB.lob);
                            $("#lob").append(option);
                        });

                        $("#lob").change(function () {
                            var selectedLob = $("#lob").val();
                            console.log("selectedLob = " + selectedLob);

                            //Use API (userid and lob)
                            $("#roleid").empty().append('<option value="">Select Role</option>');
                            rolesInfo.forEach(function (rolesInfo) {
                                console.log(rolesInfo.name);
                                var option = $('<option></option>').attr("value", rolesInfo.name).text(rolesInfo.name);
                                $("#roleid").append(option);

                            });

                            $("#roleid").change(function () {

                                var selectedRole = $("#roleid").val();
                                console.log(selectedRole);
                                $("#btnsubmit").click(function () {
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
                                        success: function (data) {
                                            console.log("Token:", data.token);
                                            localStorage.setItem('token', data.token);
    
                                            if (selectedRole === "Director") {
                                                window.location.href = 'DirectorDashboard.html';
                                                
                                            }
                                            else if (selectedRole === "HR Manager") {
                                                window.location.href = 'ManagerDashboard.html';
                                                
                                            }
                                            else if (selectedRole === "collection manager") {
                                                window.location.href = 'ManagerDashboard.html';
                                                
                                            }
                                            else if (selectedRole === "customer" || selectedRole === "employee") {
                                                window.location.href = 'UserProfile.html';
                                                
                                            }
    
                                        },
                                        error: function (xhr, status, error) {
                                            console.error("Error authenticating user:", xhr.responseText);
                                        }
                                    });
                                });
    
                               
                              });



                                                    });
                    },
                    error: function (xhr, status, error) {
                        console.error("Error fetching roles:", xhr.responseText);
                    }
                });
            },
            error: function (xhr, status, error) {
                console.error("Error fetching user data:", xhr.responseText);
            }
        });


    });


});
