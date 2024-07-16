var userLOB = sessionStorage.getItem("lob");
console.log("LOB of logged User : " + userLOB);

document.addEventListener("DOMContentLoaded", function () {
    document.getElementById("btngetroles").addEventListener("click", function () {
        var rolesContainer = document.getElementById("roles");
        rolesContainer.innerHTML = '';

        fetch(`http://localhost:5000/api/roles/lob/` + userLOB)
            .then(response => response.json())
            .then(data => {
                if (data.length > 0) {
                    console.log(data);
                    data.forEach(item => {
                        console.log(item.name);
                        var radiobox = document.createElement('input');
                        radiobox.type = 'radio';
                        radiobox.id = 'num';
                        radiobox.name = "options";
                        radiobox.value = item.id;
                        var label = document.createElement('label')
                        label.htmlFor = 'num';
                        var description = document.createTextNode(item.name);
                        label.appendChild(description);
                        rolesContainer.appendChild(radiobox);
                        rolesContainer.appendChild(label);
                    });
                    // var radioButtons = document.querySelectorAll('input[type="radio"]');
                    radioButtons.forEach(function (radio) {
                        radio.addEventListener('click', function () {
                            if (this.checked) {
                                var selectedOption = this.value;
                                console.log("Selected Option: " + selectedOption);
                                console.log("Selected LOB"+ userLOB);
                                $.ajax({
                                    url: `http://localhost:5000/api/roles/getuserbyroles/rolename/${selectedOption}/lob/${userLOB}`,
                                    type: 'GET',
                                    contentType: 'application/json',
                                    success: function (data) {
                                        console.log(data);

                                        // const roles = $("#roles").empty();
                                       // data.forEach(role => roles.append($('<div></div>').text(role.name)));
                                    },
                                    error: function (xhr, status, error) {
                                        console.error(xhr.responseText);
                                        alert("An error occurred while fetching the roles. Please try again.");
                                    }
                                });
                            }
                        });
                    });
                }
                else {
                    rolesContainer.textContent = "No Roles Found";
                }
            })
            .catch(error => {
                console.error(error);
            });
    });
});