import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import axios from "axios";
<<<<<<< HEAD
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
=======
import { Link } from "react-router-dom";
function LoanApplicationsList() {
  const url = "http://localhost:5053/api/application/applicationAscustomer";
  const [data, setData] = useState([]);
  const [toDate, setToDate] = useState(new Date().toISOString().slice(0,10));
  const [tempData, setTempData] = useState(["applied"]);

  const handleChange = (e) => {
    if (e.target.checked) {
      setTempData([...tempData, e.target.value]);
    } else {
      setTempData(tempData.filter((item) => item != e.target.value));
>>>>>>> 40a5d3745bcdc13afd95320abd3d2fe131865392
    }
  };

  const getFilteredData =  data.filter((loan) => tempData.includes(loan.loanStatus) && loan.applicationDate<=toDate);


<<<<<<< HEAD
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
=======
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
      <input type="date" onChange={(e)=>setToDate(e.target.value)}  value={toDate} /> ToDate
      <input value="applied" type="checkbox"   onChange={handleChange}  defaultChecked/>
      <span>Applied</span>
      <input value="approved" type="checkbox" onChange={handleChange} />
      <span>Approved</span>
      <input value="rejected" type="checkbox" onChange={handleChange} />
      <span>Rejected</span>
      <Table striped bordered hover size="sm">
        <thead>
          <tr>
            <th>Sr.No</th>
            <th>AccountId</th>
            <th>Applicant Name</th>
            <th>Applicant Date</th>
            <th>Loan filteredList</th>
            <th></th>
          </tr>
        </thead>
        {getFilteredData.map((applications, index) => (
          <tbody key={applications.applicationId}>
            <tr>
              <td>{index + 1}</td>
              <td>{applications.accountId}</td>
              <td>{applications.applicantName}</td>
              <td>{applications.applicationDate}</td>
              <td>{applications.loanStatus}</td>
              <td>
                <Link to={`/detailsfromlist/${applications.applicationId}`}>
                  Details
                </Link>
              </td>
            </tr>
          </tbody>
        ))}
      </Table>
    </div>
  );
>>>>>>> 40a5d3745bcdc13afd95320abd3d2fe131865392
}
export default LoanApplicationsList;
