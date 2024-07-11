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
                console.log("User's Data:", userData.id);
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
                            var option = $('<option></option>').attr("value", LOB.lob).attr("id",LOB.id).text(LOB.lob);
                            $("#lob").append(option);
                        });

                        $("#lob").change(function () {
                            var selectedLob = $("#lob").val();
                            console.log(` ${selectedLob}` );

                           var selectedLOB = rolesData.find(role => role.lob === selectedLob);
                        //    for(i=0; i < rolesData.length;i++)
                        //    {
                        //      console.log(rolesData[i].id+" "+rolesData[i].name+" "+rolesData[i].lob);

                        //    }
                           console.log("Selected Lob : "+selectedLOB.name);
                            if (selectedLOB) {
                                var selectedLOBId = selectedLOB.id;
                                var selectedLOBRole = selectedLOB.name;
                                console.log("Selected LOB ID: " + selectedLOBId);
                                console.log("Selected LOB Role: " + selectedLOBRole);
                            }

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
                         
                                        if (selectedLOBRole === "Director" && selectedLob === "PMS")
                                        {
                                            window.location.href = 'DirectorDashboard.html';
                                            roleFound = true;
                                        } 
                                        else if (selectedLOBRole === "HR Manager" && selectedLob === "PMS" )
                                            {
                                                window.location.href = 'ManagerDashboard.html';
                                                roleFound = true;
                                            }
                                        else if (selectedLOBRole === "collection manager" && selectedLob === "EAgro" )
                                        {
                                            window.location.href = 'ManagerDashboard.html';
                                            roleFound = true;
                                        }
                        
                                    },
                                    error: function (xhr, status, error) {
                                        console.error("Error authenticating user:", xhr.responseText);
                                    }
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
