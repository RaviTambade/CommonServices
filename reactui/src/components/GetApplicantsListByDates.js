import React, { useState, useEffect } from "react"
import {Button,Table} from 'react-bootstrap';
import axios from "axios";

function GetApplicantsListByDate() {
    const [FromDate, setFromdate] = useState('')
    const [ToDate, setTodate] = useState('')

    const handledates=(values) =>{
        setFromdate(values.FromDate)
        setTodate(values.ToDate)
    }
    const handleSubmit = (event) => {
        console.log(FromDate, ToDate);
        event.preventDefault();
        
    }

    const url = "http://localhost:5053/api/application" +"/" + FromDate + "/" + ToDate;
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
        <>
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
                {data.map((applications) => (

                    <tbody key={applications.applicationId}>

                        <tr >
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


            <form onSubmit={handleSubmit}>
                <h1>Applicant List According to dates </h1>

                <label>From Date : </label>
                <input type="date" id="fromdate" name="fromdate" placeholder="Enter Starting Date" onChange={(e) => handledates(e.target.value)} /><br /><br />

                <label>To Date : </label>
                <input type="date" id="startdate" name="startdate" placeholder="Enter Starting Date" onChange={(e) => handledates(e.target.value)} /><br /><br />

                <Button type="submit" variant="primary">Submit</Button>{' '}


            </form>
        </>


    )
}
export default GetApplicantsListByDate