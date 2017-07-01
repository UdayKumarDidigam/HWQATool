app.controller("taskController", function ($scope, $http) {

    debugger;
    $http.get("http://localhost:2864/api/Tasks").then(function (response) {
        debugger;
        $scope.tasks = response.data;
    }, function (error) {

    });


    $scope.defaults = function () {
        $scope.task= {
            id: 0,
            name: "",
            samplePercentage: "",
            teamId:0

        }

    }

    $scope.addTask = function () {
        if ($scope.task.id != 0) {
            $http.put("http://localhost:2864/api/Tasks" + $scope.task.id, $scope.task).then(function (response) {
                debugger;
            }, function (error) {

            });
        }
        else {
            $http.post("http://localhost:2864/api/Tasks", $scope.task).then(function (response) {
                $scope.tasks.push($scope.task);
            }, function (error) {

            });
        }
    }

    $scope.deleteTask = function (index) {
        $scope.task = $scope.tasks[index];
        $http.delete("http://localhost:2864/api/Tasks/" + $scope.task.id).then(function (response) {
            debugger;
            $scope.tasks.splice(index, 1);
        }, function (error) {
        });

    }



    $scope.editTask = function () {
        if ($scope.task.id != 0) {
            $http.put("http://localhost:2864/api/Tasks" + $scope.task.id, $scope.task).then(function (response) {
                debugger;
            }, function (error) {

            });
        }

    }
}
);