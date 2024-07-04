document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("btndeleteuser").addEventListener("click", function () {
        var userId = document.getElementById("txtUserId").value;

        fetch('http://localhost:5000/api/users/' + userId, {
            method: 'DELETE',
            headers: {
                'Content-Type': 'application/json'
            }
        })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {

                alert("User Deleted Successfully");
                console.log('User deleted successfully:', data);

            })
            .catch(error => {

                console.error('Error:', error);
            });
    });
});