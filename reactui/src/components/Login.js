
import React,{useState} from 'react';
import axios from "axios";
import { Outlet, Link } from "react-router-dom";

function Login(){

    const[contact,setContact] = useState('');
    const[password,setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
    
        const data = {
            
            ContactNumber:contact,
            Password:password,
            Lob:"banking"
        };
        console.log("data ",data);
        const url =' http://localhost:5142/api/auth/signin';
    
        axios.post(url,data).then((result) =>{
            console.log(result.data);
            if(result.data.token){
                localStorage.setItem("jwt_token",result.data.token);
                alert("Login is Valid");
            }
            else
            {
                alert("Login is not Valid");;
            }
            
        }).catch(error =>{
                alert(error);
                
        });
     
      }
    
    return(
        <div>
           <form onSubmit={handleSubmit}>
                <div><h1>Login Here..</h1></div><hr/>
                <br></br>
                <label>Contact Number : </label>
                <input type="text" id="contactnumber" name="contactnumber" placeholder="Enter the Contact Number"  onChange={(e) => setContact(e.target.value)}/>
                <br></br><br></br>

                <label>Password : </label>
                <input type="password" id="password" name="password" placeholder="Enter Passwor" onChange={(e) => setPassword(e.target.value)}/>
                <br></br><br></br>

                <input type="submit" value="Login" /> <br></br>
                <label>If you are new user click on Register Link</label><br></br>
                <Link to="/register">Register</Link>
            </form>
        </div>
    )
}
export default Login