

 function displayData(details)
    {
        var htmlContent = '<div class="table-responsive"> <table id="loanapplicantsTable" class="table table-striped"> <thead> <tr>' +
                                    '<th>AccountId</th><th>Application Date</th><th>Loan Type</th><th>Loan Duration<th>Loan Amount</th><th>Loan Status</th><th>Applicant Name</th><th>Applicant Type</th></tr></thead><body>';
                                
                                    htmlContent += '<tr>';
                                    htmlContent +='<td>'+details.accountId + '</td>';
                                    htmlContent += '<td>'+details.applyDate + '</td>';
                                    htmlContent += '<td>'+details.panId + '</td>';
                                    htmlContent += '<td>'+details.loanType + '</td>';
                                    htmlContent += '<td>'+details.amount + '</td>';
                                    htmlContent += '<td>'+details.status + '</td>';
                                    htmlContent += '<td>'+details.applicantName + '</td>';
                                    htmlContent += '<td>'+details.applicantType + '</td>';

                                   
                                    htmlContent += '<td>' + "  " + '<button onclick = "checkstatus(status1,responsedata)" id="btnapproved" class="btn btn-success">Approved</button>' + "  "+ '<button  onclick = "checkstatus(status2,responsedata)" id="btnrejected" class="btn btn-danger">Rejected</button>' + '</td>';
                                    htmlContent += '</tr>';

                                htmlContent += '</tbody></table></div>';
                                $('#dataDisplay').html(htmlContent);
             

    };


