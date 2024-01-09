import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import {Table} from 'react-bootstrap'
import axios from "axios";

function GetApplicantDetails() {
    const params = useParams();
    const {id} = params;
    console.log(id);


    const url = "http://localhost:5053/api/application" + "/" + id;
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
            <h1>Loan Applicant Detials</h1>
            <Table striped bordered hover >
                <thead>
                    <tr>
                        <th>AccountId</th>
                        <th>Applicant Name</th>
                        <th>Application Date</th>
                        <th>Loan Type</th>
                        <th>Loan Duration</th>
                        <th>Loan Amount</th>
                        <th>Loan Status</th>
                    </tr>
                </thead>

                <tbody>
                    <tr >
                        <td>{data.accountId}</td>
                        <td>{data.applicantName}</td>
                        <td>{data.applicationDate}</td>
                        <td>{data.loanTypeName}</td>
                        <td>{data.loanDuration}</td>
                        <td>{data.loanAmount}</td>
                        <td>{data.loanStatus}</td>
                    </tr>
                </tbody>
            </Table>
        </div>
    )
}
export default GetApplicantDetails;