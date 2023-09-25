// Get all the pagination links
const paginationLinks = document.querySelectorAll('.pagination .page');

// Function to handle click events
function handlePageClick(event) {
    // Prevent the default link behavior (e.g., navigating to a new page)
    event.preventDefault();

    // Remove the "active" class from all pagination links
    paginationLinks.forEach(link => link.classList.remove('active'));

    // Add the "active" class to the clicked link
    event.target.classList.add('active');

    // Extract the page number from the clicked link
    const pageNumber = event.srcElement.innerText;
    ;
    // You can add additional logic here to handle the click, e.g., loading new content.
    // Use the extracted pageNumber to construct the new URL
    window.location.href = `/Inventory?pageNumber=${pageNumber}`;
}

// Add a click event listener to each pagination link
paginationLinks.forEach(link => link.addEventListener('click', handlePageClick));


// Get a reference to the dropdown element
function redirectToSelectedStore() {
    const selectedStoreCode = document.getElementById('storeDropdown').value;
    window.location.href = `/Inventory?StoreID=${selectedStoreCode}`;
}