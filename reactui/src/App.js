import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
//import { Notifications } from "react-push-notification";
import AboutUs from './components/AboutUs';
import Home from './components/Home';
import NoPage from './components/NoPage';
import Login from './components/Login';
import Resister from './components/Resister';
import Layout from './components/Layout';
//import LoanApplicantsList from './components/LoanApplicationList';
import GetApplicantsListByDate from './components/GetApplicantsListByDates';
import GetApplicantsListByStatus from './components/GetApplicantsListByStatus';
import DetailsOfLoanApplicants from './components/DetailsOfLoanApplicants';
import LoanApplicationsList from './components/LoanApplicationsList';
import CheckboxDemo from './components/CheckboxDemo';
<<<<<<< HEAD
import MiniStatement from './components/MiniStatement';
=======
import NavBar from './components/Navbar';
//import TryNotification from './components/Notification';
import { NotificationContainer } from 'react-notifications';
//import { Notifications } from "react-push-notification";
import 'react-notifications/lib/notifications.css';
>>>>>>> 8e8a4013a23cdd71d8788a34becee25245d39e3f

function App() {
  return (
    <div className="App">

<<<<<<< HEAD
{/*     
      <BrowserRouter>
      
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="login" element={<Login />} />
            <Route path="resister" element={<Resister />} />
            <Route path="aboutus" element={<AboutUs />} />
           
            <Route path="loanapplicantsaccordingtodates" element={<GetApplicantsListByDate />} />
            <Route path="loanapplicantsaccordingtostatus" element={<GetApplicantsListByStatus/>}/>
            <Route path="details/:id" element={<GetApplicantDetails/>}/>
            <Route path="detailsfromlist/:id" element={<DetailsOfLoanApplicants/>}/>
            <Route path="loanapplicationslist" element={<LoanApplicationsList/>}/>
            <Route path="checkboxdemo" element={<CheckboxDemo/>}/>
            <Route path="*" element={<NoPage />} />
            
          </Route> 

        </Routes>
        
      </BrowserRouter>   */}
      <MiniStatement></MiniStatement>
      
=======
      
      <BrowserRouter>
      <NavBar/>
        <NotificationContainer/>
        <Routes>          
            <Route path='/' element={<Home />} />
            <Route path="aboutus" element={<AboutUs />} />
            <Route path="loanapplicationslist" element={<LoanApplicationsList/>}/> 
            <Route path="detailsfromlist/:id" element={<DetailsOfLoanApplicants/>}/> 
            <Route path="*" element={<NoPage/>}/>             
        </Routes>

        {/* <TryNotification/> */}
      </BrowserRouter>
>>>>>>> 8e8a4013a23cdd71d8788a34becee25245d39e3f

    </div>
  );
}

export default App;
