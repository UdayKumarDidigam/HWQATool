/// <reference path="team.service.js" />
app.service("gradeService", function ($http) {
    var service = {};
    service.get = getGrades;
    return service;

    function getGrades(callback) {
        debugger;
        $http.get("http://localhost:2864/api/Grades").then(function (response) {
            debugger;
            callback(response.data);
        }, function (error) {

        });

    }
});