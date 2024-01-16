import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import axios from "axios";
import { Link } from "react-router-dom";
import '../css/LoanApplicationsList.css';


function LoanApplicationsList() {
  const url = "http://localhost:5053/api/application/applicationAscustomer";
  const [data, setData] = useState([]);
  const [toDate, setToDate] = useState(new Date().toISOString().slice(0, 10));
  const [fromDate, setFromDate] = useState('');
  const [tempData, setTempData] = useState(["applied"]);

  const handleChange = (e) => {
    if (e.target.checked) {
      setTempData([...tempData, e.target.value]);
    } else {
      setTempData(tempData.filter((item) => item != e.target.value));
    }
    console.log(fromDate);
  };
  

  const getFilteredData = data.filter((loan) => tempData.includes(loan.loanStatus) && loan.applicationDate <= toDate && loan.applicationDate >=fromDate);


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
      <div >
        <h1>Loan Applicnts List</h1>
        <div className="container-header1">
          <span>From Date :-</span>
          <input className="container-header1-ip1"type="date" onChange={(e) => setFromDate(e.target.value)} value={fromDate} />
          <span>To Date :- </span>
          <input className="container-header1-ip2" type="date" onChange={(e) => setToDate(e.target.value)} value={toDate} />
        </div><br/><br/><br/>

        <div className="container2">
          <input className="container-ck1" value="applied" type="checkbox" onChange={handleChange} defaultChecked />
          <span>Applied</span>
          <input className="container-ck2" value="approved" type="checkbox" onChange={handleChange} />
          <span>Approved</span>
          <input className="container-ck3" value="rejected" type="checkbox" onChange={handleChange} />
          <span>Rejected</span>
        </div>

        <Table striped bordered hover>
          <thead>
            <tr>
              <th>Sr.No</th>
              <th>Applicant Name</th>
              <th>Loan Status</th>
              <th></th>
            </tr>
          </thead>
          {getFilteredData.map((applications, index) => (
            <tbody key={applications.applicationId}>
              <tr>
                <td>{index + 1}</td>
                <td>{applications.applicantName}</td>
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
    </>
  );
}
export default LoanApplicationsList;
