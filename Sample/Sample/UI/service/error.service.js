app.service("errorService", function ($http) {
    var service = {};
    service.get = getErrors;
    return service;

    function getErrors(callback) {
        debugger;
        $http.get("http://localhost:2864/api/Errors").then(function (response) {
            debugger;
            callback(response.data);
        }, function (error) {

        });

    }
});