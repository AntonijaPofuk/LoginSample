angular.module('user', ['kendo.directives'])
    .service('usersSvc', function ($http) {
        this.getUsers = function () {
            return $http.get(serviceBase + "api/users");
        }
    }
    )


angular.module('users', ['kendo.directives'])
    .service('usersSvc', function ($http) {
        this.getUsers = function () {
            return $http.get(serviceBase + "api/users");
        }  
    }
    )

    .controller('usersOverviewCtrl', function ($scope, usersSvc, $state) {
        usersSvc.getUsers().then(function (result) {
            $scope.users = result.data.users;
        }, function () { });

    });