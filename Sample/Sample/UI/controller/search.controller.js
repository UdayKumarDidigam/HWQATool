app.controller("searchController", function ($scope, $http) {
    debugger;
    $http.get("http://localhost:5883/api/Teams").then(function (response) {
        debugger
        $scope.teams = response.data;
    }, function (error) {

    });
   $http.get("http://localhost:5883/api/Clients").then(function (response) {
       $scope.clients = response.data;
   }, function (error) {

   });

   $http.get("http://localhost:5883/api/Audits").then(function (response) {
       $scope.audits = response.data;
   }, function (error) {

   });

   $http.get("http://localhost:5883/api/Tasks").then(function (response) {
       $scope.tasks = response.data;
   }, function (error) {

   });

   $http.get("http://localhost:5883/api/Platforms").then(function (response) {
       $scope.platforms = response.data;
   }, function (error) {

   });




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
