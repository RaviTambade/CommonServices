function getUserdetailsByContact() {
    var userContact = $('#contact').val();
    $.ajax({
        url: 'http://localhost:5000/api/users/contact/' + userContact,
        type: 'GET',
        contentType: 'application/json',
        success: function (response) {
            var htmlContent = `
                <div class="table-responsive">
                    <table id="userByContactTable" class="table table-striped">
                        <thead>
                            <tr>
                                <th>Id</th>
                                <th>ImageUrl</th>
                                <th>FirstName</th>
                                <th>LastName</th>
                                <th>BirthDate</th>
                                <th>AadharId</th>
                                <th>Gender</th>
                                <th>Email</th>
                                <th>ContactNumber</th>
                                <th>CreatedOn</th>
                                <th>ModifiedOn</th>
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
            $('#dataDisplay').html(htmlContent);
        },
        error: function (xhr, status, error) {
            console.error('Error:', status + ': ' + error);
            alert("Failed to retrieve data.");
        }
    });
}
