$(document).ready(function () {
    var mymap = L.DomUtil.get('map');
    if (mymap != null) {
        mymap._leaflet_id = null;
    }
    mymap = L.map('map').setView([11.966065, 75.395162], 13);
    // add the OpenStreetMap tiles
    L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
        maxZoom: 18,
        attribution: '&copy; <a href="https://openstreetmap.org/copyright">OpenStreetMap contributors</a>'
    }).addTo(mymap);

    // show the scale bar on the lower left corner
    L.control.scale().addTo(mymap);
    $('.leaflet-container').css('cursor', 'crosshair');
    var createMarker = {}
    mymap.on('click', function (e) {
        $("#Lat").val(e.latlng.lat);
        $("#Long").val(e.latlng.lng);
        if (createMarker != undefined) {
            mymap.removeLayer(createMarker);
        };
        createMarker = new L.Marker([e.latlng.lat, e.latlng.lng]).addTo(mymap);
    });
});