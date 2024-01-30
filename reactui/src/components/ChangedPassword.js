
import React,{useState} from 'react';
import axios from "axios";

function ChangedPassword(){

    const[oldpassword,setOldPassword] = useState('');
    const[newpassword,setNewPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
    
        const data = {      
            oldPassword:oldpassword,
            newPassword:newpassword  
        };
        console.log("data ",data);
        const url =' http://localhost:5142/api/auth/updatepassword';
        const token = localStorage.getItem("jwt_token");
        axios.put(url,data,{ headers: {
            Authorization: `Bearer ${token}`
            
        }}).then((result) =>{
            
            console.log(result.data);
            if(result.data)
                alert("Login Password is Changed Succeesufully.....");
            else
            alert("Login Password is not Changed.......");
        }).catch(error =>{
                alert(error);
                
        });
     
      }
    
    return(
        <div>
           <form onSubmit={handleSubmit}>
                <div><h1>Changed the Password Here..</h1></div><hr/>
                <br></br>
                <label>Enter Old Password : </label>
                <input type="text" id="oldpassword" name="oldpassword" placeholder="Enter old password"  onChange={(e) => setOldPassword(e.target.value)}/>
                <br></br><br></br>

                <label>Enter New Password : </label>
                <input type="password" id="newpassword" name="newpassword" placeholder="Enter New Password" onChange={(e) => setNewPassword(e.target.value)}/>
                <br></br><br></br>

                <input type="submit" value = "ChangedPassword"/>
        
            </form>
        </div>
    )
}
export default ChangedPassword