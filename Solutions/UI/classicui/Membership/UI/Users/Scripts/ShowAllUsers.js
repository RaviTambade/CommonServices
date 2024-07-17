$(document).ready(function() {
    $.ajax({
        url: 'http://localhost:5000/api/users',
        type: 'GET',
        contentType: 'application/json',
        success: function(response) {
            var htmlContent = '<div class="table-responsive"><table id="usersTable"><thead><tr>' +
                '<th>Id</th><th>Image URL</th><th>First Name</th><th>Last Name</th><th>Birth Date</th><th>Aadhar Id</th>' +
                '<th>Gender</th><th>Email</th><th>Contact Number</th><th>Password</th><th>Created On</th><th>Modified On</th>' +
                '</tr></thead><tbody>';

            $.each(response, function(index, item) {
                htmlContent += '<tr>' +
                    '<td>' + item.id + '</td>' +
                    '<td>' + item.imageUrl + '</td>' +
                    '<td>' + item.firstName + '</td>' +
                    '<td>' + item.lastName + '</td>' +
                    '<td>' + item.birthDate + '</td>' +
                    '<td>' + item.aadharId + '</td>' +
                    '<td>' + item.gender + '</td>' +
                    '<td>' + item.email + '</td>' +
                    '<td>' + item.contactNumber + '</td>' +
                    '<td>' + item.password + '</td>' +
                    '<td>' + item.createdOn + '</td>' +
                    '<td>' + item.modifiedOn + '</td>' +
                    '</tr>';
            });

            htmlContent += '</tbody></table></div>';
            $('#dataDisplay').html(htmlContent);
        },
        error: function(xhr, status, error) {
            console.error('Error:', status + ': ' + error);
        }
    });
});
