$(document).ready(function() {
    $('#getUserdetailsByUserIds').on('click', function() {
      getUserdetailsByUsersIds();
    });
  });
  
  function getUserdetailsByUsersIds() {
    var UserIds = $('#userids').val();
    $.ajax({
      url: 'http://localhost:5000/api/users/details/ids/' + UserIds,
      type: 'GET',
      contentType: 'application/json',
      success: function(response) {
        var htmlContent = '<div class="overflow-x-auto"><table class="min-w-full bg-white"><thead><tr>' +
          '<th class="py-2">Id</th><th class="py-2">ImageUrl</th><th class="py-2">Full Name</th></tr></thead><tbody>';
        $.each(response, function(index, item) {
          htmlContent += '<tr>';
          htmlContent += '<td class="border px-4 py-2">' + item.id + '</td>';
          htmlContent += '<td class="border px-4 py-2">' + item.imageUrl + '</td>';
          htmlContent += '<td class="border px-4 py-2">' + item.fullName + '</td>';
          htmlContent += '</tr>';
        });
        htmlContent += '</tbody></table></div>';
        $('#dataDisplay').html(htmlContent);
      },
      error: function(xhr, status, error) {
        console.error('Error:', status + ': ' + error);
      }
    });
  }
  