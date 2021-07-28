var geocoder;
var map;
function initialize() {
  geocoder = new google.maps.Geocoder();
  var mapOptions = {
    zoom: 16,
  }
  map = new google.maps.Map(document.getElementById("map-canvas"), mapOptions);
}

function codeAddress() {

  for(var i = 0; i < address.length; i++){

    geocoder.geocode( { 'address': address[i]}, function(results, status) {

      if (status == google.maps.GeocoderStatus.OK) {

        map.setCenter(results[0].geometry.location);

        str = String(results[0].geometry.location);
        var comma = str.indexOf(",");

        lat = str.substr(1,comma -1);
        lng = str.substr(comma+1, str.length-comma-2);

        var latlng = new google.maps.LatLng(lat,lng);

        var image = 'http://icons.iconarchive.com/icons/pelfusion/long-shadow-media/32/Maps-Pin-Place-icon.png';

        var marker = new google.maps.Marker({
            map: map,
            position: latlng,
            icon: image,
            title: results[0].address_components[1].long_name
        });

      } else {
        //alert("Geocode was not successful for the following reason: " + status);
      }
    });        
  }
}