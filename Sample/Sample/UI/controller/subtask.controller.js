app.controller("subtaskController", function ($scope,subtaskService, $http) {

    subtaskService.get(function (data) {
        $scope.subtasks = data;
    });
    debugger;
  

    $scope.defaults = function () {
        $scope.subtask = {
            id: 0,
            name: "",
            taskId: 0

        }

    }

    $scope.addSubTask = function () {
        debugger;
        if ($scope.subtask.id != 0) {
            $http.put("http://localhost:2864/api/SubTasks" + $scope.subtask.id, $scope.subtask).then(function (response) {
                debugger;
            }, function (error) {

            });
        }
        else {
            $http.post("http://localhost:2864/api/SubTasks", $scope.subtask).then(function (response) {
                $scope.subtasks.push($scope.subtask);
            }, function (error) {

            });
        }
    }

    $scope.deleteSubTask = function (index) {
        debugger;
        $scope.subtask = $scope.subtasks[index];
        $http.delete("http://localhost:2864/api/SubTasks/" + $scope.subtask.id).then(function (response) {
            debugger;
            $scope.subtasks.splice(index, 1);
        }, function (error) {
        });

    }



    $scope.editSubTask = function () {
        $scope.subtask = $scope.subtasks[index];

    }
}
);