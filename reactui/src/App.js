import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
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



function App() {
  return (
    <div className="App">

      
      <BrowserRouter>
      <NavBar/>
        <Routes>          
            <Route path='/' element={<Home />} />
            <Route path="aboutus" element={<AboutUs />} />
            <Route path="loanapplicationslist" element={<LoanApplicationsList/>}/> 
            <Route path="detailsfromlist/:id" element={<DetailsOfLoanApplicants/>}/> 
            <Route path="*" element={<NoPage/>}/>             
        </Routes>
      </BrowserRouter>

    </div>
  );
}

export default App;
