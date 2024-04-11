﻿
// SignalR
// #region SignalR
let connection3 = null;

setupSignalR();

function setupSignalR() {
    connection3 = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:7332/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection3.on("PoolTableCreated", (user, message) => {
        return getPoolTables()
            .then(() => displayPoolTables());
    });
    connection3.on("PoolTableDeleted", (user, message) => {
        return getPoolTables()
            .then(() => displayPoolTables());
    });
    connection3.on("PoolTableUpdated", (user, message) => {
        return getPoolTables()
            .then(() => displayPoolTables());
    });

    connection3.onclose
        (async () => {
            await start();
        });
    start();
}
async function start() {
    try {
        await connection3.start();
        console.log("SignalR Connected.(PoolTable)");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};
//#endregion

let pooltables = [];

getPoolTables();

async function getPoolTables() {
    await fetch('http://localhost:7332/pooltable')
        .then(response => response.json())
        .then(data => {
            pooltables = data;
            console.log(pooltables);
        });
}
function displayPoolTables() {
    document.getElementById('bookingwindow').style.display = 'none'; // Hide bookingwindow
    document.getElementById('pooltablewindow').style.display = 'flex'; // Hide pooltablewindow
    document.getElementById('customerwindow').style.display = 'none'; // Show customerwindow

    document.getElementById('pooltables').innerHTML = "";
    pooltables.forEach(t => {
        document.getElementById('pooltables').innerHTML +=
            `<tr><td><input type="radio" name="selectPoolTableRadio" onclick="showUpdatePoolTable()"></input></td>` +
            "</td><td>" + t.tableId +
            "</td><td>" + t.t_kind +
            `</td><td><button type="button" onclick='removePoolTable(${t.tableId})'>Delete</button></td></tr>`;;
    })
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

async function removePoolTable(id) {
    await fetch('http://localhost:7332/pooltable/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json' },
        body: null
    })
        .then(data => {
            console.log(data);
            getBookings();
            return getPoolTables();
        })
        .then(() => {
            displayPoolTables();
        })
        .catch((error) => {
            console.error('Error:', error);
        });
}

function showUpdatePoolTable() {
    document.getElementById('updatePoolTable').style.display = 'flex';

}