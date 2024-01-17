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
import GetApplicantDetails from './components/GetApplicantDetails';
import DetailsOfLoanApplicants from './components/DetailsOfLoanApplicants';
import LoanApplicationsList from './components/LoanApplicationsList';
import CheckboxDemo from './components/CheckboxDemo';
import MiniStatement from './components/MiniStatement';

function App() {
  return (
    <div className="App">

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
      

    </div>
  );
}

export default App;
