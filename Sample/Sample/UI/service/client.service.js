app.service("clientService", function ($http) {
    var service = {};
    service.get = getClients;
    return service;

    function getClients(callback) {
        debugger;
        $http.get("http://localhost:2864/api/Clients").then(function (response) {
            debugger;
            callback(response.data);
        }, function (error) {

        });

    }
});