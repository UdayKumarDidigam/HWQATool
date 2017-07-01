app.config(function ($routeProvider) {
    $routeProvider
    .when("/", {
        templateUrl: "view/platform.view.html",
        controller: "platformController"
    })
    .when("/team", {
        templateUrl: "view/team.view.html",
        controller: "teamController"
    })
    .when("/platform", {
             templateUrl: "view/platform.view.html",
             controller: "platformController"
         })
    .when("/task", {
        templateUrl: "view/task.view.html",
        controller: "taskController"
    })
     .when("/grade", {
          templateUrl: "view/grade.view.html",
          controller: "gradeController"
      })
    .when("/subtask", {
        templateUrl: "view/subtask.view.html",
        controller: "subtaskController"
    })
     .when("/error1", {
        templateUrl: "view/error.html",
        controller: "errorController"
     })
      .when("/client", {
        templateUrl: "view/client.html",
        controller: "clientController"
    }).when("/upload", {
        templateUrl: "view/upload.html",
        controller: "fupController"
    })

    ;
});