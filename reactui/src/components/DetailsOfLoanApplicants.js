import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { Button } from 'react-bootstrap'
import axios from "axios";

function DetailsOfLoanApplicants() {
    const params = useParams();
    const { id } = params;
    const [emiAmount,setEmiAmount]=useState(0);
    console.log(id);


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
        setEmiAmount(emiamount);
        console.log("EMI =", emiAmount);

        // displayData(data, emiamount);

        // var sanctionedate = new Date();
        // var formatdate = sanctionedate.toISOString().slice(0, 10);
        // //var emiday= 10;
        // var acctId = data.applicationId;
    }

    const UpdateStatus =(e)=>{
        window.confirm("Are You "+{e}+"Status..");
        console.log(e);
        Data.loanStatus=e;
        axios
            .put(url,Data)
            .then((res) => {
                console.log(res);
                            })
            .catch((err) => {
                console.log(err);
            });

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
            <Button variant="success" id="btnapprove" value="approved" onClick={(e)=>UpdateStatus(e.target.value)}>Approve Loan  </Button>
            <Button variant="danger" id="btnreject" value="rejected" onClick={(e)=>UpdateStatus(e.target.value)}>Reject Loan  </Button>
           
        </div>
    )
}
export default DetailsOfLoanApplicants;