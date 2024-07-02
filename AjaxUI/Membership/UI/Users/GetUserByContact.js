$(document).ready(function() {
    $('#getUserDetailsBtn').on('click', function() {
        getUserdetailsByContact();
    });
});

function getUserdetailsByContact() {
    var userContact = $('#contact').val();
    $.ajax({
        url: 'http://localhost:5000/api/users/contact/' + userContact,
        type: 'GET',
        contentType: 'application/json',
        success: function(response) {
            var htmlContent = '<div class="overflow-x-auto"><table id="userByContactTable" class="min-w-full divide-y divide-gray-200"><thead class="bg-gray-50"><tr>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Id</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Image URL</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">First Name</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Last Name</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Birth Date</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Aadhar Id</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Gender</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Email</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Contact Number</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Created On</th>' +
                '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Modified On</th>' +
                '</tr></thead><tbody class="bg-white divide-y divide-gray-200">';

            htmlContent += '<tr>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.id + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.imageUrl + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.firstName + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.lastName + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.birthDate + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.aadharId + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.gender + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.email + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.contactNumber + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.createdOn + '</td>' +
                '<td class="px-6 py-4 whitespace-nowrap">' + response.modifiedOn + '</td>' +
                '</tr>';

            htmlContent += '</tbody></table></div>';
            $('#dataDisplay').html(htmlContent);
        },
        error: function(xhr, status, error) {
            console.error('Error:', status, error);
            alert("Failed to fetch user details.");
        }
    });
}
