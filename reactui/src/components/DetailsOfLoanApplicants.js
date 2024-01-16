import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { Button } from 'react-bootstrap'
import axios from "axios";
import { useNavigate } from 'react-router-dom';

//import addNotification from "react-push-notification";

import { NotificationManager } from "react-notifications";

function DetailsOfLoanApplicants() {

    const params = useParams();
    const { id } = params;
    console.log(id);

    const navigation = useNavigate()


    const url = "http://localhost:5053/api/application" + "/" + id;
    const [Data, setData] = useState({});

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
        fetchInfo();
        fetchInfo2();
    }, []);

    const EmiCalculation = () => {
        var loatypeid = Data.loanTypeId;
        var irate = loantypes.find((loantype) => loantype.loanTypeId == loatypeid).intrestRate
        var durtioninmonths = Data.loanDuration * 12;
        const interest = (Data.loanAmount * (irate * 0.01)) / durtioninmonths;
        var emiamount = ((Data.loanAmount / durtioninmonths) + irate).toFixed(2);

        return emiamount;

    }

    const UpdateStatus = (e) => {

        console.log(e);
        Data.loanStatus = e;
        axios
            .put(url, Data)
            .then((res) => {
                console.log(res);

                if (e === "approved") {

                    //approveNotification(e);
                    InsertLoanRecord();  
                }
                /*else
                {
                    rejectNotification(e);
                }*/
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
        let applicationID = Data.applicationId;

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

    /*function rejectNotification(type) {
        console.log(type);
        addNotification({
            title: "Rejected",
            subtitle: "Try next time",
            message: "Your oan is rejected....",
            theme: "red",
            closeButton: "X",
            duration:3000
        });
    }
 
    function approveNotification(type) {
        console.log(type);
        addNotification({
            title: "Success",
            subtitle: "Congrtutions!!!!",
            message: "Loan is approved.",
            theme: "light",
            closeButton: "X",
            backgroundTop: "green",
            backgroundBottom: "yellowgreen",
            duration:2000
        });
    }*/
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
                        <td>: {Data.accountId}</td>
                    </tr>
                    <tr>
                        <td>Applicant Name </td>
                        <td><th>: {Data.applicantName}</th> </td>
                    </tr>
                    <tr>
                        <td>Application Date  </td>
                        <td>: {Data.applicationDate}</td>
                    </tr>
                    <tr>
                        <td>Loan Type   </td>
                        <td>: {Data.loanTypeName}</td>
                    </tr>
                    <tr>
                        <td>Loan Duration  </td>
                        <td>: {Data.loanDuration} Years</td>
                    </tr>
                    <tr>
                        <td>Loan Amount  </td>
                        <td>: Rs {Data.loanAmount}</td>
                    </tr>
                    <tr>
                        <td>Loan Status  </td>
                        <td>: {Data.loanStatus}</td>
                    </tr>
                </tbody>
            </table>
            <br />
            {Data.loanStatus == "applied" ?
                <div>
                    <Button variant="success" id="btnapprove" value="approved" onClick={(e) => UpdateStatus(e.target.value)}>Approve Loan  </Button>
                    <Button variant="danger" id="btnreject" value="rejected" onClick={(e) => UpdateStatus(e.target.value)}>Reject Loan  </Button>
                </div>
            : null}

        </div>
    )
}
export default DetailsOfLoanApplicants;