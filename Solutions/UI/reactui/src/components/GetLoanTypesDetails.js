import React, { useState, useEffect } from "react";
import axios from "axios";



function GetLoanTypeDetails() {
    const url = "http://localhost:5053/api/loanstypes";
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
        <h1>Get Loan Type Details</h1>
    )
}
export default GetLoanTypeDetails