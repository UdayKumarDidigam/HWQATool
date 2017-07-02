app.controller('fupController', function ($scope, $window, $http) {

    debugger;
    $http.get("http://localhost:2864/api/UploadTracks").then(function (response) {
        debugger;
        $scope.uploads = response.data;
    }, function (error) {

    });

    $scope.downloadFile = function (teamId, trackId) {
        $window.open("/api/file/download/" + teamId + "/" + trackId /*+ params*/);
    }






    // GET THE FILE INFORMATION.
    $scope.getFileDetails = function (e) {

        $scope.files = [];
        $scope.$apply(function () {

            // STORE THE FILE OBJECT IN AN ARRAY.
            for (var i = 0; i < e.files.length; i++) {
                $scope.files.push(e.files[i])
            }

        });
    };

    // NOW UPLOAD THE FILES.
    $scope.uploadFiles = function () {

        //FILL FormData WITH FILE DETAILS.
        var data = new FormData();

        for (var i in $scope.files) {
            data.append("uploadedFile", $scope.files[i]);
        }

        // ADD LISTENERS.
        var objXhr = new XMLHttpRequest();
        objXhr.addEventListener("progress", updateProgress, false);
        objXhr.addEventListener("load", transferComplete, false);

        // SEND FILE DETAILS TO THE API.
        objXhr.open("POST", "/api/fileupload/");
        objXhr.send(data);
    }

    // UPDATE PROGRESS BAR.
    function updateProgress(e) {
        if (e.lengthComputable) {
            debugger;
            document.getElementById('pro').setAttribute('value', e.loaded);
            document.getElementById('pro').setAttribute('max', e.total);
        }
    }

    // CONFIRMATION.
    function transferComplete(e) {
        alert("Files uploaded successfully.");
    }

    var formdata = new FormData();
    $scope.getTheFiles = function ($files) {
        $scope.$apply(function () {
            $scope.uploadFileName = $files[0].name;
            $scope.files = $files;
        });

        angular.forEach($files, function (value, key) {
            formdata.append(key, value);
        });

    };

    $scope.setFileName = function () {
        if ($scope.files && $scope.files[0])
            $scope.uploadFileName = $scope.files[0].name;
    }

    $scope.clear = function () {
        $scope.uploadFileName = "";
    }
});






//// NOW UPLOAD THE FILES.
//$scope.uploadFiles = function () {
//    var request = {
//        method: 'POST',
//        url: 'api/FileUpload/UploadFiles',
//        data: formdata,
//        headers: {
//            'Content-Type': undefined
//        }
//    };

//    // SEND THE FILES.
//    $http(request)
//        .success(function (d) {
//            alert(d);
//        })
//        .error(function () {
//        });
//}


