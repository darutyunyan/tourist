/// <reference path="../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../Scripts/typings/googlemaps/google.maps.d.ts" />

class MapData {

    // #region Public actions

    static GetCities(callback) {
        $.ajax({
            url: 'Map/GetCities',
            type: 'GET'
        }).done(function (data) {
            callback(data);
        }).fail(function (error) {
            //TODO
        });
    }

    public setCenterMapByAddress(address): void {

    }

    public getAddressByCoordinates(latLng, callback) {

    }

    // #endregion

    // #region Static fields

    // #endregion

    // #region Private fields

    // #endregion
}

class MapTourist {

    // #region Constructor

    public constructor() {

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

        MapData.GetCities(function (data) {
            $.each(data, function (value, key) {
                if (key == MapTourist.DEFAULT_CITY) {
                    $('#selectCity')
                        .append($("<option></option>")
                            .attr('selected', 'selected')
                            .text(key));
                } else {
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
    public addMarker(latLng: google.maps.LatLng): void {

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
    }

    public setCenterMapByAddress(cityName): void {
        var self = this;
        this._geocoder.geocode({ 'address': cityName }, function (results, status) {
            if (status.toString() === MapTourist.STATUS_OK) {
                self._map.setCenter(results[0].geometry.location);
                self._currentCity = cityName;
            } else if (status.toString() === MapTourist.STATUS_ZERO_RESULTS) {
                alert(MapTourist.ERROR_MESSAGE_INCORRECT);
            } else {
                alert(MapTourist.ERROR_MESSAGE_SERVER_ERROR);
            }
        });
    }

    public getAddressByCoordinates(latLng, callback) {
        let address: string = null;
        this._geocoder.geocode({ 'location': latLng }, function (results, status) {
            if (status.toString() === 'OK') {
                if (results[0]) {
                    callback(results[0].formatted_address);
                }
            }
        });
    }

    // #endregion

    // #region Static fields

    static STATUS_OK: string = 'OK';

    static STATUS_ZERO_RESULTS: string = 'ZERO_RESULTS';

    static ERROR_MESSAGE_INCORRECT: string = 'Incorrect city!';

    static ERROR_MESSAGE_SERVER_ERROR: string = 'Server error try later!';

    static DEFAULT_CITY = 'Taganrog';

    static DEFAULT_COORDINATES: google.maps.LatLng = new google.maps.LatLng(47.23720460839429, 38.86011685767835);

    static DEFAULT_ZOOM: number = 13;

    static MAX_ZOOM: number = 18;

    static MIN_ZOON: number = 12;

    // #endregion

    // #region Private fields

    // The map.
    private _map: google.maps.Map;

    // The marker.
    private _startMarker: google.maps.Marker;

    // Geocoder service.
    private _geocoder: google.maps.Geocoder;

    private _currentCity: string = MapTourist.DEFAULT_CITY;

    // #endregion
}

let mapTourist: MapTourist = new MapTourist();

$('#selectCity').change(function () {
    // Get entered address.
    var cityName = $(this).find(":checked").val();

    // Centered map by address.
    mapTourist.setCenterMapByAddress(cityName);
});