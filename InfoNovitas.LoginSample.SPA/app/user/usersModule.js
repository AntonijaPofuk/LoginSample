angular.module('user', ['kendo.directives'])
    .service('usersSvc', function ($http) {   
        this.getUser = function () {
            return $http.get(serviceBase + 'api/userInfo');
        }
      
    })
       
    .controller('userProfileCtrl', function ($scope, userSvc, $state, $stateParams) {
        userSvc.getUser($stateParams.id).then(function (result) {
            $scope.user = result.data;
        })
    })
    
