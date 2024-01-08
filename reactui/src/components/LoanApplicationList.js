import React, { useState, useEffect } from "react";
import axios from "axios";
import Table from 'react-bootstrap/Table';


function LoanApplicantsList() {
    const url = "http://localhost:5053/api/application/applicationAscustomer";
    const [data, setData] = useState([]);

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
    useEffect(() => {
        fetchInfo();
    }, []);

    return (
        <div>
            <h1>Loan Applicnts List</h1>

            <Table striped bordered hover >
                <thead>
                    <tr>
                        <th>Sr.No</th>
                        <th>AccountId</th>
                        <th>Applicant Name</th>
                        <th>Application Date</th>
                        <th>Loan Type</th>
                        <th>Loan Duration</th>
                        <th>Loan Amount</th>
                        <th>Loan Status</th>
                    </tr>
                </thead>
                {data.map((applications, index) => (

                    <tbody key={applications.applicationId}>

                        <tr >
                            <td>{index+1}</td>
                            <td>{applications.accountId}</td>
                            <td>{applications.applicantName}</td>
                            <td>{applications.applicationDate}</td>
                            <td>{applications.loanTypeName}</td>
                            <td>{applications.loanDuration}</td>
                            <td>{applications.loanAmount}</td>
                            <td>{applications.loanStatus}</td>
                        </tr>
                    </tbody>
                ))}
            </Table>
        </div>
    );
}
export default LoanApplicantsList;