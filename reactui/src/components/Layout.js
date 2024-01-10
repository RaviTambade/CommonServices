import { Outlet, Link } from "react-router-dom";
import '../css/Layout.css';

const Layout = () => {
  return (
    <>
      <nav>
        <ul>
          <li>
            <Link to="/">Home</Link>
          </li>
          <li>
            <Link to="/aboutus">AoutUs</Link>
          </li>
          <li>
            <Link to="/login">Login</Link>
          </li>
          <li>
            <Link to="/resister">Resister</Link>
          </li>
          <li>
            <Link to="/loanapplicationslist">Loan Applications List</Link>
          </li>
          <li>
            <Link to="/loanapplicantsaccordingtodates">Loan Application List Acording to dates</Link>
          </li>
          <li>
            <Link to="/loanapplicantsaccordingtostatus">Loan Application List Acording to Status</Link>
          </li>
          <li>
            <Link to="/checkboxdemo">CheckboxDemo</Link>
          </li>
          
        </ul>
      </nav>

      <Outlet />
    </>
  )
};

export default Layout;
