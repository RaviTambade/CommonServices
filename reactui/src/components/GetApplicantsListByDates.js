import React, { useState, useEffect } from "react"
import { Button, Table } from 'react-bootstrap';
import axios from "axios";

function GetApplicantsListByDate() {
    const [FromDate, setFromdate] = useState('')
    const [ToDate, setTodate] = useState('')
    const [data, setData] = useState([]);


    const handlefromdates = (values) => {
        setFromdate(values)
        
    }
    const handletodates = (values) => {
        
        setTodate(values)
    }
    const handleSubmit = (event) => {
        console.log(FromDate, ToDate);
        event.preventDefault();

        const url = "http://localhost:5053/api/application" + "/" + FromDate + "/" + ToDate;
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
    // const fetchInfo = () => {

    //     axios
    //         .get(url)
    //         .then((res) => {
    //             console.log(res);
    //             setData(res.data);
    //         })
    //         .catch((err) => {
    //             console.log(err);
    //         });

   // };

    // useEffect(() => {
    //     fetchInfo();
    // }, []);

    return (
        <>
            <form onSubmit={handleSubmit}>
                <h1>Applicant List According to dates </h1>

                <label>From Date : </label>
                <input type="date" id="fromdate" name="fromdate" placeholder="Enter Starting Date" onChange={(e) => handlefromdates(e.target.value)} /><br /><br />

                <label>To Date : </label>
                <input type="date" id="startdate" name="startdate" placeholder="Enter Starting Date" onChange={(e) => handletodates(e.target.value)} /><br /><br />

                <Button type="submit" variant="primary">Submit</Button>{' '}

            </form>
            <Table striped bordered hover >
                <thead>
                    <tr>
                        <th>Sr No.</th>
                        <th>AccountId</th>
                        <th>Applicant Name</th>
                        <th>Application Date</th>
                        <th>Loan Type</th>
                        <th>Loan Duration</th>
                        <th>Loan Amount</th>
                        <th>Loan Status</th>
                    </tr>
                </thead>
                {data.map((applications,i) => (

                    <tbody key={applications.applicationId}>

                        <tr >
                            <td>{i+1}</td>
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


            
        </>


    )
}
export default GetApplicantsListByDate