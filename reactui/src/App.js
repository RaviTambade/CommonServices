import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
//import { Notifications } from "react-push-notification";
import AboutUs from './components/AboutUs';
import Home from './components/Home';
import NoPage from './components/NoPage';
import Login from './components/Login';
import ChangedPassword from './components/ChangedPassword';
import Register from './components/Register';
import Layout from './components/Layout';
//import GetApplicantsListByDate from './components/GetApplicantsListByDates';
import DetailsOfLoanApplicants from './components/DetailsOfLoanApplicants';
import LoanApplicationsList from './components/LoanApplicationsList';
import MiniStatement  from './components/MiniStatement';
import NavBar from './components/Navbar';
import LoanApplicationForm from'./components/LoanApplicationForm';
//import TryNotification from './components/Notification';
import { NotificationContainer } from 'react-notifications';

//import { Notifications } from "react-push-notification";
import 'react-notifications/lib/notifications.css';

function App() {
  return (
    <div className="App">

      <BrowserRouter>
      <NavBar/>
          <NotificationContainer/>
          
          <hr/>
        <Routes>          
            <Route path='/' element={<Home />} />
            <Route path="aboutus" element={<AboutUs />} />
            <Route path="loanapplicationslist" element={<LoanApplicationsList/>}/> 
            <Route path="detailsfromlist/:id" element={<DetailsOfLoanApplicants/>}/> 
            <Route path="login" element={<Login />} />
            <Route path="changedpassword" element={<ChangedPassword />} /> 
            <Route path="register" element={<Register/>} /> 
            <Route path="ministatment" element={<MiniStatement/>} /> 
            <Route path="loanapplicationForm" element={<LoanApplicationForm/>}/>
        </Routes> 
        
        {/* <TryNotification/> */}

      </BrowserRouter>

    </div>
  );
}

export default App;
