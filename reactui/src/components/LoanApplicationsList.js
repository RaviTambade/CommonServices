import React, { useState, useEffect } from "react";
import { Table } from "react-bootstrap";
import axios from "axios";
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
    }
  };

  const getFilteredData =  data.filter((loan) => tempData.includes(loan.loanStatus) && loan.applicationDate<=toDate);


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
}
export default LoanApplicationsList;
