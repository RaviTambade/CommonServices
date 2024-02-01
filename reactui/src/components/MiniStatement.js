import React, { useState, useEffect } from "react";
import { useParams } from 'react-router-dom';
import { Table } from 'react-bootstrap'
import axios from "axios";

function MiniStatement() {

    const [data, setData] = useState([]);

    const [acctnum, setAcctnum] = useState();


    const handleministatement = (values) => {
        setAcctnum(values)
    }


    const handleSubmit = (event) => {
        console.log(acctnum);
        event.preventDefault();
        fetchInfo();
    }

    const fetchInfo = () => {
        const url = "http://localhost:5053/api/banking/accounts/statement/"+acctnum;
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
            <h1>Mini Statement of Account</h1><br></br>
            <form onSubmit={handleSubmit}>
                
                <label>Enter Account Number : </label>
                <input type="text" placeholder="Enter Account Number" onChange={(e) => handleministatement(e.target.value)} />
                
                {/* <label>To Date : </label>
                <input type="date" id="startdate" name="startdate" placeholder="Enter Starting Date" onChange={(e) => handletodates(e.target.value)} /><br /><br /> */}
                <button type="submit" variant="primary">Submit</button>{' '}  
            </form>

            <br></br>
            <Table striped bordered hover >
                <thead>
                    <tr>

                        <th>Amount</th>
                        <th>Date</th>
                        <th>Mode</th>
                        <th>Balance</th>

                    </tr>
                </thead>

                {data.map((statement, index) => (
                    <tbody key={index}>

                        <tr >
                            <td>{statement.amount}</td>
                            <td>{statement.date}</td>
                            <td>{statement.mode}</td>
                            <td>{statement.balance}</td>
                            
                        </tr>
                       
                    </tbody>))}
            </Table>

        </div>

    
    )
}


export default MiniStatement;