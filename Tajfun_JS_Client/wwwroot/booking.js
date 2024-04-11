
//SignalR
// #region SignalR
let connection1 = null;

setupSignalR();

function setupSignalR() {
    connection1 = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:7332/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection1.on("BookingCreated", (user, message) => {
        return getBookings()
            .then(() => displayBookings());
    });
    connection1.on("BookingDeleted", (user, message) => {
        return getBookings()
            .then(() => displayBookings());
    });
    connection1.on("BookingUpdated", (user, message) => {
        return getBookings()
            .then(() => displayBookings());
    });

    connection1.onclose
        (async () => {
            await start();
        });
    start();
}
async function start() {
    try {
        await connection1.start();
        console.log("SignalR Connected.(Booking)");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

//#endregion

let bookings = [];

getBookings();

async function getBookings() {
    await fetch('http://localhost:7332/booking')
        .then(response => response.json())
        .then(data => {
            bookings = data;
            console.log(bookings);
        });
}
function displayBookings() {
    document.getElementById('bookingwindow').style.display = 'flex'; // Hide bookingwindow
    document.getElementById('pooltablewindow').style.display = 'none'; // Hide pooltablewindow
    document.getElementById('customerwindow').style.display = 'none'; // Show customerwindow

    document.getElementById('bookings').innerHTML = "";
    bookings.forEach(t => {
        document.getElementById('bookings').innerHTML +=
            `<tr><td><input type="radio" name="selectBookingRadio" onclick="showUpdateBooking()"></input></td>` +
            "</td><td>" + t.customer.name +
            "</td><td>" + formatDate(t.startDate) +
            "</td><td>" + formatDate(t.endDate) +
            "</td><td>" + t.poolTable.t_kind +
            `</td><td><button type="button" onclick='removeBooking(${t.bookingId})'>Delete</button></td></tr>`;;
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

async function removeBooking(id) {
    await fetch('http://localhost:7332/booking/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            return getBookings();
        })
        .then(() => {
            displayBookings();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showUpdateBooking() {
    document.getElementById('updateBooking').style.display = 'flex';
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