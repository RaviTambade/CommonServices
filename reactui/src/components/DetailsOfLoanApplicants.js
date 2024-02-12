import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { Button } from 'react-bootstrap'
import axios from "axios";
import { useNavigate } from 'react-router-dom';

import { NotificationManager } from "react-notifications";

function DetailsOfLoanApplicants() {

    let params = useParams();
    let { id } = params;
    console.log("****" +id);

    const navigation = useNavigate()


    const url = "http://localhost:5053/api/loanppications/"  + id;
    
    const [Data, setData] = useState({theApplication:{},theApplicant:{}});// Wrongway to set the data in this way :useState({})


    const url2 = "http://localhost:5053/api/loanstypes";
     const [loantypes, setLoantypes] = useState([]);
     
    const fetchInfo = () => {

        axios
            .get(url)
            .then((res) => {
                console.log(res);
                setData(res.data);
            })
            .catch((err) => {
                console.log(err);
            });

    };

    const fetchInfo2 = () => {
        axios
            .get(url2)
            .then((res) => {
                console.log(res);
                setLoantypes(res.data);
            })
            .catch((err) => {
                console.log(err);
            });

    };

    useEffect(() => {
        console.log("try effect");
        fetchInfo();
        fetchInfo2();
      }, []);
    
   

    const EmiCalculation = () => {
        var loatypeid = Data.theApplication.loanTypeId;
        var irate = loantypes.find((loantype) => loantype.loanTypeId == loatypeid).intrestRate
        var durtioninmonths = Data.theApplication.loanDuration * 12;
        const interest = (Data.theApplication.loanAmount * (irate * 0.01)) / durtioninmonths;
        var emiamount = ((Data.theApplication.loanAmount / durtioninmonths) + irate).toFixed(2);

        return emiamount;
    
    };

    const UpdateStatus = (e) => {

        console.log(e);
        Data.theApplication.loanStatus = e;
        
        var obj = {
        applicationId : Data.theApplication.applicationId,
        applicationDate : Data.theApplication.applicationDate,
        loanAmount : Data.theApplication.loanAmount,
        loanDuration : Data.theApplication.loanDuration,
        loanStatus :  e,    
        accountId : Data.theApplication.accountId,
        loanTypeId : Data.theApplication.loanTypeId
        }
        console.log(Data);
        axios
            .put(url, obj)
            .then((res) => {
                console.log(res);

                if (e === "approved") {     
                    InsertLoanRecord();  
                }
                
                createNotification(e);
            
                var btnApprove=document.getElementById("btnapprove");
                var btnReject=document.getElementById("btnreject");
                btnApprove.remove();
                btnReject.remove(); 
                navigation("/loanapplicationslist");          
            })
            .catch((err) => {
                console.log(err);
            });
    };


    const InsertLoanRecord = () => {
        
        let sanctionedate = new Date();
        let formatdate = sanctionedate.toISOString().slice(0, 10);
        let applicationID = Data.theApplication.applicationId;

        var emiAmount = EmiCalculation();

        const loanData = {
            "loanSanctionDate": formatdate,
            "eMIAmount": emiAmount,
            "applicationId": applicationID
        };

        console.log("loanData = ", loanData);

        let url = 'http://localhost:5053/api/loans'

        axios
            .post(url, loanData)
            .then((res) => {
                console.log(res);
            })
            .catch((err) => {
                console.log(err);
            });
    };

   
    const createNotification = (type) => {

        switch (type) {
            case 'approved':
             
              NotificationManager.success('Loan is approved successfuly. Congratulations!!!!','Approve',2000);
              break;
            case 'rejected':
              NotificationManager.error('Sorry.. Loan is rejected.You can try next time.', 'Reject',2000);
              break;
            case 'warning':
              NotificationManager.warning('Warning message', 'Close after 3000ms', 3000);
              break;
            case 'error':
              NotificationManager.error('Error message', 'Click me!', 5000, () => {
                alert('callback');
              });
              break;
          }

    };

    return (
        <div>
            <h1>Loan Applicant Detials</h1>
            <table>
                <tbody>
                    <tr>
                        <td>AccountId  </td>
                        <td>: {Data.theApplication.accountId}</td>   
                    </tr>
                    <tr>
                        <td>Applicant Name </td>
                        <td>: {Data.theApplicant.applicantName} </td>
                    </tr>
                    <tr>
                        <td>Application Date  </td>
                        <td>: {Data.theApplication.applicationDate}</td>
                    </tr>
                    <tr>
                        <td>Loan Type   </td>
                        <td>: {Data.theApplicant.loanTypeName}</td>
                    </tr>
                    <tr>
                        <td>Loan Duration  </td>
                        <td>: {Data.theApplication.loanDuration} Years</td>
                    </tr>
                    <tr>
                        <td>Loan Amount  </td>
                        <td>: Rs {Data.theApplication.loanAmount}</td>
                    </tr>
                    <tr>
                        <td>Loan Status  </td>
                        <td>: {Data.theApplication.loanStatus}</td>
                    </tr>
                </tbody>
            </table>
            <br />
            {Data.theApplication.loanStatus == "applied" ?
                <div>
                    <Button variant="success" id="btnapprove" value="approved" onClick={(e) => UpdateStatus(e.target.value)}>Approve Loan  </Button>
                    <Button variant="danger" id="btnreject" value="rejected" onClick={(e) => UpdateStatus(e.target.value)}>Reject Loan  </Button>
                </div>
            : null}

        </div>
    )
}
export default DetailsOfLoanApplicants;