function populateItems(items) {
    var tbody = $('#itemsTable tbody');
    tbody.empty(); // Clear existing items
    $.each(items, function(index, item) {
        var row = '<tr class="bg-white border-b dark:bg-gray-800 dark:border-gray-700" >' +
                    '<td>' + item.id + '</td>' +
                    '<td>' + item.name + '</td>' +
                    '<td>' + item.lob + '</td>' +
                  '</tr>';
        tbody.append(row);
    });
}


$(document).ready(function () {
    console.log("Document.Ready");
    $("#btngetroles").click(function () {
        $.ajax({
            url: "http://localhost:5000/api/roles",
            type: 'GET',
            contentType: 'application/json',
            success: function (data) {
                populateItems(data);
            },
            error: function (xhr, status, error) {
                console.error(xhr.responseText);
            }
        });
    });
});