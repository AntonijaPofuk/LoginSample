angular.module('users', ['kendo.directives'])
    .service('usersSvc', function ($http) {
        this.getUsers = function () {
            return $http.get(serviceBase + "api/users");
        }
        this.getUser = function (id) {
            return $http.get(serviceBase + "api/users/" + id);
        }
    })

        .controller('usersOverviewCtrl', function ($scope, usersSvc, $state) {

            usersSvc.getUsers().then(function (result) {
                $scope.users = result.data.users;
            }, function () { });

            $scope.profile = function (id) {
                $state.go('userProfile', { id: id });
            }
        })
        .controller('userProfileCtrl', function ($scope, usersSvc, $state, $stateParams) {
            usersSvc.getUser($stateParams.id).then(function (result) {
                $scope.user = result.data;
            })
        });