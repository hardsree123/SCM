var PageLoaderActivity = {
    SHOW: "show",
    HIDE: "hide",
};
// load the csv test and training datasets, generate the require objects to display them on map.
var map = {};
CommonJs = {
    //call before ajax start and end with toggle indicator show and hide
    SetPageLoader: function (toggleIndicator) {
        $body = $("body");
        if (toggleIndicator) {
            if (toggleIndicator === "show") {
                $body.addClass("loading");
            }
            else if (toggleIndicator === "hide") {
                $body.removeClass("loading");
            }
        }
    },
    buildMap: function () {
        var osmUrl = 'http://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png',
            osmAttribution = 'Map data © <a href="http://openstreetmap.org">OpenStreetMap</a> contributors,' +
                ' <a href="http://creativecommons.org/licenses/by-sa/2.0/">CC-BY-SA</a>',
            osmLayer = new L.TileLayer(osmUrl, { maxZoom: 18, attribution: osmAttribution });
        map = new L.Map('map');
        map.setView(new L.LatLng(11.966065, 75.395162), 9);
        map.addLayer(osmLayer);
        var validatorsLayer = new OsmJs.Weather.LeafletLayer({ lang: 'en' });
        map.addLayer(validatorsLayer);
    },
    buildNewMap: function () {
        map = L.DomUtil.get('map');
        if (map != null) {
            map._leaflet_id = null;
            map = L.map('map').setView([11.966065, 75.395162], 13);
            // add the OpenStreetMap tiles
            L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
                maxZoom: 18,
                attribution: '&copy; <a href="https://openstreetmap.org/copyright">OpenStreetMap contributors</a>'
            }).addTo(map);
            
        }
    }

}

//var mymap = L.map('map').setView([11.966065, 75.395162], 13);
//// add the OpenStreetMap tiles
//L.tileLayer('https://{s}.tile.openstreetmap.org/{z}/{x}/{y}.png', {
//    maxZoom: 18,
//    attribution: '&copy; <a href="https://openstreetmap.org/copyright">OpenStreetMap contributors</a>'
//}).addTo(mymap);
