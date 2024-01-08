import React, { useState, useEffect,useNavigate } from "react";
import axios from "axios";
import Table from 'react-bootstrap/Table';


function LoanApplicantsList() {
    const navigate = useNavigate();

     const navigateToDetails = () => {
        // 👇️ navigate to /Details
         navigate('/details');
       };

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
                        <th>Loan Status</th>
                        <th></th>
                    </tr>
                </thead>
                {data.map((applications, index) => (

                    <tbody key={applications.applicationId}>

                        <tr >
                            <td>{index+1}</td>
                            <td>{applications.accountId}</td>
                            <td>{applications.applicantName}</td>
                            <td>{applications.loanStatus}</td>
                            <td><button onClick={navigateToDetails}>Details</button></td> 
                        </tr>
                        <Routes>
                        <Route key={applications.applicantId} path="/details" element={<GetApplicantDetails />} />
                        
                        </Routes>
                    </tbody>
                ))}
            </Table>
        </div>
    );
}
export default LoanApplicantsList;