app.controller("searchController", function ($scope, $http) {
  /* $http.get("http://localhost:5883/api/Teams").then(function (response) {
        $scope.results = response.data;
    }, function (error) {

    });         */


    $scope.results = [
        {
                auditNo          :  7.32075E+19,
                processDate      :  '4/15/16',
                auditDate        :  '4/16/16',
                client           :  'Stamford Health System',
                processor        :  'Deepa Dsouza',
                auditor          :  'Shalni Dabburi',
                type             :  'Internal Audit',
                status           :  'Hold',
                error            :  '1-0-approved the dep'

           
        }
    ];

});
