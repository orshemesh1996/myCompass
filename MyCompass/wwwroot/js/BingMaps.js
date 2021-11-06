var cord = {};

function initCordinates(lat, lon) {
    cord.lat = lat;
    cord.lon = lon;
}

function getMap() {
    const mapElement = document.getElementById("map");
    var map = new Microsoft.Maps.Map(mapElement, { center: new Microsoft.Maps.Location(cord.lat, cord.lon), zoom: 12 });
    var center = map.getCenter();
    var pin = new Microsoft.Maps.Pushpin(center, { icon: 'https://www.bingmapsportal.com/Content/images/poi_custom.png' });
    map.entities.push(pin);
}
