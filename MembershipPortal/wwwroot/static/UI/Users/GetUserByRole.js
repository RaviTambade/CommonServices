

function getUserdetailsByRole() {

    // AJAX GET request to getall data from database
    var UserRole = $('#role').val();
    $.ajax({
        url: 'http://localhost:5000/api/users/roles/' + UserRole,
        type: 'GET',
        contentType: 'application/json',

        success: function (response) {


            var htmlContent = '<div class="table-responsive"> <table id="userByRoleTable "  class="table table-striped"> <thead> <tr>' +
                '<th>Id</th><th>ImageUrl</th><th>FirstName</th><th>LastName</th><th>BirthDate<th>AadharId</th><th>Gender</th><th>Email</th><th>contactNumber</th><th>CreatedOn</th><th>ModifiedOn</th> </tr></thead><body>';
            $.each(response, function (index, item) {
                htmlContent += '<tr>';
                htmlContent += '<td>' + item.id + '</td>';
                htmlContent += '<td>' + item.imageUrl + '</td>';
                htmlContent += '<td>' + item.firstName + '</td>';
                htmlContent += '<td>' + item.lastName + '</td>';
                htmlContent += '<td>' + item.birthDate + '</td>';
                htmlContent += '<td>' + item.aadharId + '</td>';
                htmlContent += '<td>' + item.gender + '</td>';
                htmlContent += '<td>' + item.email + '</td>';
                htmlContent += '<td>' + item.contactNumber + '</td>';
                //htmlContent += '<td>'+item.password + '</td>';
                htmlContent += '<td>' + item.createdOn + '</td>';
                htmlContent += '<td>' + item.modifiedOn + '</td>';
                // htmlContent += '<td>' + '<button id="edit" class="btn btn-success">Edit</button>' + '<button id="delete" class="btn btn-danger">Delete</button>' + '</td>';
                htmlContent += '</tr>';
            });

            htmlContent += '</tbody></table></div>';
            $('#dataDisplay').html(htmlContent);

        },
        error: function (xhr, status, error) {
            console.error('Error:', status + ': ' + error);

        }
    });
};

