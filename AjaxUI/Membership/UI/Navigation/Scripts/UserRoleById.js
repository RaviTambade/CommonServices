var userId = parseInt(sessionStorage.getItem("userid"));
console.log(userId);
document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("btngetroles").addEventListener("click", function () {
        var rolesContainer = document.getElementById("roles");
        rolesContainer.innerHTML = '';

        fetch(`http://localhost:5000/api/roles/` + userId)
            .then(response => response.json())
            .then(data => {
                if (data.length > 0) {
                    data.forEach(function (role) {
                        var roleElement = document.createElement("div");
                        roleElement.className = "p-4 bg-gray-100 border border-gray-300 rounded";
                        roleElement.textContent = `ID: ${role.id}, Name: ${role.name}, LOB: ${role.lob}`;
                        rolesContainer.appendChild(roleElement);
                    });
                } else {
                    rolesContainer.textContent = "No Roles Found";
                }
            })
            .catch(error => {
                console.error(error);
            });
    });
});