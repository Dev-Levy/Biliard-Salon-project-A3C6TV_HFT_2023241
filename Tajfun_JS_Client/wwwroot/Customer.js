
let customers = [];

getCustomers();

async function getCustomers() {
    await fetch('http://localhost:7332/customer')
        .then(response => response.json())
        .then(data => {
            customers = data;
            console.log(customers);
        });
}
function displayCustomers() {
    document.getElementById('bookingwindow').style.display = 'none'; // Hide bookingwindow
    document.getElementById('pooltablewindow').style.display = 'none'; // Hide pooltablewindow
    document.getElementById('customerwindow').style.display = 'flex'; // Show customerwindow

    document.getElementById('customers').innerHTML = "";
    customers.forEach(t => {
        document.getElementById('customers').innerHTML +=
            `<tr><td><input type="radio" name="selectCustomerRadio" onclick='showUpdateCustomer()'></input></td>` +
            "</td><td>" + t.name +
            "</td><td>" + t.phone +
            "</td><td>" + t.email +
            `</td><td><button type="button" onclick='removeCustomer(${t.customerId})'>Delete</button></td></tr>`;
    })
}
function addCustomer() {
    let name = document.getElementById('name').value;
    let phone = document.getElementById('phone').value;
    let email = document.getElementById('email').value;

    fetch('http://localhost:7332/customer', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            name: name,
            phone: phone,
            email: email
        })
    })
        .then(data => {
            console.log(data);
            getCustomers();
            displayCustomers();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
async function removeCustomer(id) {
    await fetch('http://localhost:7332/customer/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            getBookings();
            return getCustomers();
        })
        .then(() => {
            displayCustomers();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdateCustomer() {
    document.getElementById('updateCustomer').style.display = 'flex';
}
function updateCustomer() {
    // Update customer
}