var userLOB = sessionStorage.getItem("lob");
console.log("LOB of logged User : " + userLOB);

function redirectToupdate(element) {

    console.log("Element : " + element);
    alert(element);
    localStorage.setItem("ID", element);
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
                                            console.log("Item Length  =  " + data.length);
                                            console.log("Index " + index);

                                            htmlContent += '<tr>' +
                                                '<td class="px-6 py-4 whitespace-nowrap" name="id">' + item.id + '</td>' +
                                                '<td class="px-6 py-4 whitespace-nowrap">' + item.imageUrl + '</td>' +
                                                '<td class="px-6 py-4 whitespace-nowrap" name="firstName">' + item.firstName + '</td>' +
                                                '<td class="px-6 py-4 whitespace-nowrap" name="lastName">' + item.lastName + '</td>' +
                                                '<td>' + '<button class="bg-blue-500 hover:bg-blue-700 text-white font-bold py-2 px-4 rounded focus:outline-none focus:shadow-outline" id="updaterole"  > Update Role </button>' + '</td>'  //onclick="redirectToupdate('+ item[index]+ ')"
                                            '</tr>';


                                        });
                                        htmlContent += '</tbody></table></div>';
                                        $('#dataDisplay').html(htmlContent);

                                        $(document).on("click", "#updaterole", function () {

                                            var $row = $(this).closest("tr"),       // Finds the closest row <tr> 
                                                $tds = $row.find("td");             // Finds all children <td> elements


                                           /* var table = document.getElementById('userByRoleTable'),
                                                rows = table.getElementsByTagName('tr'),
                                                i, j, cells, customerId;

                                            for (i = 0, j = rows.length; i < j; ++i) {
                                                cells = rows[i].getElementsByTagName('td');
                                                if (!cells.length) {
                                                    continue;
                                                }
                                                Id = cells[0].innerHTML;
                                                console.log("ID : "+ Id);
                                            }*/




                                             $.each($tds, function () { 
                                                 //var retrived_data = $(this).text();
                                                 //console.log(retrived_data);                             // Visits every single <td> element
                                                 //console.log($(this).text());        // Prints out the text within the <td>
                                                
                                                var element = $(this).text().split(" ");

                                                console.log(element);
                                                //redirectToupdate(element)
                                               localStorage.setItem("selectedId",element);
                                                window.location.href = '../Navigation/UserRoleManagment.html';
                                                 alert(element);
                                             });


                                            /*let $row = $(this).closest('tr');
                                            let $tds = $row.find('td');

                                            $.each($tds,function(){

                                                //let a = $tds.find('input[name="id"]').text();
                                                //let a = $tds.text();
                                                //let a = $tds.find('.name').val();
                                                let a = $(this).find('.name').text();
                                                console.log("a = " + a);
                                                //let b = $tds.find('input[name="firstname"]').text();
                                                //let b = $tds.find('[name = " id"]').val();
                                                //let b = $row.find('td').find('.name').val();
                                                let b = $(this).find('.name').val()
                                                console.log("b = " + b);
                                                alert('Output : ' + a + ' ' + b);

                                             })*/

                                        });


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