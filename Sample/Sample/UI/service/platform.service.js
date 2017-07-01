/// <reference path="platform.service.js" />
app.service("platformService", function ($http) {
    var service = {};
    service.get = getPlatforms;
    return service;

    function getPlatforms(callback) {
        debugger;
        $http.get("http://localhost:2864/api/Platforms").then(function (response) {
            debugger;
            callback(response.data);
        }, function (error) {

        });

    }
});