app.controller("clientController", function ($scope,clientService, $http) {

    
        clientService.get(function (data) {
            $scope.clients = data;
        });


   

    $scope.defaults = function () {
        debugger;
        $scope.client = {
            id:0,
            name: "",
            teamId: 4,
            isKeyClient: "",
            samplePercentage:"",
           isActive:""
        }
    }

    $scope.addClient = function () {
        if ($scope.client.id != 0) {
            debugger;
            $http.put("http://localhost:2864/api/Clients/" + $scope.client.id, $scope.client).then(function (response) {
                debugger;
                //$scope.clients = $scope.client;
            }, function (error) {
            });

        } else {
            debugger;
            $http.post("http://localhost:2864/api/Clients", $scope.client).then(function (response) {
                $scope.clients.push($scope.client);
            }, function (error) {
            });
        }
    }

    $scope.deleteClient= function (index) {
        $scope.client = $scope.clients[index];
        $http.delete("http://localhost:2864/api/Clients/" + $scope.client.index).then(function (response) {
            debugger;
            $scope.clients.splice(index, 1);
        }, function (error) {
        });
    }

    $scope.editClient = function (index) {
        $scope.client = $scope.clients[index];
        $scope.client.id = index;
    }
}

);