import React, {useState} from "react"
import axios from "axios";

function Register(){
    const[imageurl,setImageUrl] = useState('');
    const[aadharid,setAadharId] = useState('');
    const[firstname,setFirstName] = useState('');
    const[lastname,setLastName] = useState('')
    const[birthdate,setBirthDate] = useState('');
    const[gender,setGender] = useState('');
    const[contactnumber,setContactNumber] = useState('');
    const[password,setPassword] = useState('');

    const handleSubmit = (event) => {
        event.preventDefault();
    
        const data = {
            
            ImageUrl:imageurl,
            FirstName:firstname,
            LastName:lastname,
            BirthDate:birthdate,
            AadharId:aadharid,
            Gender:gender,
            ContactNumber:contactnumber,
            Password:password
     
        };
        console.log("data ",data);
        const url ='http://localhost:5053/api/users';
    
        axios.post(url,data).then((result) =>{
            console.log(result.data);
            if(result.data)
                alert("Data Posted")
            
        }).catch(error =>{
                alert(error);
                
        });
     
      }
    



    return(
        <div>
            <h1>Resister Form</h1>
            <form onSubmit={handleSubmit}>
                
                <br></br>
                <label>Imge Url : </label>
                <input type="text" id="imageurl" name="imageurl" placeholder="Enter Image Url"  onChange={(e) => setImageUrl(e.target.value)}/>
                <br></br><br></br>

                <label>Aadhar ID : </label>
               
                <input type="text" id="aadharid" name="aadharid" placeholder="Enter aadhar Id"  onChange={(e) => setAadharId(e.target.value)}/>
                <br></br><br></br>

                <label>First Name : </label>
                <input type="text" id="fname" name="fname" placeholder="Enter First Name " onChange={(e) => setFirstName(e.target.value)}/>
                <br></br><br></br>

                <label>Last Name: </label>
                <input type="text" id="name" name="name" placeholder="Enter Last Name" onChange={(e) => setLastName(e.target.value)}/>
                <br></br><br></br>

                <label>Birth Date : </label>
                 <input type="date" id="bdate" name="bdate" placeholder="Enter Birth Date" onChange={(e) => setBirthDate(e.target.value)}/> 
                <br></br><br></br>

                <label>Gender : </label> &nbsp;
                <input type="radio" id="male" name="male" value="Male"/>
                <label for="male">Male</label>&nbsp; &nbsp;
                <input type="radio" id="female" name="female" value="Female"/>
                <label for="female">Female</label><br/>  
                       
                <br></br><br></br>

                <label>Contact Number : </label>
                <input type="text" id="contact" name="contact" onChange={(e) => setContactNumber(e.target.value)}/>
                    
                <br></br><br></br>   

                <label>Password : </label>
                <input type="password" id="password" name="password" onChange={(e) => setPassword(e.target.value)}/>
                    
                <br></br><br></br>               

                <input type="submit" />

            </form>
            </div>
    )
}
export default Register


