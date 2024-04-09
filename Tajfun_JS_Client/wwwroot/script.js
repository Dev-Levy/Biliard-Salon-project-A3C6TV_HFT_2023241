
let customers = [];
let pooltables = [];
let bookings = [];

fetch('http://localhost:7332/customer')
    .then(response => response.json())
    .then(data => {
        customers = data;
        console.log(customers);
        displayCustomers();
    });
fetch('http://localhost:7332/booking')
    .then(response => response.json())
    .then(data => {
        bookings = data;
        console.log(bookings);
        displayBookings();
    });
fetch('http://localhost:7332/pooltable')
    .then(response => response.json())
    .then(data => {
        pooltables = data;
        console.log(pooltables);
        displayPoolTables();
    });


function displayCustomers() {
    customers.forEach(t => {
        document.getElementById('customers').innerHTML +=
            "<tr><td>" + t.name + "</td><td>" + t.phone + "</td><td>" + t.email + "</td></tr>";
    })
}
function displayBookings() {
    bookings.forEach(t => {
        document.getElementById('bookings').innerHTML +=
            "<tr><td>" + t.customer.name + "</td><td>" + t.startDate + "</td><td>" + t.endDate + "</td><td>" + t.poolTable.t_kind + "</td></tr>";
    })
}

function displayPoolTables() {
    pooltables.forEach(t => {
        document.getElementById('pooltables').innerHTML +=
            "<tr><td>" + t.tableId + "</td><td>" + t.t_kind + "</td></tr>";
    })
}

