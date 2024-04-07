fetch('http://localhost:7332/Booking')
    .then(x => x.json)
    .then(y => console.log(y));