
//SignalR
// #region SignalR
let connection2 = null;

setupSignalR();

function setupSignalR() {
    connection2 = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:7332/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection2.on("CustomerCreated", (user, message) => {
        return getCustomers()
            .then(() => displayCustomers());
    });
    connection2.on("CustomerDeleted", (user, message) => {
        return getCustomers()
            .then(() => displayCustomers());
    });
    connection2.on("CustomerUpdated", (user, message) => {
        return getCustomers()
            .then(() => displayCustomers());
    });

    connection2.onclose
        (async () => {
            await start();
        });
    start();
}
async function start() {
    try {
        await connection2.start();
        console.log("SignalR Connected.(Customer)");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

//#endregion

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
            `<tr><td><input type="radio" name="selectCustomerRadio" onclick='showUpdateCustomer("${t.name}","${t.phone}","${t.email}")'></input></td>` +
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
function showUpdateCustomer(name, phone, email) {
    document.getElementById('updateCustomer').style.display = 'flex';
    document.getElementById('nameUpdate').value = name;
    document.getElementById('phoneUpdate').value = phone;
    document.getElementById('emailUpdate').value = email;
}
function updateCustomer() {
    
}