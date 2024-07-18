$(document).ready(function () {
    console.log("Document.Ready");
    var userId = parseInt(sessionStorage.getItem("userid"));
    var userLob = sessionStorage.getItem("lob");
    var userFullName = sessionStorage.getItem("fullname");
    console.log("User Id = " + userId);
    console.log("LOB = "+ userLob);
    console.log("Name : "+ userFullName)
   
    $("#txtUserId").val(userId);
    $("#txtlob").val(userLob);
    $("#userdetails").text(userFullName);

    /*$('#txtUserId').change(function () {
      var id = $("#txtUserId").val();
      console.log("Input Id = " + id);

      $.ajax({
        url: `http://localhost:5000/api/users/details/id/` + id,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
          console.log(data);
          var name = data.fullName;
          $("#userdetails").html(name);
        },
        error: function (xhr, status, error) {
          console.error(xhr.responseText);
          alert("An error occurred while fetching the user details. Please try again.");
        }
      });
    });*/

   /* $.ajax({
      url: `http://localhost:5000/api/roles/lobs`,
      type: 'GET',
      contentType: 'application/json',
      success: function (data) {
        $("#ddlob").append('<option value="">Select LOB</option>');
        data.forEach(function (lob) {
          var option = $('<option></option>').attr("value", lob).text(lob);
          $("#ddlob").append(option);
        });
      },
      error: function (xhr, status, error) {
        console.error(xhr.responseText);
        alert("An error occurred while fetching the LOBs. Please try again.");
      }
    });

    $('#ddlob').change(function () {
      var selectedLob = $(this).val();
      if (selectedLob) {
        $.ajax({
          url: `http://localhost:5000/api/roles/lob/${selectedLob}`,
          type: 'GET',
          contentType: 'application/json',
          success: function (data) {
            if (Array.isArray(data)) {
              selectCheckbox(data, []); // Empty selectedRoles
            } else {
              console.error('Expected an array of roles, but received:', data);
            }
          },
          error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + ' ' + error);
          }
        });
      }
    });*/

   /* $("#btngetroles").click(function () {
      var userId = $("#txtUserId").val();
      var lob = $("#ddlob").val();

      if (userId && lob) {
        $.ajax({
          url: `http://localhost:5000/api/roles/users/${userId}/lob/${lob}`,
          type: 'GET',
          contentType: 'application/json',
          success: function (userRoles) {
            if (Array.isArray(userRoles)) {
              $.ajax({
                url: `http://localhost:5000/api/roles/lob/${lob}`,
                type: 'GET',
                contentType: 'application/json',
                success: function (allRoles) {
                  if (Array.isArray(allRoles)) {
                    selectCheckbox(allRoles, userRoles);
                  } else {
                    console.error('Expected an array of roles, but received:', allRoles);
                  }
                },
                error: function (xhr, status, error) {
                  console.error('AJAX Error: ' + status + ' ' + error);
                }
              });
            } else {
              console.error('Expected an array of roles, but received:', userRoles);
            }
          },
          error: function (xhr, status, error) {
            console.error('AJAX Error: ' + status + ' ' + error);
          }
        });
      } else {
        alert("Please enter a User ID and select a LOB.");
      }
    });

    $("#btnaddrole").click(function () {
      var userId = $("#txtUserId").val();
      var lob = $("#ddlob").val();

      if (userId && lob) {
        $("#checkboxContainer input:checkbox:checked").each(function () {
          var roleId = $(this).data('role-id');
          var userRole = {
            UserId: userId,
            RoleId: roleId,
            Lob: lob
          };

          $.ajax({
            url: `http://localhost:5000/api/roles/userroles`,
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(userRole),
            success: function () {
              console.log('Role added successfully');
              alert('Role added successfully');
            },
            error: function (xhr, status, error) {
              console.error('AJAX Error: ' + status + ' ' + error);
            }
          });
        });
      } else {
        alert("Please enter a User ID and select a LOB.");
      }
    });

    $("#btndeleterole").click(function () {
      var userId = $("#txtUserId").val();
      var lob = $("#ddlob").val();

      if (userId && lob) {
        $("#checkboxContainer input:checkbox:checked").each(function () {
          var roleId = $(this).data('role-id');

          $.ajax({
            url: `http://localhost:5000/api/roles/remove/userroles/userid/${userId}/roleid/${roleId}`,
            type: 'DELETE',
            contentType: 'application/json',
            success: function () {
              console.log('Role removed successfully');
              alert('Role removed successfully');
            },
            error: function (xhr, status, error) {
              console.error('AJAX Error: ' + status + ' ' + error);
              alert('Failed to remove role. Please try again.');
            }
          });
        });
      } else {
        alert("Please enter a User ID and select a LOB.");
      }
    });

    function selectCheckbox(allRoles, selectedRoles) {
      $('#checkboxContainer').empty();

      allRoles.forEach(function (role) {
        var checkbox = $('<input>').attr({
          type: 'checkbox',
          value: role.name,
          'data-role-id': role.id,
          class: 'mr-2'
        });

        var roleExists = selectedRoles.some(function (selectedRole) {
          return selectedRole.name === role.name;
        });

        checkbox.prop('checked', roleExists);

        var label = $('<label>').addClass('text-sm font-medium text-gray-700').text(role.name).prepend(checkbox);
        $('<div>').addClass('flex items-center space-x-2').append(label).appendTo('#checkboxContainer');
      });
    }*/


  });