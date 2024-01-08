import React,{useState,useEffect} from  "react";
import {Routes, Route, useNavigate} from 'react-router-dom';
//import axios from "axios";

function GetApplicantDetails(props)
{
    const keyitem = props.key;

    return(
        <div>
            <h1>Loan Applicant Detials</h1>
            console.log(keyitem);
        </div>
    )
}



export default GetApplicantDetails;