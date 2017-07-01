/// <reference path="platform.controller.js" />
/// <reference path="platform.controller.js" />
app.controller("platformController", function ($scope,platformService, $http) {
  
    platformService.get(function (data) {
        $scope.platforms = data;
    });


    debugger;
  
    $scope.defaults = function () {
        debugger;
        $scope.platform = {
            id: 0,
            name: "",
            teamId: ""
        }
    }
    $scope.addPlatform = function () {
        debugger;
        if ($scope.platform.id != 0) {
            $http.put("http://localhost:2864/api/Platforms" + $scope.platform.id, $scope.platform).then(function (response) {
                debugger;

            }, function (error) {

            });
        }
        else {
            $http.post("http://localhost:2864/api/Platforms", $scope.platform).then(function (response) {
            },
            function (error) {
                $scope.platforms.push($scope.platform);
            });
        }
    }
    $scope.deletePlatform = function (index) {
        $scope.platform = $scope.platforms[index];
        $http.delete("http://localhost:2864/api/Platforms/" + $scope.platform.id).then(function (response) {
            debugger;
            $scope.platforms.splice(index, 1);
        }, function (error) {
        });

    }


    $scope.editPlatform = function (index) {
        $scope.platform = $scope.platforms[index];
    }
});