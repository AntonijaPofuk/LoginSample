var loginApp = angular.module('LoginApp', ['common', 'LocalStorageModule', 'oc.lazyLoad', 'ui.router', 'kendo.directives']);

loginApp.run([
    'authService', '$http', '$window', '$q', '$rootScope', function (authService, $http, $window, $q, $rootScope) {
        if (authService.getToken() == null) {
            $window.location.href = '/account/login';
        }

        $rootScope.$on('event:auth-loginRequired', function () {
            console.log("AUTH REQUIRED CONFIG");
            authService.refreshToken();
        });

        $rootScope.$on('event:auth-loginCancelled', function () {
            console.log("AUTH CANCELLED CONFIG");
            $window.location.href = '/account/login';
        });
    }
]);

var loginRequired = function ($location, $window, authService) {
    return true;
    if (authService.getToken() == null) {
        $window.location.href = '/account/login';
    }
}


loginApp.config([
    '$httpProvider', '$stateProvider', '$urlRouterProvider', '$locationProvider','$ocLazyLoadProvider',
    function ($httpProvider, $stateProvider, $urlRouterProvider, $locationProvider,$ocLazyLoadProvider) {


        if (!$httpProvider.defaults.headers.get) {
            $httpProvider.defaults.headers.get = {};
        }
        $httpProvider.defaults.headers.get['Cache-Control'] = 'no-cache';
        $httpProvider.defaults.headers.get['Pragma'] = 'no-cache';

        $ocLazyLoadProvider.config({
            debug: true
        });

        $urlRouterProvider.otherwise('/');

        $stateProvider
            .state('dashboard', {
                url: "/",
                controller: "DashboardCtrl",
                templateUrl: "app/dashboard/partials/dashboard.html",
                cache: false,
                resolve: {
                    loginRequired: loginRequired,
                    dashboard: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "dashboard",
                            files: [
                                "app/dashboard/controllers/dashboardCtrl.js",
                                "app/dashboard/dashboardModule.js"
                            ]
                        });
                    }
                }
            })
         .state('authorsOverview', {
             url: "/authors",
             controller: "authorsOverviewCtrl",
             templateUrl: "app/authors/authorsOverview.html",
             resolve: {
                 loginRequired: loginRequired,
                 authors: function ($ocLazyLoad) {
                     return $ocLazyLoad.load({
                         name: "authors",
                         files: [
                             "app/authors/authorsModule.js"
                         ]
                     });
                 }
             }
         })
            .state('authorProfile', {
                url: "/authors/:id",
                controller: "authorProfileCtrl",
                templateUrl: "app/authors/profile.html",
                resolve: {
                    loginRequired: loginRequired,
                    authors: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "authors",
                            files: [
                                "app/authors/authorsModule.js"
                            ]
                        });
                    }
                }
            })

            .state('userProfile', {
                url: "/user/:id",
                controller: "LayoutCtrl",
                templateUrl: "app/user/userProfile.html",
                resolve: {
                    loginRequired: loginRequired,
                    authors: function ($ocLazyLoad) {
                        return $ocLazyLoad.load({
                            name: "user",
                            files: [
                                "app/user/usersModule.js"
                            ]
                        });
                    }
                }
            })
         .state('newAuthor', {
             url: "/author/new",
             controller: "newAuthorCtrl",
             templateUrl: "app/authors/newAuthor.html",
             cache: false,
             resolve: {
                 loginRequired: loginRequired,
                 authors: function ($ocLazyLoad) {
                     return $ocLazyLoad.load({
                         name: "authors",
                         files: [
                             "app/authors/authorsModule.js"
                         ]
                     });
                 }
             }
         })
         .state('updateAuthor', {
             url: "/author/update/:id",
             controller: "updateAuthorCtrl",
             templateUrl: "app/authors/updateAuthor.html",
             cache: false,
             resolve: {
                 loginRequired: loginRequired,
                 authors: function ($ocLazyLoad) {
                     return $ocLazyLoad.load({
                         name: "authors",
                         files: [
                             "app/authors/authorsModule.js"
                         ]
                     });
                 }
             }
         });       
        $locationProvider.html5Mode(true);
    }
]);

loginApp.controller('LayoutCtrl', [
    '$scope', 'authService', '$window', '$rootScope', 'userInfoService', function ($scope, authService, $window, $rootScope, userInfoService) {

        userInfoService.getInfo().then(function (result) {
            $scope.loggedUser = result.data;
            $scope.loggedUser.fullName = $scope.loggedUser.firstname + ' ' + $scope.loggedUser.lastname;
            $scope.loggedUser.email = $scope.loggedUser.email;
            $scope.loggedUser.firstName = $scope.loggedUser.firstname;
            $scope.loggedUser.lastName = $scope.loggedUser.lastname;
        }, function(result) {
        });

        $scope.logOut = function () {
            authService.logOut();
            $window.location.href = '/account/login';
        };

        $rootScope.$on('event:auth-loginRequired', function () {
            console.log("AUTH REQUIRED");
            authService.logOut();
            $window.location.href = '/account/login';
        });

        $rootScope.$on('event:auth-loginCancelled', function () {
            console.log("LOGIN CANCELLED");
            $scope.logOut();
        });
    }
]);