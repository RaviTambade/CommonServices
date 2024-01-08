import React, { useState, useEffect} from "react";
import {useNavigate,Routes,Route} from "react-router-dom";
import axios from "axios";
import Table from 'react-bootstrap/Table';
import GetApplicantDetails from './GetApplicantDetails'

function LoanApplicantsList() {
    const navigate = useNavigate();

     const navigateToDetails = () => {
        // 👇️ navigate to /Details
         navigate('/details');
       };

    const url = "http://localhost:5053/api/application/applicationAscustomer";
    const [data, setData] = useState([]);

    const fetchInfo = () => {

        axios
            .get(url)
            .then((res) => {
                console.log(res);
                setData(res.data);
            })
            .catch((err) => {
                console.log(err);
            });

    };
    useEffect(() => {
        fetchInfo();
    }, []);

    return (
        <div>
            <h1>Loan Applicnts List</h1>

            <Table striped bordered hover >
                <thead>
                    <tr>
                        <th>Sr.No</th>
                        <th>AccountId</th>
                        <th>Applicant Name</th>
                        <th>Loan Status</th>
                        <th></th>
                    </tr>
                </thead>
                {data.map((applications, index) => (

                    <tbody key={applications.applicationId}>

                        <tr >
                            <td>{index+1}</td>
                            <td>{applications.accountId}</td>
                            <td>{applications.applicantName}</td>
                            <td>{applications.loanStatus}</td>
                            <td><button onClick={navigateToDetails}>Details</button></td> 
                        </tr>
                        <Routes>
                        <Route key={applications.applicationId} path="/details/:key" element={<GetApplicantDetails />} />
                        
                        </Routes>
                    </tbody>
                ))}
            </Table>
        </div>
    );

}
export default LoanApplicantsList;


/*We wrap our content first with <BrowserRouter>.

Then we define our <Routes>. An application can have multiple <Routes>. Our basic example only uses one.

<Route>s can be nested. The first <Route> has a path of / and renders the Layout component.

The nested <Route>s inherit and add to the parent route. So the blogs path is combined with the parent and becomes /blogs.

The Home component route does not have a path but has an index attribute. That specifies this route as the default route for the parent route, which is /.

Setting the path to * will act as a catch-all for any undefined URLs. This is great for a 404 error page.
----------------------------------------------------------------------------------------------------------------
The Layout component has <Outlet> and <Link> elements.

The <Outlet> renders the current route selected.

<Link> is used to set the URL and keep track of browsing history.

Anytime we link to an internal path, we will use <Link> instead of <a href="">.

The "layout route" is a shared component that inserts common content on all pages, such as a navigation menu.
*/