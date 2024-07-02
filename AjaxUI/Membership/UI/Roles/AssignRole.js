$(document).ready(function () {
    var userId = null;
    $("#btngetlobs").click(function () {
        userId = $("#userid").val();
        if (userId) {
            $.ajax({
                url: `http://localhost:5000/api/roles/${userId}`,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    $("#ddlob").empty().append('<option value="">Select LOB</option>');
                    const lobSet = new Set();
                    data.forEach(function (lob) {
                        if (!lobSet.has(lob.lob)) {
                            lobSet.add(lob.lob);
                        var option = $('<option></option>').attr("value", lob.lob).text(lob.lob);
                        $("#ddlob").append(option);
                        }
                    });
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                    alert("An error occurred while fetching the LOBs. Please try again.");
                }
            });
        } else {
            alert("Please enter a valid user ID.");
        }
    });

    $("#ddlob").change(function () {
        var lob = $(this).val();
        if (userId && lob) {
            $.ajax({
                url: `http://localhost:5000/api/roles/users/${userId}/lob/${lob}`,
                type: 'GET',
                contentType: 'application/json',
                success: function (data) {
                    const roles = $("#roles").empty();
                    data.forEach(role => roles.append($('<div></div>').text(role.name)));
                },
                error: function (xhr, status, error) {
                    console.error(xhr.responseText);
                    alert("An error occurred while fetching the roles. Please try again.");
                }
            });
        } else {
            $("#roles").empty();
        }
    });
});