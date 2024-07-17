$(document).ready(function () {
  // Arrays for navbar elements for different pages
  const navItemsForHomePage = [
    { href: 'LandingPage.html', text: 'Home' },
    { href: 'AboutUs.html', text: 'About' },
    { href: 'Contact.html', text: 'Contact' },
    { href: 'Help.html', text: 'Help' }
  ];

  const navItemsForDashboardPage = [
    { href: 'Dashboard.html', text: 'Dashboard' },
    { href: 'Profile.html', text: 'Profile' },
    { href: 'Settings.html', text: 'Settings' },
    { href: 'Logout.html', text: 'Logout' }
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
  if (currentPage !== 'Login.html') {
    if (currentPage === 'LandingPage.html' || currentPage === 'AboutUs.html' || currentPage === 'Contact.html' || currentPage === 'Help.html') {
      updateNavbar(navItemsForHomePage);
    } else if (currentPage === 'Dashboard.html' || currentPage === 'Profile.html' || currentPage === 'Settings.html' || currentPage === 'Logout.html') {
      updateNavbar(navItemsForDashboardPage);
    }
  }
});
