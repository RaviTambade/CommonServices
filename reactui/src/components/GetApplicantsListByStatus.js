import React, { useState } from "react"
import { Button, Table } from 'react-bootstrap';
import axios from "axios";
import {Link} from 'react-router-dom';

function GetApplicantsListByStatus() {
    const [Status, setStatus] = useState('');
    const [data, setData] = useState([]);


    const handlestatus = (values) => {
        setStatus(values)

    }
   
    const handleSubmit = (event) => {
        console.log(Status);
        event.preventDefault();

        const url = "http://localhost:5053/api/application/status" + "/" + Status;

        axios
            .get(url)
            .then((res) => {
                console.log(res);
                setData(res.data);
            })
            .catch((err) => {
                console.log(err);
            });
    }
   
    return (
        <>
            <form onSubmit={handleSubmit}>
                <h1>Applicant List According to Loan Status </h1>

                <label>Select Loan Status: </label>
                <select id="loanstatus" name="loanstatus" onChange={(e) => handlestatus(e.target.value)}>
                    <option>Select Loan Status</option>
                    <option value="applied">Applied</option>
                    <option value="approved">Approved</option>
                    <option value="rejected">Rejected</option>

                </select>
               <br/>
                <Button type="submit" variant="primary">Submit</Button>

            </form>
            <br/>
            <Table striped bordered hover size="sm">
                <thead>
                    <tr>
                        <th>Sr No.</th>
                        <th>AccountId</th>
                        <th>Applicant Name</th>
                        <th>Loan Status</th>
                        <th></th>
                    </tr>
                </thead>
                {data.map((applications, i) => (

                    <tbody key={applications.applicationId}>

                        <tr >
                            <td>{i + 1}</td>
                            <td>{applications.accountId}</td>
                            <td>{applications.applicantName}</td>
                            <td>{applications.loanStatus}</td>
                            <td><Link to={`/details/${applications.applicationId}`}>details</Link></td>
                        </tr>
                    </tbody>
                ))}
            </Table>
        </>
    )
}
export default GetApplicantsListByStatus