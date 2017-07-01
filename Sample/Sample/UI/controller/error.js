app.controller("errorController", function ($scope, errorService, $http) {


    errorService.get(function (data) {
        //debugger;
        $scope.errors = data;
    });

    /* debugger;
     $http.get("http://localhost:5883/api/Errors").then(function (response) {
         debugger;
         $scope.errors = response.data;
     }, function (error) {
 
     });*/

    $scope.defaults = function () {
        debugger;
        $scope.error1 = {
            id: 0,
            name: "",
            description: "",
            weightage: "",
            taskId: ""
        }
    }



    $scope.addError = function () {
        if ($scope.error1.id != 0) {
            $http.put("http://localhost:2864/api/Errors/" + $scope.error1.id, $scope.error1).then(function (response) {
                debugger;

            }, function (error) {
            });

        } else {
            $http.post("http://localhost:2864/api/Errors", $scope.error1).then(function (response) {
                $scope.errors.push($scope.error1);
            }, function (error) {
            });
        }
    }

    $scope.deleteError = function (index) {
        $scope.error1 = $scope.errors[index];
        $http.delete("http://localhost:2864/api/Errors/" + $scope.error1.index).then(function (response) {
            debugger;
            $scope.errors.splice(index, 1);
        }, function (error) {
        });
    }

    $scope.editError = function (index) {
        $scope.error1 = $scope.errors[index];
        //$scope.error1.id = index;
    }
});
