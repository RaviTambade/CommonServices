var userLOB = sessionStorage.getItem("lob");
console.log("LOB of logged User : " + userLOB);

function redirectToupdate(info){
                     
     console.log("Type of info : "+ info);
     var ID = info.id;
    alert("Hello" + ID);
    
   // var fullName = info.firstName + " " +info.lastName;
    //alert(fullName);
    //localStorage.setItem("selectedId",ID);
    //localStorage.setItem("fullname",fullName);
    window.location.href = '../Navigation/UserRoleManagment.html';
};

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
                        radiobox.value = item.name;
                        var label = document.createElement('label')
                        label.htmlFor = 'num';
                        var description = document.createTextNode(item.name);
                        label.appendChild(description);
                        rolesContainer.appendChild(radiobox);
                        rolesContainer.appendChild(label);
                    });
                    var radioButtons = document.querySelectorAll('input[type="radio"]');
                    radioButtons.forEach(function (radio) {
                        radio.addEventListener('click', function () {
                            if (this.checked) {
                                var selectedOption = this.value;
                                console.log("Selected Option: " + selectedOption);
                                console.log("Selected LOB: " + userLOB);
                                $.ajax({
                                    url: `http://localhost:5000/api/roles/getuserbyroles/rolename/${selectedOption}/lob/${userLOB}`,
                                    type: 'GET',
                                    contentType: 'application/json',
                                    success: function (data) {
                                        var htmlContent = '<div class="overflow-x-auto"><table id="userByRoleTable" class="min-w-full divide-y divide-gray-200"><thead class="bg-gray-50"><tr>' +
                                            '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Id</th>' +
                                            '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Image</th>' +
                                            '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">First Name</th>' +
                                            '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider">Last Name</th>' +
                                            '<th scope="col" class="px-6 py-3 text-left text-xs font-medium text-gray-500 uppercase tracking-wider"></th>' +
                                            
                                            '</tr></thead><tbody class="bg-white divide-y divide-gray-200">';

                                        $.each(data, function (index, item) {
                                            //var stringifiedObj  = JSON.stringify(item);
                                            console.log(item);
                                            console.log("Item Length  =  "+data.length);
                                            console.log("Index " + index);
                                            var array = item;
                                            for(i=0;i<data.length;i++)
                                            {
                                                console.log("Array = " + array[i]);
                                            }
                                           
                                           
                                            htmlContent += '<tr>' +
                                                '<td class="px-6 py-4 whitespace-nowrap">' + item.id + '</td>' +
                                                '<td class="px-6 py-4 whitespace-nowrap">' + item.imageUrl + '</td>' +
                                                '<td class="px-6 py-4 whitespace-nowrap">' + item.firstName + '</td>' +
                                                '<td class="px-6 py-4 whitespace-nowrap">' + item.lastName + '</td>' +
                                                '<td>'+'<button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" id="updaterole"  onclick="redirectToupdate('+ item[index]+ ')"> Update Role </button>'+ '</td>'  //'+JSON.stringify(item)+'
                                                '</tr>';
                                               
                                               
                                        });
                                        htmlContent += '</tbody></table></div>';
                                        $('#dataDisplay').html(htmlContent);
                                        
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