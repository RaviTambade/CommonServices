$(document).ready(function () {
    // Arrays for navbar elements for different pages
    const navItemsForLogin = [
      { href: '../Navigation/LandingPage.html', text: 'Home' },
      { href: '../Navigation/AboutUs.html', text: 'About' },
      { href: '../Navigation/Contact.html', text: 'Contact' },
      { href: '../Navigation/Help.html', text: 'Help' }
    ];
  
    const navItemsForDashboard = [
      { href: '../Navigation/UserLogin.html', text: 'UserLogin' },
      { href: '../Navigation/TryUserProfile.html', text: 'TryUserProfile' },
      { href: '../Navigation/DirectorDashboard.html', text: 'DirectorDashboard' },
      { href: '../Navigation/ManagerDashboard.html', text: 'ManagerDashboard' }
    ];
  
    // Function to dynamically update the navbar
    function updateNavbar(navItems) {
      const navbar = $('#navbar-items');
      navbar.empty(); // Clear existing items
      navItems.forEach(item => {
        const navItem = $('<a>')
          .attr('href', item.href)
          .text(item.text)
          .addClass('text-white hover:text-gray-300');
        navbar.append(navItem);
      });
    }
  
    // Determine the current page and update the navbar accordingly
    const currentPage = window.location.pathname.split('/').pop();
    if (currentPage === 'Login.html') {
      updateNavbar(navItemsForLogin);
    } else if (currentPage === 'DynamicDashboard.html') {
      updateNavbar(navItemsForDashboard);
    }
  
    // Function to dynamically add elements to the dashboard
    function populateDashboard(elements) {
      const dashboard = $('#dashboard');
      elements.forEach(element => {
        const el = $('<' + element.type + '>')
          .addClass(element.class)
          .text(element.content);
        dashboard.append(el);
      });
    }
  });
  