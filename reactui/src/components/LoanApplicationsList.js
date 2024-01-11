import React, { useState,useEffect } from "react"
import { Button, Table } from 'react-bootstrap';
import axios from "axios";
import { Link } from 'react-router-dom';

function LoanApplicationsList() {
    
    var [Status,setStatus]=useState([]);   
   
    const url = "http://localhost:5053/api/application/applicationAscustomer";
    const [data, setData] = useState([]); 
    
   
    const handleChange=(e)=>{
        //setAppliedStatus(value)
        console.log(e.target.value)
        
        if (e.target.checked) {
            // setAllChecked([...allchecked, e.target.value]);
            setStatus(data.filter((items)=>items.loanStatus==e.target.value));
                       
        } else {
            // setAllChecked(allchecked.filter((item) => item !== e.target.value));
            setStatus(data.filter((item) => item !== e.target.value))          
        }      
    }

    const fetchInfo = () => {
        axios
            .get(url)
            .then((res) => {
                console.log(res);
                setData(res.data);
                setStatus(res.data);
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
            <input value="applied" type="checkbox" onChange={handleChange} />
            <span>Applied</span>
            <input value="approved" type="checkbox" onChange={handleChange} />
            <span>Approved</span>
            <input value="rejected" type="checkbox" onChange={handleChange} />
            <span>Rejected</span>
            <Table striped bordered hover  >
                <thead>
                    <tr>
                        <th>Sr.No</th>
                        <th>AccountId</th>
                        <th>Applicant Name</th>
                        <th>Loan Status</th>
                        <th></th>
                    </tr>
                </thead>
                {Status.map((applications, index) => (

                    <tbody key={applications.applicationId}>

                        <tr >
                            <td>{index + 1}</td>
                            <td>{applications.accountId}</td>
                            <td>{applications.applicantName}</td>
                            <td>{applications.loanStatus}</td>                           
                            <td><Link to={`/detailsfromlist/${applications.applicationId}`}>Details</Link></td>
                        </tr>
                        
                    </tbody>
                ))}
            </Table>
        </div>
    );
}
export default LoanApplicationsList


