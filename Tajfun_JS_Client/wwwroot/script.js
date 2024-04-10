
let customers = [];
let pooltables = [];
let bookings = [];

fetch('http://localhost:7332/customer')
    .then(response => response.json())
    .then(data => {
        customers = data;
        console.log(customers);
    });
fetch('http://localhost:7332/booking')
    .then(response => response.json())
    .then(data => {
        bookings = data;
        console.log(bookings);
    });
fetch('http://localhost:7332/pooltable')
    .then(response => response.json())
    .then(data => {
        pooltables = data;
        console.log(pooltables);
    });


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
            "<tr><td>" + t.customer.name + "</td><td>" + t.startDate + "</td><td>" + t.endDate + "</td><td>" + t.poolTable.t_kind + "</td></tr>";
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

