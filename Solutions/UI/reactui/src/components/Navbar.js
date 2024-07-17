import Container from 'react-bootstrap/Container';
import Nav from 'react-bootstrap/Nav';
import Navbar from 'react-bootstrap/Navbar';



function NavBar() {


  return (
    <Navbar bg="dark" data-bs-theme="dark" expand="lg" className="bg-body-tertiary">
      <Container>
        <Navbar.Brand href="/home">TAP BANK</Navbar.Brand>
        <Navbar.Toggle aria-controls="basic-navbar-nav" />
        <Navbar.Collapse id="basic-navbar-nav">
          <Nav className="me-auto">
            <Nav.Link href="/">Home</Nav.Link>
            <Nav.Link href="/aboutus">About US</Nav.Link>
            <Nav.Link href="/loanapplicationslist">Loan Applicant List</Nav.Link>    

            <Nav.Link href="/login">Login</Nav.Link>  
            <Nav.Link href="/register">Register</Nav.Link>  
            <Nav.Link href="/changedpassword">ChangedPassword</Nav.Link>  
            <Nav.Link href="/ministatment">MiniStatement</Nav.Link>
            <Nav.Link href="/loanapplicationform">LoanApplicationForm</Nav.Link>
            
          </Nav>
        </Navbar.Collapse>
      </Container>
    </Navbar>
  );
}

export default NavBar;