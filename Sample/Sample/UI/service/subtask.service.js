/// <reference path="team.service.js" />
app.service("subtaskService", function ($http) {
    var service = {};
    service.get = getSubTasks;
    return service;

    function getTeams(callback) {
        debugger;
        $http.get("http://localhost:2864/api/SubTasks").then(function (response) {
            debugger;
            callback(response.data);
        }, function (error) {

        });

    }
});