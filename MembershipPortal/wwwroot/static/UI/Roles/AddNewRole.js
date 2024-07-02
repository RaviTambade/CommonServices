// Ajax call to add new role
/* $(document).ready(function() {
    $('#btnaddrole').click(function() {
        var roleId = $('#roleid').val();
        var role = $('#role').val();
        var lob = $('#lob').val();

        var newRole = {
            id: roleId,
            name: role,
            lob: lob
        };
        console.log(newRole);

        $.ajax({
            url: 'http://localhost:5000/api/roles/addrole',
            type: 'POST',
            contentType: 'application/json',
            data: JSON.stringify(newRole),
            success: function(data) {
               alert("Role Added");
               
            },
            error: function(xhr, status, error) {
                console.error('Error adding role:', error);
               
            }
        });
    });
});
 */

document.getElementById('addnewrole').addEventListener('submit', function(event) {
    event.preventDefault();

    const roleId = document.getElementById('roleid').value;
    const roleName = document.getElementById('role').value;
    const LOB = document.getElementById('lob').value;

    fetch(`http://localhost:5000/api/roles/addrole`, {
        method: 'Post',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            id: roleId,
            name: roleName,
            lob: LOB
        })
    })
    .then(response => response.json())
    .then(data => {
        console.log('Success:', data);
        alert('Role added successfully!');
    })
    .catch((error) => {
        console.error('Error:', error);
        alert('Failed to update user.');
    });
});