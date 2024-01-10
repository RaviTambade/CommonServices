import './App.css';
import { BrowserRouter, Routes, Route } from "react-router-dom";
import AboutUs from './components/AboutUs';
import Home from './components/Home';
import NoPage from './components/NoPage';
import Login from './components/Login';
import Resister from './components/Resister';
import Layout from './components/Layout';
import LoanApplicantsList from './components/LoanApplicationList';
import GetApplicantsListByDate from './components/GetApplicantsListByDates';
import GetApplicantsListByStatus from './components/GetApplicantsListByStatus';
import GetApplicantDetails from './components/GetApplicantDetails';


function App() {
  return (
    <div className="App">

      <br /> <br></br>
      <BrowserRouter>
        {/* <GetApplicantsListByDate/> */}
        <Routes>
          <Route path="/" element={<Layout />}>
            <Route index element={<Home />} />
            <Route path="login" element={<Login />} />
            <Route path="resister" element={<Resister />} />
            <Route path="aboutus" element={<AboutUs />} />
            <Route path="loanapplicationlist" element={<LoanApplicantsList />} />
            <Route path="loanapplicantsaccordingtodates" element={<GetApplicantsListByDate />} />
            <Route path="loanapplicantsaccordingtostatus" element={<GetApplicantsListByStatus/>}/>
            <Route path="details/:id" element={<GetApplicantDetails/>}/>
            <Route path="*" element={<NoPage />} />
          </Route>         
        </Routes>
      </BrowserRouter>

    </div>
  );
}

export default App;
