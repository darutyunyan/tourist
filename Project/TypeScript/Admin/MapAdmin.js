/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../Scripts/typings/googlemaps/google.maps.d.ts" />
var MapAdmin = /** @class */ (function () {
    // #region Constructor
    function MapAdmin() {
        this._currentCity = MapAdmin.DEFAULT_CITY;
        var self = this;
        // Init map.
        this._map = new google.maps.Map(document.getElementById('mapAdmin'), {
            center: MapAdmin.DEFAULT_COORDINATES,
            zoom: MapAdmin.DEFAULT_ZOOM,
            maxZoom: MapAdmin.MAX_ZOOM,
            minZoom: MapAdmin.MIN_ZOON
        });
        // Init geocoder service.
        this._geocoder = new google.maps.Geocoder();
        // Add listener by click map.
        this._map.addListener('click', function (e) {
            self.addMarker(e.latLng);
        });
        this.GetCities();
    }
    // #endregion
    // #region Public actions
    // Adds a marker to the map.
    MapAdmin.prototype.addMarker = function (latLng) {
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
    MapAdmin.prototype.setCenterMapByAddress = function (cityName) {
        var self = this;
        this._geocoder.geocode({ 'address': cityName }, function (results, status) {
            if (status.toString() === MapAdmin.STATUS_OK) {
                self._map.setCenter(results[0].geometry.location);
                self._currentCity = cityName;
            }
            else if (status.toString() === MapAdmin.STATUS_ZERO_RESULTS) {
                alert(MapAdmin.ERROR_MESSAGE_INCORRECT);
            }
            else {
                alert(MapAdmin.ERROR_MESSAGE_SERVER_ERROR);
            }
        });
    };
    MapAdmin.prototype.GetCities = function () {
        $.ajax({
            url: 'Admin/GetCities',
            type: 'GET'
        }).done(function (data) {
            $.each(data, function (value, key) {
                if (key == MapAdmin.DEFAULT_CITY) {
                    $('#listOFCities')
                        .append($("<option></option>")
                        .attr('selected', 'selected')
                        .text(key));
                }
                else {
                    $('#listOFCities')
                        .append($("<option></option>")
                        .text(key));
                }
            });
        }).fail(function (error) {
            console.log(error);
        });
    };
    // #endregion
    // #region Static fields
    MapAdmin.STATUS_OK = 'OK';
    MapAdmin.STATUS_ZERO_RESULTS = 'ZERO_RESULTS';
    MapAdmin.ERROR_MESSAGE_INCORRECT = 'Incorrect city!';
    MapAdmin.ERROR_MESSAGE_SERVER_ERROR = 'Server error try later!';
    MapAdmin.DEFAULT_CITY = 'Taganrog';
    MapAdmin.DEFAULT_COORDINATES = new google.maps.LatLng(47.23720460839429, 38.86011685767835);
    MapAdmin.DEFAULT_ZOOM = 13;
    MapAdmin.MAX_ZOOM = 18;
    MapAdmin.MIN_ZOON = 12;
    return MapAdmin;
}());
var mapAdmin = new MapAdmin();
$('#listOFCities').change(function () {
    // Get entered city name.
    var cityName = $(this).find(":checked").val();
    // Centered map by city name.
    mapAdmin.setCenterMapByAddress(cityName);
});
$('#search').click(function () {
    // Get input city name.
    var cityName = $('#inputCity').val();
    // Centered map by city name.
    mapAdmin.setCenterMapByAddress(cityName);
});
//# sourceMappingURL=MapAdmin.js.map