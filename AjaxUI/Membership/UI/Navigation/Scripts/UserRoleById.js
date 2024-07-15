var userLOB = sessionStorage.getItem("lob");
console.log("LOB of logged User : "+userLOB);

document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("btngetroles").addEventListener("click", function () {
        var rolesContainer = document.getElementById("roles");
        rolesContainer.innerHTML = '';

        fetch(`http://localhost:5000/api/roles/getUserAndRoles/lob/` + userLOB)
            .then(response => response.json())
            .then(data => {
                if (data.length > 0) {

                    console.log(data);
                     /* data.forEach(function (role) {
                       var roleElement = document.createElement("div");
                        roleElement.className = "p-4 bg-gray-100 border border-gray-300 rounded";
                        roleElement.textContent = `Role: ${role.name} | LOB: ${role.lob}`;
                        rolesContainer.appendChild(roleElement); */
                        var tableHtml = "<table><thead><tr><th>Name</th><th>Role</th></tr></thead><tbody>";

                    data.forEach(item => {
                        tableHtml += "<tr><td>" + item.firstName+" "+item.lastName + "</td><td>" + item.roleName + "</td></tr>";
                    });

                    tableHtml += "</tbody></table>";
                    rolesContainer.innerHTML = tableHtml;
                   // });
                } else {
                    rolesContainer.textContent = "No Roles Found";
                }
            })
            .catch(error => {
                console.error(error);
            });
    });
});