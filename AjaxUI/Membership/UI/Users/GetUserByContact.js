$(document).ready(function () {
    function getUserdetailsByContact() {
        const userContact = $('#contact').val(); // Use const for variables that do not change
        const apiUrl = `http://localhost:5000/api/users/contact/${userContact}`;

        $.ajax({
            url: apiUrl,
            type: 'GET',
            contentType: 'application/json',
            success: function (response) {
                // Build HTML content for displaying user details
                const htmlContent = `
                    <div class="table-responsive">
                        <table id="userByContactTable" class="table table-striped">
                            <thead>
                                <tr>
                                    <th>Id</th>
                                    <th>Image URL</th>
                                    <th>First Name</th>
                                    <th>Last Name</th>
                                    <th>Birth Date</th>
                                    <th>Aadhar Id</th>
                                    <th>Gender</th>
                                    <th>Email</th>
                                    <th>Contact Number</th>
                                    <th>Created On</th>
                                    <th>Modified On</th>
                                </tr>
                            </thead>
                            <tbody>
                                <tr>
                                    <td>${response.id}</td>
                                    <td>${response.imageUrl}</td>
                                    <td>${response.firstName}</td>
                                    <td>${response.lastName}</td>
                                    <td>${response.birthDate}</td>
                                    <td>${response.aadharId}</td>
                                    <td>${response.gender}</td>
                                    <td>${response.email}</td>
                                    <td>${response.contactNumber}</td>
                                    <td>${response.createdOn}</td>
                                    <td>${response.modifiedOn}</td>
                                </tr>
                            </tbody>
                        </table>
                    </div>`;
                
                $('#dataDisplay').html(htmlContent); // Update HTML content with user details
            },
            error: function (xhr, status, error) {
                console.error('Error:', status, error); // Log detailed error information
                alert("Failed to fetch user details."); // Alert user about the error
            }
        });
    }

    // Event handler for button click
    $('#getUserDetailsBtn').click(function () {
        getUserdetailsByContact();
    });
});
