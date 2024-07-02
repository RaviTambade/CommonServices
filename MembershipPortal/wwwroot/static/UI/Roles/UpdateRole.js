document.getElementById('updateRoleForm').addEventListener('submit', function(event) {
    event.preventDefault();

    const roleId = document.getElementById('Id').value;
    const roleName = document.getElementById('roleTitle').value;
    const LOB = document.getElementById('lob').value;

    fetch(`http://localhost:5000/api/roles`, {
        method: 'PUT',
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
        alert('User updated successfully!');
    })
    .catch((error) => {
        console.error('Error:', error);
        alert('Failed to update user.');
    });
});