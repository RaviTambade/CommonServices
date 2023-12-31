import { BrowserRouter } from 'react-router-dom';
import './App.css';
import LoanApplicationsAccordingToDates from './components/LoanApplicationByDates';
import LoanApplicationForm from './components/LoanApplicationForm';
import LoanApplicantsList from './components/LoanApplicationList';

function App() {
  return (
    <div className="App">
      
      <br/> <br></br>
      <BrowserRouter>
      {/* <LoanApplicantsList/> */}
      {/* <LoanApplicationForm></LoanApplicationForm> */}
      <LoanApplicationsAccordingToDates/>
      </BrowserRouter>

    </div>
  );
}

export default App;
