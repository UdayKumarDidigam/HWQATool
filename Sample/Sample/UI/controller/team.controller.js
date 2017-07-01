/// <reference path="team.controller.js" />
/// <reference path="team.controller.js" />
app.controller("teamController", function ($scope, teamService,$http) {
    
    teamService.get(function (data) {
        $scope.teams = data;
    });





    //  $scope.teams = [
    //    {
    //         name: 'Team1',
    //        qu
    //    {alityBenchMark: 99
    //    },
    //       name: 'Team2',
    //       qualityBenchMark: 98
    //    },
    //    {
    //        name: 'Team3',
    //        qualityBenchMark: 97
    //    }
    //  ];

    debugger;
    $http.get("http://localhost:2864/api/Teams").then(function (response) {
        debugger;
        $scope.teams = response.data;
    }, function (error) {

    });


    $scope.defaults = function () {
        $scope.team = {
            id: 0,
            name:"",
            qualityBenchMark:""

        }

    }

    $scope.addTeam = function () {
        if ($scope.team.id!=0) {
            $http.put("http://localhost:2864/api/Teams/" + $scope.team.id, $scope.team).then(function (response) {
                debugger;
            }, function (error) {

            });
        }
        else {
            $http.post("http://localhost:2864/api/Teams" , $scope.team).then(function (response) {
                $scope.teams.push($scope.team);
            }, function (error) {

            });
        }
    }

    $scope.deleteTeam = function (index) {
        $scope.team = $scope.teams[index];
        $http.delete("http://localhost:2864/api/Teams/" + $scope.team.id).then(function (response) {
            debugger;
            $scope.teams.splice(index, 1);
        }, function (error) {
        });

    }

  

    $scope.editTeam = function (index) {
        debugger;
        $scope.team= $scope.teams[index];
       
    }

}

);