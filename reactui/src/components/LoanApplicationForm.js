import React,{Fragment,useState} from 'react';
import axios from "axios";

function LoanApplicationForm(){

    const[accountid,setAccountid] = useState('');
    const[applicationdate,setApplicationdate] = useState('');
    const[amount,setAmount] = useState('')
    const[duration,setDuration] = useState('');
    const[loantype,setLoantype] = useState('');
    const[intrestrate,setIntrestrate] = useState('');
    const[status,setStatus] = useState('');

       

   

    const handleSubmit = (event) => {
    event.preventDefault();

    const data = {
        
        AccountId:accountid,
        ApplicationDate:applicationdate,
        LoanAmount:amount,
        LoanDuration:duration,
        LoanType:loantype,
        Intrestrate:intrestrate,
        LoanStatus:status
   
        
    };
    console.log("data ",data);
    const url ='http://localhost:5053/api/application';

    axios.post(url,data).then((result) =>{
        console.log(result.data);
            alert("Data Posted")
        
    }).catch(error =>{
            alert(error);
            
    });
 
  }

    return(
        <Fragment>
            <form onSubmit={handleSubmit}>
                <div><h1>Loan Application Form</h1></div><hr/>
                <br></br>
                <label>Bank AccountId : </label>
                <input type="text" id="accountId" name="accountId" placeholder="Enter Bank Account ID"  onChange={(e) => setAccountid(e.target.value)}/>
                <br></br><br></br>

                <label>Application Date : </label>
                <input type="date" id="applicationdate" name="applicationdate" placeholder="Enter Loan Application Date" onChange={(e) => setApplicationdate(e.target.value)}/>
                <br></br><br></br>

                <label>Loan Amount : </label>
                <input type="number" id="txtAmount" name="txtAmount" placeholder="Enter Loan Amount" onChange={(e) => setAmount(e.target.value)}/>
                <br></br><br></br>

                <label>Loan Duration : </label>
                <input type="number" id="txtDuration" name="txtDuration" placeholder="Enter Loan Duration" onChange={(e) => setDuration(e.target.value)}/>
                <br></br><br></br>

                <label>Loan Type : </label>
                <select  id="txtLoantype" name="txtLoantype" placeholder="Enter Loan Type" onChange={(e) => setLoantype(e.target.value)}>
                    <option value="">Select Loan Type</option></select>
                <br></br><br></br>

                <label>Intrest Rate : </label>
                <label type="number" id="intrestrate" name="intrestrate" onChange={(e) => setIntrestrate(e.target.value)}></label>
                <br></br><br></br>

                <label>Loan Status : </label>
                <select id="loanstatus" name="loanstatus" onChange={(e) => setStatus(e.target.value)}>
                    <option value="applied">Applied</option></select>
                <br></br><br></br>

                
                

                <input type="submit" />

            </form>
        </Fragment>
    )
}

export default LoanApplicationForm;



/*<button onClick={()=>handleSave()}>Save</button> */
/*onChange={(e) => setContact(e.target.value)}*/
/*onChange={(e) => setAccountid(e.target.value)}*/