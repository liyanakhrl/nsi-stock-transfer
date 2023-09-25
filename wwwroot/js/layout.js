const hideTabName = false;

function toggleSidebar() {
    const sidebar = document.querySelector('.sidebar');
    sidebar.classList.toggle('active');
    const tabNameList = document.querySelectorAll('.tab-name');
    tabNameList.forEach(tabName => {
        tabName.classList.toggle('hidden');
        tabName.style.transition = 'opacity 0.8s ease-in-out';
        tabName.style.opacity = tabName.style.opacity === '0' ? '1' : '0';
    });
    const logos = document.querySelectorAll('.logo');
    logos.forEach(logo => {
        logo.style.display = logo.style.display === 'none' ? 'block' : 'none';
    });
    const txtlogos = document.querySelectorAll('.logo-text');
    txtlogos.forEach(text => {
        text.style.display = text.style.display === 'none' ? 'block' : 'none';
    });
    const outlet = document.querySelectorAll('.outlet');
    outlet.forEach(text => {
        text.style.display = text.style.display === 'none' ? 'block' : 'none';
    });
}

function showContent(contentId, clickedTab) {
    const menuContent = document.querySelector('.menu-content');
    menuContent.style.display = 'flex';
    //setActiveTab(clickedTab); // Call setActiveTab with the clickedTab parameter
}

function setActiveTab(tab) {
    const menuItems = document.querySelectorAll('.menu li');
    menuItems.forEach(item => {
        item.classList.remove('active');
    });
    tab.classList.add('active');
}


document.addEventListener('DOMContentLoaded', function () {
    const firstTab = document.querySelector('.menu li:first-child');
    showContent('home-content', firstTab);
});
function markAsActive(linkElement) {
    // Remove the 'active' class from all <li> elements
    const menuItems = document.querySelectorAll('li');
    menuItems.forEach((menuItem) => {
        menuItem.classList.remove('active');
    });

    // Add the 'active' class to the parent <li> of the clicked link
    const parentListItem = linkElement.parentElement;
    parentListItem.classList.add('active');
}


var menu = document.getElementById("menu");

menu.addEventListener("click", function (e) {
    if (e.target && e.target.tagName == "LI") {
        // Remove the "active" class from all list items
        var listItems = menu.getElementsByTagName("li");
        for (var i = 0; i < listItems.length; i++) {
            listItems[i].classList.remove("active");
        }

        // Add the "active" class to the clicked list item
        e.target.classList.add("active");

        var page = e.target.getAttribute("data-page");
        if (page) {
            window.location.href = page;
        }
    }
});


  