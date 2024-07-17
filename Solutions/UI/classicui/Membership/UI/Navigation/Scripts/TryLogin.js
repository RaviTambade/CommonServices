$(document).ready(function () {
    var rolesInfo;
    var userId;
    sessionStorage.clear();
    localStorage.clear();

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
                            window.sessionStorage.setItem("lob",selectedLob);

                            console.log("selectedLob = " + selectedLob);

                            //Use API (userid and lob)
                            $.ajax({
                                url:"http://localhost:5000/api/roles/users/"+userId+"/lob/"+selectedLob,
                                typr:"GET",
                                contentType:'application/json',
                                success:function(data){
                                    console.log(data);
                                    var userRole = data[0].name; //Check this
                                    console.log("User Role Inside Sign In button : ",userRole);
                                    $("#btnsubmit").click(function () {
                                        var contactNo = $("#contactNo").val();
                                        var pass = $("#pass").val();
                                        var lob = $("#lob").val();
        
                                        var claimData = {
                                            "ContactNumber": contactNo,
                                            "password": pass,
                                            "lob": lob
                                        };
                                        console.log(claimData);
                                        console.log("inside the btn submit....");
                                        $.ajax({

                                            url: "http://localhost:5000/api/auth/signin",
                                            type: 'POST',
                                            data: JSON.stringify(claimData),
                                            contentType: 'application/json',
                                            success: function (data) {
                                                console.log("Token:", data.token);
                                                localStorage.setItem('token', data.token);
                                               if(data.token)
                                               {
                                                if (userRole === "Director") {
<<<<<<< HEAD
                                                    window.location.href = 'Director.html';
                                                    
                                                }
                                                else if (userRole === "HR Manager") {
                                                    window.location.href = 'Manager.html';
=======
                                                    window.location.href = '../navigation/dashboard/Director.html';
                                                    
                                                }
                                                else if (userRole === "HR Manager") {
                                                    window.location.href = '../navigation/dashboard/HRManager.html';
>>>>>>> 36f0ed810f9c9f964c5832b625d31d1acfe64176
                                                    
                                                }
                                                else if (userRole === "collection manager") {
                                                    window.location.href = 'Manager.html';
                                                    
                                                }
                                                else {
                                                    window.location.href = 'User.html';
                                                    
                                                }

                                               }
                                               else{
                                                alert("Enter valid Contact Number or Password")
                                               }
                                                
        
                                            },
                                            error: function (xhr, status, error) {
                                                console.error("Error authenticating user:", xhr.responseText);
                                            }
                                        });
                                    });
        

                                },
                                error: function (xhr, status, error) {
                                    console.error("Error getting user role:", xhr.responseText);
                                }
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