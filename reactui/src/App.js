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
import NavBar from './components/Navbar';
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
        <Routes>          
            <Route path='/' element={<Home />} />
            <Route path="aboutus" element={<AboutUs />} />
            <Route path="loanapplicationslist" element={<LoanApplicationsList/>}/> 
            <Route path="detailsfromlist/:id" element={<DetailsOfLoanApplicants/>}/> 
            <Route path="*" element={<NoPage/>}/>             
        </Routes>

        {/* <TryNotification/> */}
      </BrowserRouter>

    </div>
  );
}

export default App;
