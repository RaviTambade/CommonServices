import { BrowserRouter } from 'react-router-dom';
import './App.css';
//import LoanApplicantsList from './components/LoanApplicationList';
import GetApplicantsListByDate from './components/GetApplicantsListByDates';

function App() {
  return (
    <div className="App">

      <br /> <br></br>
      <BrowserRouter>
        {/* <LoanApplicantsList /> */}
        <GetApplicantsListByDate/>
      </BrowserRouter>

    </div>
  );
}

export default App;
