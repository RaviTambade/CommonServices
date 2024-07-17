import React,{Fragment,useState} from 'react';
import axios from "axios";

function LoanApplicationForm(){

    const[accountid,setAccountid] = useState('');
    const[applicationdate,setApplicationdate] = useState('');
    const[amount,setAmount] = useState('')
    const[duration,setDuration] = useState('');
    const[loantypeid,setLoantypeid] = useState('');
    const[intrestrate,setIntrestrate] = useState('');
    const[status,setStatus] = useState('applied');
    

    const handleChange = (e) => {

        setLoantypeid(e.target.value);
        
        console.log("Inside handlechange  "+ loantypeid);
       
        SetInterestAccordingLoanType(e.target.value);
      };

       
    const SetInterestAccordingLoanType = (ltype)=>
    {
        console.log("Inside SetInterset  " + ltype);
        switch(ltype){

            case '100': setIntrestrate(9.5);
            console.log(intrestrate);
            break;
            case '101':setIntrestrate(11);
            console.log(intrestrate);
            break;
            case '102':setIntrestrate(12.5);
            console.log(intrestrate);
            break;
            case '103':setIntrestrate(7.6);
            console.log(intrestrate);
            break;
            case '104':setIntrestrate(15.6);
            console.log(intrestrate);
            break;
        }
        
    };


    const handleSubmit = (event) => {
    event.preventDefault();    
    const data = {
        
        AccountId:accountid,
        ApplicationDate:applicationdate,
        LoanAmount:amount,
        LoanDuration:duration,
        LoanTypeId:loantypeid,
        Intrestrate:intrestrate,
        LoanStatus:status
   
        
    };
    console.log("data ",data);
    const url ='http://localhost:5053/api/loanppications';

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
                <select  id="txtLoantype" name="txtLoantype" placeholder="Enter Loan Type" onChange={handleChange}>
                    <option value="">Select Loan Type</option>
                    <option value='100' >Home</option>
                    <option value='101' >Personal</option>
                    <option value='102' >Car</option>
                    <option value='103' >Education</option>
                    <option value='104' >Business</option>
                
                    </select>
                    

                <br></br><br></br>

                <label>Intrest Rate : </label>
                {/* <label type="number" id="intrestrate" name="intrestrate" onChange={(e) => setIntrestrate(e.target.value)}></label> */}
                <label type="number" id="intrestrate" name="intrestrate" >{intrestrate}</label>

                {/* <label type="number" id="intrestrate" name="intrestrate" onChange={(e) => SetInterestAccordingLoanType(collectloantype)}></label> */}
               
                <br></br><br></br>

                <label>Loan Status : </label>
                {/* <select id="loanstatus" name="loanstatus" onChange={(e) => setStatus(e.target.value)}> */}
                    {/* <option value="applied">Applied</option></select> */}
                <label type="text" id="loanstatus" name="loanstatus" >{status}</label>

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