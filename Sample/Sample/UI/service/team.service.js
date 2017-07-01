/// <reference path="team.service.js" />
app.service("teamService", function ($http) {
    var service = {};
    service.get = getTeams;
    return service;

    function getTeams(callback) {
        debugger;
        $http.get("http://localhost:2864/api/Teams").then(function (response) {
            debugger;
            callback(response.data);
        }, function (error) {

        });

    }
});