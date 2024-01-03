import React,{Fragment,useState} from 'react';
import axios from "axios";
import Table from 'react-bootstrap/Table';


function LoanApplicationsAccordingToDates(){

    const getLoanApplications = (event) => {
    event.preventDefault();

    const[applicationstartdate,setApplicationstartdate] = useState('');
    const[applicationsenddate,setApplicationenddate] = useState('');


   
        const url = "http://localhost:5053/api/application" + "/" + applicationstartdate + "/" + applicationsenddate;
        const [data, setData] = useState([]);

        const fetchInfo = () =>{

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
    },[]);

    return(
    <div>
       <h1>Loan Applicnts List</h1>
      
            <Table stripped bordered hover >
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
    </div>
   );

    }




    return(
        <Fragment>
            <form onSubmit={getLoanApplications}>
                <div><h1>Loan Applications According To Dates..</h1></div><hr/>
                <br></br>
                <label>Application Start Date : </label>
                <input type="date" id="applicationstartdate" name="applicationstartdate" placeholder="Enter Loan Application Start Date" onChange={(e) => setApplicationstartdate(e.target.value)}/>
                <br></br><br></br>

                <label>Application End Date : </label>
                <input type="date" id="applicationenddate" name="applicationenddate" placeholder="Enter Loan Application End Date" onChange={(e) => setApplicationenddate(e.target.value)}/>
                <br></br><br></br>

                <input type="submit" />

            </form>
        </Fragment>
    ) 
}

export default LoanApplicationsAccordingToDates;
