let starships = [];
let starshipIdToUpdate = -1;
let connection = null;
getdata();
setupSignalR();


function setupSignalR() {
    connection = new signalR.HubConnectionBuilder()
        .withUrl("http://localhost:53910/hub")
        .configureLogging(signalR.LogLevel.Information)
        .build();

    connection.on("ActorCreated", (user, message) => {
        getdata();
    });

    connection.on("ActorDeleted", (user, message) => {
        getdata();
    });

    connection.on("ActorUpdated", (user, message) => {
        getdata();
    });

    connection.onclose(async () => {
        await start();
    });
    start();


}

async function start() {
    try {
        await connection.start();
        console.log("SignalR Connected.");
    } catch (err) {
        console.log(err);
        setTimeout(start, 5000);
    }
};

async function getdata() {
    await fetch('http://localhost:53910/starship')
        .then(x => x.json())
        .then(y => {
            starships = y;
            //console.log(actors);
            display();
        });
}

function display() {
    document.getElementById('resultarea').innerHTML = "";
    starships.forEach(t => {
        document.getElementById('resultarea').innerHTML +=
            "<tr><td>" + t.id + "</td><td>"
                + t.name + "</td><td>" +
                + t.basePrice + "</td><td>" +
                + t.brandId + "</td><td>" +
                + t.weaponId + "</td><td>" +
        `<button type="button" onclick="remove(${t.id})">Delete</button>` +
        `<button type="button" onclick="showUpdate(${t.id})">Update</button>`
    });
}

function remove(id) {
    fetch('http://localhost:53910/starship/' + id, {
        method: 'DELETE',
        headers: { 'Content-Type': 'application/json', },
        body: null
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function create() {
    let name = document.getElementById('starshipname').value;
    let price = document.getElementById('starshipprice').value;
    let brandid = document.getElementById('brandid').value;
    let weaponid = document.getElementById('weaponid').value;
    fetch('http://localhost:53910/starship/', {
        method: 'POST',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { name: name, basePrice: price,brandId: brandid, weaponId: weaponid})
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });

}

function update() {    
    let name = document.getElementById('starshipname_update').value;
    let price = document.getElementById('starshipprice_update').value;
    let brandid = document.getElementById('brandid_update').value;
    let weaponid = document.getElementById('weaponid_update').value;
    fetch('http://localhost:53910/starship/', {
        method: 'PUT',
        headers: { 'Content-Type': 'application/json', },
        body: JSON.stringify(
            { id: starshipIdToUpdate, name: name, basePrice: price, brandId: brandid, weaponId: weaponid })
    })
        .then(response => response)
        .then(data => {
            console.log('Success:', data);
            getdata();
        })
        .catch((error) => { console.error('Error:', error); });
    alert("Update was succesfull")
    hideUpdate();

}

function showUpdate(id) {
    document.getElementById('starshipname_update').value = starships.find(t => t['id'] == id)['name'];
    document.getElementById('starshipprice_update').value = starships.find(t => t['id'] == id)['basePrice'];
    document.getElementById('brandid_update').value = starships.find(t => t['id'] == id)['brandId'];
    document.getElementById('weaponid_update').value = starships.find(t => t['id'] == id)['weaponId'];
    document.getElementById('formdiv').style.display = 'none';
    document.getElementById('updateformdiv').style.display = 'flex';
    starshipIdToUpdate = id;
    
}

function hideUpdate() {
    document.getElementById('starshipname_update').value = null;
    document.getElementById('starshipprice_update').value = null;
    document.getElementById('brandid_update').value = null;
    document.getElementById('weaponid_update').value = null;
    document.getElementById('updateformdiv').style.display = 'none';
    document.getElementById('formdiv').style.display = 'flex';
}

