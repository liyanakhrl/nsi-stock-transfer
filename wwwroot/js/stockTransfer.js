const newRequestBtn = document.getElementById('new-request-btn');
const showRequestBtn = document.getElementById('show-request-btn');
const statusBtn = document.getElementById('status-btn');
const newRequestDiv = document.getElementById('new-request');
const showRequestDiv = document.getElementById('show-request');
const statusDiv = document.getElementById('status');

newRequestBtn.addEventListener('click', () => {
    newRequestDiv.classList.remove('hidden');
    showRequestDiv.classList.add('hidden');
    statusDiv.classList.add('hidden');
});

showRequestBtn.addEventListener('click', () => {
    newRequestDiv.classList.add('hidden');
    showRequestDiv.classList.remove('hidden');
    statusDiv.classList.add('hidden');
});

statusBtn.addEventListener('click', () => {
    newRequestDiv.classList.add('hidden');
    showRequestDiv.classList.add('hidden');
    statusDiv.classList.remove('hidden');
});

/*set active button*/
// Get all buttons in the group
const buttons = document.querySelectorAll('.button-main');

// Function to handle button click
function handleButtonClick(event) {
    // Deactivate all buttons in the group
    buttons.forEach(button => {
        button.classList.remove('button-active');
    });

    // Activate the clicked button
    event.target.classList.add('button-active');
}

// Add click event listeners to each button
buttons.forEach(button => {
    button.addEventListener('click', handleButtonClick);
});

/* MAKE NEW REQUEST*/
const summaryTableBody = document.getElementById('summary-table-body');

function openTab(tabId, buttonId) {
    const tabs = document.querySelectorAll('.tab-content');
    tabs.forEach(tab => tab.classList.remove('active'));

    const tab = document.getElementById(tabId);
    tab.classList.add('active');

    // Remove active class from all buttons
    const buttons = document.querySelectorAll('.button');
    buttons.forEach(button => button.classList.remove('active'));

    // Add active class to the clicked button
    const clickedButton = document.getElementById(buttonId);
    clickedButton.classList.add('active');
}

function addItemToTab3(itemCode, LongDesc, Department_Code, qty) {
    // Find the input element associated with the item
    const inputId = "quantityInput_" + itemCode;
    const inputElement = document.getElementById(inputId);

    // Create a new row or find an existing row based on itemCode
    let newRow = null;
    if (summaryTableBody.querySelector(`[data-item-code="${itemCode}"]`)) {
        newRow = summaryTableBody.querySelector(`[data-item-code="${itemCode}"]`);
    } else {
        newRow = summaryTableBody.insertRow();
        newRow.setAttribute("data-item-code", itemCode); // Set a custom attribute to identify the row
    }

    // Populate the cells with the item details
    const cell1 = newRow.insertCell(0);
    const cell2 = newRow.insertCell(1);
    const cell3 = newRow.insertCell(2);
    const cell4 = newRow.insertCell(3);

    cell1.textContent = itemCode;
    cell2.textContent = LongDesc;
    cell3.textContent = Department_Code;

    // Create an input element for quantity
    const qtyInput = document.createElement("input");
    qtyInput.type = "number";
    qtyInput.value = qty; // Set the initial quantity value
    qtyInput.addEventListener("input", function () {
        // Update the quantity when it changes
        qty = parseFloat(this.value) || 0; // Parse the input value as a float
    });
    cell4.appendChild(qtyInput);
}


function updateTab3FromTab1() {
    const itemName = document.getElementById('name').value;
    const itemQuantity = document.getElementById('quantity').value;

}

function filterTable() {
    const searchInput = document.getElementById('searchInput').value.toLowerCase();
    const categorySelect = document.getElementById('categorySelect').value;

    const rows = document.querySelectorAll('tbody tr');

    rows.forEach(row => {
        const itemName = row.querySelector('td:first-child').textContent.toLowerCase();
        const itemCategory = row.querySelector('td:nth-child(2)').textContent.toLowerCase();

        const shouldShow =
            (searchInput === '' || itemName.includes(searchInput)) &&
            (categorySelect === 'all' || itemCategory.includes(categorySelect));

        row.style.display = shouldShow ? '' : 'none';
    });
}

// Initial table filtering
filterTable();
const nameForm = document.getElementById('name');
const qtyForm = document.getElementById('quantity');

const nameSummary = document.querySelector('.name-summary');
const qtySummary = document.querySelector('.qty-summary');

nameForm.addEventListener('input', updateSummary);
qtyForm.addEventListener('input', updateSummary);

function updateSummary() {
    nameSummary.textContent = nameForm.value;
    qtySummary.textContent = qtyForm.value;
}

/* SHOW HQ REQUEST*/
function toggleSummary(summaryId) {
    const summary = document.getElementById(summaryId);
    if (summary.style.display === 'none' || summary.style.display === '') {
        summary.style.display = 'block';
    } else {
        summary.style.display = 'none';
    }
}


//



