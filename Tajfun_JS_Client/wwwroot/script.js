

let customerslist = [];
let pooltableslist = [];
let bookingslist = [];

fetch('http://localhost:7332/customer')
    .then(response => response.json())
    .then(data => {
        customerslist = data;
        console.log(customerslist);
    });

fetch('http://localhost:7332/pooltable')
    .then(response => response.json())
    .then(data => {
        pooltableslist = data;
        console.log(pooltableslist);
    });

fetch('http://localhost:7332/booking')
    .then(response => response.json())
    .then(data => {
        bookingslist = data;
        console.log(bookingslist);
    });

