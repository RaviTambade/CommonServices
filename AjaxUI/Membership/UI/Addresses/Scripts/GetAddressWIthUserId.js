$(document).ready(function () {
    $('#getAddressesBtn').click(function () {
        const userId = $('#userId').val();
        if (!userId) {
            alert('Please enter a User ID');
            return;
        }

        $.ajax({
            url: `http://localhost:5000/api/addresses/users/${userId}`,
            method: 'GET',
            success: function (addresses) {
                displayAddresses(addresses);
            },
            error: function () {
                console.error('There was a problem with the fetch operation.');
            }
        });
    });

    function displayAddresses(addresses) {
        const tbody = $('#addressesTable tbody');
        tbody.empty(); // Clear previous data
        addresses.forEach(address => {
            const row = $('<tr>');
            row.append($('<td>').text(address.userId));
            row.append($('<td>').text(address.area));
            row.append($('<td>').text(address.landMark));
            row.append($('<td>').text(address.city));
            row.append($('<td>').text(address.state));
            row.append($('<td>').text(address.pinCode));
            row.append($('<td>').text(address.addressType));
            row.append($('<td>').text(address.contactNumber));
            row.append($('<td>').text(address.name));
            tbody.append(row);
        });
    }
});
