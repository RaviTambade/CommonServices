$(document).ready(function() {
    $('#getAddressesBtn').click(function() {
        const addressId = $('#addressId').val();
        if (!addressId) {
            alert('Please enter an Address ID');
            return;
        }

        $.ajax({
            url: `http://localhost:5000/api/addresses/${addressId}`,
            method: 'GET',
            success: function(address) {
                displayAddress(address);
            },
            error: function() {
                console.error('There was a problem with the fetch operation.');
            }
        });
    });

    function displayAddress(address) {
        const tbody = $('#addressesTable tbody');
        tbody.empty(); // Clear previous data
        const row = $('<tr>');
        row.append($('<td>').addClass('border p-2').text(address.id));
        row.append($('<td>').addClass('border p-2').text(address.userId));
        row.append($('<td>').addClass('border p-2').text(address.area));
        row.append($('<td>').addClass('border p-2').text(address.landMark));
        row.append($('<td>').addClass('border p-2').text(address.city));
        row.append($('<td>').addClass('border p-2').text(address.state));
        row.append($('<td>').addClass('border p-2').text(address.pinCode));
        row.append($('<td>').addClass('border p-2').text(address.addressType));
        row.append($('<td>').addClass('border p-2').text(address.contactNumber));
        row.append($('<td>').addClass('border p-2').text(address.name));
        tbody.append(row);
    }
});
