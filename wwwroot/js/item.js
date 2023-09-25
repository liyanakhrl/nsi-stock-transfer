// Database

var items = @Html.Raw(Json.Serialize(Model.Item)); // Get the initial data 
const perPage = 10; // Number of items to display per page
let currentPage = 1;
let currentData = items; // Initialize current data with the initial data

// Function to display data in the table
function displayData(data) {
    const tableBody = document.getElementById("data-body");
    tableBody.innerHTML = "";

    const startIndex = (currentPage - 1) * perPage;
    const endIndex = startIndex + perPage;
    const dataToShow = data.slice(startIndex, endIndex);

    dataToShow.forEach((item) => {
        const row = document.createElement("tr");
        row.innerHTML = `
                           <td>${item.item_Code}</td>
                                            <td>${item.longDesc}</td>
                                            <td>${item.type}</td>
                `;
        tableBody.appendChild(row);
    });
}

// Function to handle pagination buttons
function handlePaginationButtons() {
    const pagination = document.getElementById("pagination");
    pagination.innerHTML = "";

    const totalPages = Math.ceil(currentData.length / perPage);

    for (let i = 1; i <= 15; i++) {
        const button = document.createElement("button");
        button.innerText = i;
        button.addEventListener("click", () => {
            currentPage = i;
            displayData(currentData);
            handlePaginationButtons();
        });
        pagination.appendChild(button);
    }
}

// Initial page load
displayData(currentData);
handlePaginationButtons();


// Elements related .js

// Start : Set active page
var pages = document.querySelectorAll('.page'); // Get all page elements

// Add a click event listener to each page element
pages.forEach(function (page) {
    page.addEventListener('click', function (event) {
        event.preventDefault(); // Prevent the default behavior of anchor links

        // Remove the "active" class from all pages
        pages.forEach(function (p) {
            p.classList.remove('active');
        });

        // Add the "active" class to the clicked page
        page.classList.add('active');

        // You can add additional logic here to update the content based on the selected page
    });
});
        // End : Set active page