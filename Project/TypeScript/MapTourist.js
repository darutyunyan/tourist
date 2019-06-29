/// <reference path="../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../Scripts/typings/googlemaps/google.maps.d.ts" />
var MapData = /** @class */ (function () {
    function MapData() {
    }
    // #region Public actions
    MapData.GetCities = function (callback) {
        $.ajax({
            url: 'Map/GetCities',
            type: 'GET'
        }).done(function (data) {
            callback(data);
        }).fail(function (error) {
        });
    };
    MapData.prototype.setCenterMapByAddress = function () {
        alert('qwe');
    };
    return MapData;
}());
var MapTourist = /** @class */ (function () {
    // #region Constructor
    function MapTourist() {
        this._currentCity = MapTourist.DEFAULT_CITY;
        var self = this;
        // Init map.
        this._map = new google.maps.Map(document.getElementById('map'), {
            center: MapTourist.DEFAULT_COORDINATES,
            zoom: MapTourist.DEFAULT_ZOOM,
            maxZoom: MapTourist.MAX_ZOOM,
            minZoom: MapTourist.MIN_ZOON
        });
        // Init geocoder service.
        this._geocoder = new google.maps.Geocoder();
        // Add listener by click map.
        this._map.addListener('click', function (e) {
            self.addMarker(e.latLng);
        });
        //// Set cities in combobox.
        MapData.GetCities(function (data) {
            $.each(data, function (value, key) {
                if (key == MapTourist.DEFAULT_CITY) {
                    $('#selectCity')
                        .append($("<option></option>")
                        .attr('selected', 'selected')
                        .text(key));
                }
                else {
                    $('#selectCity')
                        .append($("<option></option>")
                        .text(key));
                }
            });
        });
    }
    // #endregion
    // #region Public actions
    // Adds a marker to the map.
    MapTourist.prototype.addMarker = function (latLng) {
        // Remove the marker if it is.
        if (this._startMarker != null) {
            this._startMarker.setMap(null);
            this._startMarker = null;
        }
        // Add the marker.
        this._startMarker = new google.maps.Marker({
            position: latLng,
            map: this._map,
            animation: google.maps.Animation.DROP
        });
    };
    MapTourist.prototype.setCenterMapByAddress = function (cityName) {
        var self = this;
        this._geocoder.geocode({ 'address': cityName }, function (results, status) {
            if (status.toString() === MapTourist.STATUS_OK) {
                self._map.setCenter(results[0].geometry.location);
                self._currentCity = cityName;
            }
            else if (status.toString() === MapTourist.STATUS_ZERO_RESULTS) {
                alert(MapTourist.ERROR_MESSAGE_INCORRECT);
            }
            else {
                alert(MapTourist.ERROR_MESSAGE_SERVER_ERROR);
            }
        });
    };
    MapTourist.prototype.getAddressByCoordinates = function (latLng, callback) {
        var address = null;
        this._geocoder.geocode({ 'location': latLng }, function (results, status) {
            if (status.toString() === 'OK') {
                if (results[0]) {
                    callback(results[0].formatted_address);
                }
            }
        });
    };
    // #endregion
    // #region Static fields
    MapTourist.STATUS_OK = 'OK';
    MapTourist.STATUS_ZERO_RESULTS = 'ZERO_RESULTS';
    MapTourist.ERROR_MESSAGE_INCORRECT = 'Incorrect city!';
    MapTourist.ERROR_MESSAGE_SERVER_ERROR = 'Server error try later!';
    MapTourist.DEFAULT_CITY = 'Taganrog';
    MapTourist.DEFAULT_COORDINATES = new google.maps.LatLng(47.23720460839429, 38.86011685767835);
    MapTourist.DEFAULT_ZOOM = 13;
    MapTourist.MAX_ZOOM = 18;
    MapTourist.MIN_ZOON = 12;
    return MapTourist;
}());
var mapTourist = new MapTourist();
$('#selectCity').change(function () {
    // Get entered address.
    var cityName = $(this).find(":checked").val();
    // Centered map by address.
    mapTourist.setCenterMapByAddress(cityName);
});
//# sourceMappingURL=MapTourist.js.map