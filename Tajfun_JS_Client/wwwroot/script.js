
let customers = [];
let pooltables = [];
let bookings = [];

getCustomers();
getBookings();
getPoolTables();

function formatDate(date) {
    let d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear(),
        hour = '' + d.getHours(),
        minute = '' + d.getMinutes();

    if (month.length < 2)
        month = '0' + month;
    if (day.length < 2)
        day = '0' + day;
    if (hour.length < 2)
        hour = '0' + hour;
    if (minute.length < 2)
        minute = '0' + minute;

    return [year, month, day].join('.') + ' ' + [hour, minute].join(':');
}
async function getCustomers() {
    await fetch('http://localhost:7332/customer')
        .then(response => response.json())
        .then(data => {
            customers = data;
            console.log(customers);
        });
}
async function getBookings() {
   await fetch('http://localhost:7332/booking')
        .then(response => response.json())
        .then(data => {
            bookings = data;
            console.log(bookings);
        });
}
async function getPoolTables() {
   await fetch('http://localhost:7332/pooltable')
        .then(response => response.json())
        .then(data => {
            pooltables = data;
            console.log(pooltables);
        });
}


function displayCustomers() {
    document.getElementById('bookingwindow').style.display = 'none'; // Hide bookingwindow
    document.getElementById('pooltablewindow').style.display = 'none'; // Hide pooltablewindow
    document.getElementById('customerwindow').style.display = 'flex'; // Show customerwindow

    document.getElementById('customers').innerHTML = "";
    customers.forEach(t => {
        document.getElementById('customers').innerHTML +=
            "<tr><td>" + t.name + "</td><td>" + t.phone + "</td><td>" + t.email + "</td></tr>";
    })
}
function displayBookings() {
    document.getElementById('bookingwindow').style.display = 'flex'; // Hide bookingwindow
    document.getElementById('pooltablewindow').style.display = 'none'; // Hide pooltablewindow
    document.getElementById('customerwindow').style.display = 'none'; // Show customerwindow

    document.getElementById('bookings').innerHTML = "";
    bookings.forEach(t => {
        document.getElementById('bookings').innerHTML +=
            "<tr><td>" + t.customer.name + "</td><td>" +
           formatDate(t.startDate) + "</td><td>" + formatDate(t.endDate) +
            "</td><td>" + t.poolTable.t_kind + "</td></tr>";
    })

    document.getElementById('customerSelect').innerHTML = "";
    customers.forEach(c => {
        document.getElementById('customerSelect').innerHTML +=
            "<option value='" + c.customerId + "'>" + c.name + "</option>";
    })

    document.getElementById('poolTableSelect').innerHTML = "";
    pooltables.forEach(t => {
        document.getElementById('poolTableSelect').innerHTML +=
            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
    })
}
function displayPoolTables() {
    document.getElementById('bookingwindow').style.display = 'none'; // Hide bookingwindow
    document.getElementById('pooltablewindow').style.display = 'flex'; // Hide pooltablewindow
    document.getElementById('customerwindow').style.display = 'none'; // Show customerwindow

    document.getElementById('pooltables').innerHTML = "";
    pooltables.forEach(t => {
        document.getElementById('pooltables').innerHTML +=
            "<tr><td>" + t.tableId + "</td><td>" + t.t_kind + "</td></tr>";
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
function addBooking() {
    let customer = document.getElementById('customerSelect').value;
    let poolTable = document.getElementById('poolTableSelect').value;
    let startDate = document.getElementById('start').value;
    let endDate = document.getElementById('end').value;

    fetch('http://localhost:7332/booking', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            customerId: customer,
            tableId: poolTable,
            startDate: startDate,
            endDate: endDate
        })
    })
    .then(data => {
        console.log(data);
        getBookings();
        displayBookings();
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}
function addPoolTable() {

    fetch('http://localhost:7332/pooltable', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            t_kind: "Pool"
        })
    })
    .then(data => {
        console.log(data);
        getPoolTables();
        displayPoolTables();
    })
    .catch((error) => {
        console.error('Error:', error);
    });
}
function addSnookerTable() {

    fetch('http://localhost:7332/pooltable', {
        method: 'POST',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            t_kind: "Snooker"
        })
    })
        .then(data => {
            console.log(data);
            getPoolTables();
            displayPoolTables();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

