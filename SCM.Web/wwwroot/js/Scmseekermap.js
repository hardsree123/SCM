// load the csv test and training datasets, generate the require objects to display them on map.
var mymap = L.map('map').setView([11.966065, 75.395162], 13);
// add the OpenStreetMap tiles
L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
    maxZoom: 18,
    attribution: '&copy; <a href="https://openstreetmap.org/copyright">OpenStreetMap contributors</a>'
}).addTo(mymap);

// show the scale bar on the lower left corner
L.control.scale().addTo(mymap);

function MarkonMap(data) {
    var createMarker = {}
    data.forEach(cc => {
        createMarker = new L.Marker([cc.latitude, cc.longitude]).bindPopup(cc.name).addTo(mymap);
    });
}


function DisplayOnMap() {
    $.ajax({
        type: "GET",
        url: "/api/Seeker",
        contentType: 'application/json',
        secure: true,
        headers: {
            'Access-Control-Allow-Origin': 'true',
        },
        beforeSend: function (xhr) {
            xhr.setRequestHeader("Authorization", "Basic " + btoa(""));
        },
        success: function (data) {
            MarkonMap(data);
        }
    });
}



$(document).ready(function () {
    // initialize Leaflet
    DisplayOnMap();

});