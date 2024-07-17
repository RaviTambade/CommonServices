$(document).ready(function() {
    $('#getUserdetailsByUserIds').on('click', function() {
        userdetailsByUserIds();
    });
});

function userdetailsByUserIds() {
    var UserIds = $('#userids').val();
    $.ajax({
        url: 'http://localhost:5000/api/users/ids/' + UserIds,
        type: 'GET',
        contentType: 'application/json',
        success: function(response) {
            console.log('Got the Data :', response);
            alert("Data retrieved successfully");

            var htmlContent = '<div class="table-responsive"><table id="userByRoleTable" class="table-auto w-full"><thead><tr>' +
                '<th class="px-4 py-2">Id</th><th class="px-4 py-2">ImageUrl</th><th class="px-4 py-2">FirstName</th><th class="px-4 py-2">LastName</th><th class="px-4 py-2">BirthDate</th><th class="px-4 py-2">AadharId</th><th class="px-4 py-2">Gender</th><th class="px-4 py-2">Email</th><th class="px-4 py-2">ContactNumber</th><th class="px-4 py-2">CreatedOn</th><th class="px-4 py-2">ModifiedOn</th></tr></thead><tbody>';
                
            $.each(response, function(index, item) {
                htmlContent += '<tr>';
                htmlContent += '<td class="border px-4 py-2">' + item.id + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.imageUrl + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.firstName + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.lastName + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.birthDate + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.aadharId + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.gender + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.email + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.contactNumber + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.createdOn + '</td>';
                htmlContent += '<td class="border px-4 py-2">' + item.modifiedOn + '</td>';
                htmlContent += '</tr>';
            });

            htmlContent += '</tbody></table></div>';
            $('#dataDisplay').html(htmlContent);
        },
        error: function(xhr, status, error) {
            console.error('Error:', status + ': ' + error);
            alert("Failed to retrieve data");
        }
    });
}
