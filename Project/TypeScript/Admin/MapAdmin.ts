/// <reference path="../../Scripts/typings/jquery/jquery.d.ts" />
/// <reference path="../../Scripts/typings/googlemaps/google.maps.d.ts" />


class MapAdmin {

    // #region Constructor

    public constructor() {

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
            if (status.toString() === MapAdmin.STATUS_OK) {
                self._map.setCenter(results[0].geometry.location);
                self._currentCity = cityName;
            } else if (status.toString() === MapAdmin.STATUS_ZERO_RESULTS) {
                alert(MapAdmin.ERROR_MESSAGE_INCORRECT);
            } else {
                alert(MapAdmin.ERROR_MESSAGE_SERVER_ERROR);
            }
        });
    }

    public GetCities() {
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
                } else {
                    $('#listOFCities')
                        .append($("<option></option>")
                            .text(key));
                }
            });
        }).fail(function (error) {
            console.log(error);
        });
    }

    // #endregion

    // #region Static fields

    private static STATUS_OK: string = 'OK';

    private static STATUS_ZERO_RESULTS: string = 'ZERO_RESULTS';

    private static ERROR_MESSAGE_INCORRECT: string = 'Incorrect city!';

    private static ERROR_MESSAGE_SERVER_ERROR: string = 'Server error try later!';

    private static DEFAULT_CITY = 'Taganrog';

    private static DEFAULT_COORDINATES: google.maps.LatLng = new google.maps.LatLng(47.23720460839429, 38.86011685767835);

    private static DEFAULT_ZOOM: number = 13;

    private static MAX_ZOOM: number = 18;

    private static MIN_ZOON: number = 12;

    // #endregion

    // #region Private fields

    // The map.
    private _map: google.maps.Map;

    // The marker.
    private _startMarker: google.maps.Marker;

    // Geocoder service.
    private _geocoder: google.maps.Geocoder;

    private _currentCity: string = MapAdmin.DEFAULT_CITY;

    // #endregion
}

let mapAdmin: MapAdmin = new MapAdmin();



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