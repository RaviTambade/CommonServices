$(document).ready(function () {

    $.ajax({
        url: `http://localhost:5000/api/roles/lobs`,
        type: 'GET',
        contentType: 'application/json',
        success: function (data) {
                $("#ddlob").empty().append('<option value="">Select LOB</option>');
                data.forEach(function (data) {
                    var option = $('<option></option>').attr("value", data).text(data);
                    $("#ddlob").append(option);
                });
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
                alert("An error occurred while fetching the LOBs. Please try again.");
            }

    })
    $("#showRolesButton").click(function () {
        var selectedLob = $("#ddlob").val();
        if (selectedLob) {
            $.ajax({
                url: `http://localhost:5000/api/roles/lob/${selectedLob}`,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    var rolesTableBody = $("#rolesTable tbody");
                    rolesTableBody.empty();

                    if (data.length > 0) {
                        data.forEach(function (role) {
                            var row = `<tr>
                                <td class="border border-gray-300 p-2">${role.name}</td>
                                <td class="border border-gray-300 p-2">${role.lob}</td>
                            </tr>`;
                            rolesTableBody.append(row);
                        });
                    } else {
                        rolesTableBody.append('<tr><td class="border border-gray-300 p-2" colspan="2">No Roles Found</td></tr>');
                    }
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                }
            });
        } else {
            alert("Please select a LOB.");
        }
    });
});