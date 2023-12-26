

 function displayData(details)
    {
        console.log(details);
        var htmlContent = '<div class="table-responsive"> <table id="loanapplicantsTable" class="table table-striped"> <thead> <tr>' +
                            '<th>AccountId</th><th>Applicant Name</th><th padding-left:10px>Application Date</th><th>Loan Amount</th><th>Loan Duration</th><th>Loan Type</th><th>Loan Status</th><th>Your Monthly EMI</th></tr></thead><body>';
                            
                                    htmlContent += '<tr>';
                                    htmlContent +='<td>'+details.accountId + '</td>';
                                    htmlContent +='<td>'+details.applicantName + '</td>';
                                    htmlContent += '<td>'+details.applicationDate + '</td>';
                                    htmlContent += '<td>'+details.loanAmount + '</td>';
                                    htmlContent += '<td>'+details.loanDuration + '</td>';                                                                      
                                    htmlContent += '<td >'+details.loanTypeName  + '</td>';                                       
                                    htmlContent += '<td>'+details.loanStatus + '</td>';

                                    htmlContent += '<td>' + "  " + '<button onclick = "GetEMI(responsedata)" id="btngetemi" class="btn btn-success">Get EMI </button> ' ;
                                    htmlContent += '</td>';
                                    htmlContent += '<td>' + "  " + '<button onclick = "checkstatus(status1,responsedata)" id="btnapproved" class="btn btn-success">Approve </button>' + "    "+ '<button  onclick = "checkstatus(status2,responsedata)" id="btnrejected" class="btn btn-danger">Reject</button>' + '</td>';
                                    htmlContent += '</tr>';
                            
                                htmlContent += '</tbody></table></div>';
                                $('#dataDisplay').html(htmlContent);
             

    };


