import React, { useState, useEffect } from "react";
import axios from "axios";



function GetCustomerDetails() {

   
   

    const [data, setData] = useState({});
    const [corporatedata,setCorporateData] = useState({});
    const [memberdata,setmemberData] = useState({});

    const fetchInfo = () => {

        const acctnumber = document.getElementById("acctnumber").value; 
        console.log(acctnumber);
        const url = "http://localhost:5053/api/accounts/" + acctnumber;
        axios
            .get(url)
            .then((res) => {
                console.log(res);
                setData(res.data);

                console.log(data);
                let IDofCustomer = res.data.customerId;
                console.log(res.data.acctType);
                if(res.data.acctType == "business")
                {
                    console.log("Inside business.....");
                    const url2 = "http://localhost:5041/api/corporates/" + IDofCustomer;
                    //const fetchInfo2 = () => {
                        axios
                            .get(url2)
                            .then((res) => {
                                console.log("Business Info..",res);
                                setCorporateData(res.data);
                            })
                            .catch((err) => {
                                console.log(err);
                            });
                
                    //};
                    console.log(res.data.acctNumber);
                    console.log(res.data.acctType);
                    console.log(corporatedata);
                }
                else
                {
                    
                    const url3 = "http://localhost:5142/api/users/" + IDofCustomer;
                    //const fetchInfo3 = () => {
                        axios
                            .get(url3)
                            .then((res) => {
                                console.log("Users Info...",res);
                                setmemberData(res.data);
                            })
                            .catch((err) => {
                                console.log(err);
                            });
                
                    //};
                    console.log(res.data.acctNumber);
                    console.log(res.data.acctType);
                    console.log(memberdata);

                    console.log("Wrong data..");
                }
            })
            .catch((err) => {
                console.log(err);
            });

    };
    useEffect(() => {
        //fetchInfo();
    }, []);

    return (
        <div>
                <h1>Customer Details</h1>
                <label>Enter Account Number :: </label><br/>
                <input type="text" id="acctnumber" placeholde="Enter Account Number"/><br/>
                
                 <button onClick={()=>fetchInfo()}>Get Custom Details</button> <br/>
                <label> Acct Number : {data.acctNumber}</label><br/><br/>
                <label> Balance : {data.balance}</label>
                {data.acctType == "business" ?
                <div>
                     <label> Name : {corporatedata.name}</label><br/><br/>
                     <label> Contact Number : {corporatedata.contactNumber}</label><br/><br/>
                     <label> Email : {corporatedata.email}</label><br/><br/>
                </div>
            : 
                <div> <label> Name : {memberdata.firstName + "  " + memberdata.lastName}</label><br/><br/>
                <label> Contact Number : {memberdata.contactNumber}</label><br/><br/>
                <label> Email : {memberdata.email}</label><br/><br/>
                </div>
                }

                
        </div>
        
    )
}
export default GetCustomerDetails