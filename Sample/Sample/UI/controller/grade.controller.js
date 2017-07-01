app.controller("gradeController", function ($scope, gradeService, $http) {
    gradeService.get(function (data) {
        $scope.grades = data;
    });


    debugger;
  


    $scope.defaults = function () {
        $scope.grade = {
            id: 0,
            name: "",
            samplePercentage: "",
            teamId: 0

        }

    }

    $scope.addGrade = function () {
        if ($scope.grade.id != 0) {
            $http.put("http://localhost:2864/api/Grades" + $scope.grade.id, $scope.grade).then(function (response) {
                debugger;
            }, function (error) {

            });
        }
        else {
            $http.post("http://localhost:2864/api/Grades", $scope.grade).then(function (response) {
                $scope.grades.push($scope.grade);
            }, function (error) {

            });
        }
    }

    $scope.deleteGrade = function (index) {
        $scope.grade = $scope.grades[index];
        $http.delete("http://localhost:2864/api/Grades/" + $scope.grade.id).then(function (response) {
            debugger;
            $scope.grades.splice(index, 1);
        }, function (error) {
        });

    }



    $scope.editGrade = function () {
        $scope.grade= $scope.grades[index];
    }
}
);