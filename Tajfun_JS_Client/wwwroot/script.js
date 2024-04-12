let customers = [];
let bookings = [];
let pooltables = [];

let numberOfBookings = 0;
let mostUsedTable;
let tableRates;

//API
//#region API
async function getCustomers() {
    await fetch('http://localhost:7332/customer')
        .then(response => response.json())
        .then(data => {
            customers = data;
            console.log("customers GET done");
        });
}
async function getBookings() {
    await fetch('http://localhost:7332/booking')
        .then(response => response.json())
        .then(data => {
            bookings = data;
            console.log("bookings GET done");
        });
}
async function getPoolTables() {
    await fetch('http://localhost:7332/pooltable')
        .then(response => response.json())
        .then(data => {
            pooltables = data;
            console.log("pooltables GET done");
        });
}


async function getMostFrequentCustomers(num) {
    await fetch('http://localhost:7332/NonCrud/MostFrequentCustomers/' + num)
        .then(response => response.json())
        .then(data => {
            console.log(data);
        });
}
async function getHowManyBookingsBetweenTwoDates(start, end) {
    await fetch('http://localhost:7332/NonCrud/HowManyBookingsBetweenTwoDates/'+ start + ',' + end)
        .then(response => response.json())
        .then(data => {
            numberOfBookings = data;
            console.log(data);
        });
}
async function getBookingsBetweenTwoDates(start, end) {
    await fetch('http://localhost:7332/NonCrud/BookingsBetweenTwoDates/' + start + ',' + end)
        .then(response => response.json())
        .then(data => {
            bookings = data;
            console.log(data);
        });
}
async function getMostUsedTable() {
    await fetch('http://localhost:7332/NonCrud/MostUsedTable')
        .then(response => response.json())
        .then(data => {
            mostUsedTable = data;
            console.log(data);
        });
}
async function getTablekindsBooked(start, end) {
    await fetch(`http://localhost:7332/NonCrud/TablekindsBooked/`)
        .then(response => response.json())
        .then(data => {
            tableRates = data;
            console.log(data);
        });
}

//#endregion

//signalR
//#region signalR
let connection = null;

setupSignalR();

function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:7332/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("CustomerCreated", (user, message) => {
        return getCustomers()
            .then(() => displayCustomers());
    });
    connection.on("CustomerDeleted", (user, message) => {
        return getCustomers()
            .then(() => displayCustomers());
    });
    connection.on("CustomerUpdated", (user, message) => {
        return getCustomers()
            .then(() => displayCustomers());
    });

    connection.on("BookingCreated", (user, message) => {
        return getBookings()
            .then(() => displayBookings());
    });
    connection.on("BookingDeleted", (user, message) => {
        return getBookings()
            .then(() => displayBookings());
    });
    connection.on("BookingUpdated", (user, message) => {
        return getBookings()
            .then(() => displayBookings());
    });

    connection.on("PoolTableCreated", (user, message) => {
        return getPoolTables()
            .then(() => displayPoolTables());
    });
    connection.on("PoolTableDeleted", (user, message) => {
        return getPoolTables()
            .then(() => displayPoolTables());
    });
    connection.on("PoolTableUpdated", (user, message) => {
        return getPoolTables()
            .then(() => displayPoolTables());
    });

    connection.onclose
        (async () => {
            await start();
        });
    start();
}
async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected!");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
//#endregion

//Customers
//#region Customers
let customerIdUpdate = 0;
function displayCustomers() {
    document.getElementById('bookingwindow').style.display = 'none'; 
    document.getElementById('pooltablewindow').style.display = 'none';
    document.getElementById('customerwindow').style.display = 'flex';

    document.getElementById('updateCustomer').style.display = 'none';
    document.getElementById('updateBooking').style.display = 'none';
    document.getElementById('updatePoolTable').style.display = 'none';

    return getCustomers().then(() => {

        document.getElementById('customers').innerHTML = "";
        customers.forEach(t => {
            document.getElementById('customers').innerHTML +=
                `<tr><td><input type="radio" name="selectCustomerRadio" onclick='showUpdateCustomer("${t.customerId}","${t.name}","${t.phone}","${t.email}")'></input></td>` +
                "</td><td>" + t.name +
                "</td><td>" + t.phone +
                "</td><td>" + t.email +
                `</td><td><button type="button" onclick='removeCustomer(${t.customerId})'>Delete</button></td></tr>`;
        })
    });    
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
            displayCustomers();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdateCustomer(id, name, phone, email) {
    document.getElementById('updateCustomer').style.display = 'flex';
    document.getElementById('nameUpdate').value = name;
    document.getElementById('phoneUpdate').value = phone;
    document.getElementById('emailUpdate').value = email;
    customerIdUpdate = id;
}
function updateCustomer() {
    let name = document.getElementById('nameUpdate').value;
    let phone = document.getElementById('phoneUpdate').value;
    let email = document.getElementById('emailUpdate').value;

    fetch('http://localhost:7332/customer', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            customerId: customerIdUpdate,
            name: name,
            phone: phone,
            email: email
        })
    })
        .then(data => {
            console.log(data);
            return getCustomers();
        })
        .then(() => {
            displayCustomers();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('updateCustomer').style.display = 'none';
}
//#endregion

//Bookings
//#region Bookings
let bookingIdUpdate = 0;
async function displayBookings() {
    document.getElementById('bookingwindow').style.display = 'flex';
    document.getElementById('pooltablewindow').style.display = 'none';
    document.getElementById('customerwindow').style.display = 'none';
    document.getElementById('updateCustomer').style.display = 'none';
    document.getElementById('updateBooking').style.display = 'none';
    document.getElementById('updatePoolTable').style.display = 'none';

    await Promise.all([getCustomers(), getPoolTables(), getBookings(), getMostUsedTable(), getTablekindsBooked()]);

    document.getElementById('bookings').innerHTML = "";
    bookings.forEach(t => {
        document.getElementById('bookings').innerHTML +=
            `<tr><td><input type="radio" name="selectBookingRadio" onclick='showUpdateBooking("${t.bookingId}","${t.startDate}","${t.endDate}","${t.customer.customerId}","${t.poolTable.tableId}")'></input></td>` +
            "</td><td>" + t.customer.name +
            "</td><td>" + formatDate(t.startDate) +
            "</td><td>" + formatDate(t.endDate) +
            "</td><td>" + t.poolTable.t_kind + " - " + t.poolTable.tableId + "" +
            `</td><td><button type="button" onclick='removeBooking(${t.bookingId})'>Delete</button></td></tr>`;;
    })

    document.getElementById('customerSelect').innerHTML = "";
    document.getElementById('customerSelectUpdate').innerHTML = "";
    customers.forEach(c => {

        document.getElementById('customerSelect').innerHTML +=
            "<option value='" + c.customerId + "'>" + c.name + "</option>";

        document.getElementById('customerSelectUpdate').innerHTML +=
            "<option value='" + c.customerId + "'>" + c.name + "</option>";
    })

    document.getElementById('poolTableSelect').innerHTML = "";
    document.getElementById('poolTableSelectUpdate').innerHTML = "";
    pooltables.forEach(t => {
        document.getElementById('poolTableSelect').innerHTML +=
            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
        document.getElementById('poolTableSelectUpdate').innerHTML +=
            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
    })
    document.getElementById('mostUsedTable').value = mostUsedTable[0].t_kind + ' - ' + mostUsedTable[0].tableId;
    }
async function displayBookingsBetweenDates() {
    document.getElementById('bookingwindow').style.display = 'flex';
    document.getElementById('pooltablewindow').style.display = 'none';
    document.getElementById('customerwindow').style.display = 'none';
    document.getElementById('updateCustomer').style.display = 'none';
    document.getElementById('updateBooking').style.display = 'none';
    document.getElementById('updatePoolTable').style.display = 'none';

    let start = document.getElementById('queryStart').value;
    let end = document.getElementById('queryEnd').value;

    await Promise.all([getBookingsBetweenTwoDates(start, end), getPoolTables(), getCustomers(), getHowManyBookingsBetweenTwoDates(start, end)]);

    document.getElementById('bookings').innerHTML = "";
    bookings.forEach(t => {
        document.getElementById('bookings').innerHTML +=
            `<tr><td><input type="radio" name="selectBookingRadio" onclick='showUpdateBooking("${t.bookingId}","${t.startDate}","${t.endDate}","${t.customer.customerId}","${t.poolTable.tableId}")'></input></td>` +
            "</td><td>" + t.customer.name +
            "</td><td>" + formatDate(t.startDate) +
            "</td><td>" + formatDate(t.endDate) +
            "</td><td>" + t.poolTable.t_kind + " - " + t.poolTable.tableId + "" +
            `</td><td><button type="button" onclick='removeBooking(${t.bookingId})'>Delete</button></td></tr>`;;
    })

    document.getElementById('customerSelect').innerHTML = "";
    document.getElementById('customerSelectUpdate').innerHTML = "";
    customers.forEach(c => {

        document.getElementById('customerSelect').innerHTML +=
            "<option value='" + c.customerId + "'>" + c.name + "</option>";

        document.getElementById('customerSelectUpdate').innerHTML +=
            "<option value='" + c.customerId + "'>" + c.name + "</option>";
    })

    document.getElementById('poolTableSelect').innerHTML = "";
    document.getElementById('poolTableSelectUpdate').innerHTML = "";
    pooltables.forEach(t => {
        document.getElementById('poolTableSelect').innerHTML +=
            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
        document.getElementById('poolTableSelectUpdate').innerHTML +=
            "<option value='" + t.tableId + "'> ID: " + t.tableId + "  Type: " + t.t_kind + "</option>";
    })

    document.getElementById('countBookings').value = numberOfBookings;
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
            displayBookings();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
async function removeBooking(id) {
    await fetch('http://localhost:7332/booking/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            displayBookings();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdateBooking(id, start, end, customerId, tableId) {
    document.getElementById('updateBooking').style.display = 'flex';
    document.getElementById('startUpdate').value = start;
    document.getElementById('endUpdate').value = end;
    document.getElementById('customerSelectUpdate').value = customerId;
    document.getElementById('poolTableSelectUpdate').value = tableId;
    bookingIdUpdate = id;
}
function UpdateBooking() {
    let startDate = document.getElementById('startUpdate').value;
    let endDate = document.getElementById('endUpdate').value;
    let selectedCustomerId = document.getElementById('customerSelectUpdate').value;
    let selectedTableId = document.getElementById('poolTableSelectUpdate').value;

    fetch('http://localhost:7332/booking', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            bookingId: bookingIdUpdate,
            startDate: startDate,
            endDate: endDate,
            customerId: selectedCustomerId,
            tableId: selectedTableId
        })
    })
        .then(data => {
            console.log(data);
            displayBookings();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('updateBooking').style.display = 'none';
}
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
//#endregion

//PoolTables
//#region PoolTables
let poolTableIdUpdate = 0;
function displayPoolTables() {
    document.getElementById('bookingwindow').style.display = 'none';
    document.getElementById('pooltablewindow').style.display = 'flex';
    document.getElementById('customerwindow').style.display = 'none';
    document.getElementById('updateCustomer').style.display = 'none';
    document.getElementById('updateBooking').style.display = 'none';
    document.getElementById('updatePoolTable').style.display = 'none';

    return getPoolTables().then(() => {

        document.getElementById('pooltables').innerHTML = "";
        pooltables.forEach(t => {
            document.getElementById('pooltables').innerHTML +=
                `<tr><td><input type="radio" name="selectPoolTableRadio" onclick='showUpdatePoolTable("${t.tableId}","${t.t_kind}")'></input></td>` +
                "</td><td>" + t.tableId +
                "</td><td>" + t.t_kind +
                `</td><td><button type="button" onclick='removePoolTable(${t.tableId})'>Delete</button></td></tr>`;;
        })
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
            displayPoolTables();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
async function removePoolTable(id) {
    await fetch('http://localhost:7332/pooltable/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            displayPoolTables();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}
function showUpdatePoolTable(id, type) {
    document.getElementById('updatePoolTable').style.display = 'flex';
    document.getElementById('typeUpdate').value = type;
    poolTableIdUpdate = id;
}
function updatePoolTable() {
    let type = document.getElementById('typeUpdate').value;

    fetch('http://localhost:7332/pooltable', {
        method: 'PUT',
        headers: {
            'Content-Type': 'application/json'
        },
        body: JSON.stringify({
            tableId: poolTableIdUpdate,
            t_kind: type
        })
    })
        .then(data => {
            console.log(data);
            return getPoolTables();
        })
        .then(() => {
            displayPoolTables();
        })
        .catch((error) => {
            console.error('Error:', error);
        });

    document.getElementById('updatePoolTable').style.display = 'none';
}
//#endregion