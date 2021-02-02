angular.module('books', ['kendo.directives'])
    .service('booksSvc', function ($http) {
        this.getbooks = function () {
            return $http.get(serviceBase + "api/books");
        }
        this.getbook = function (id) {
            return $http.get(serviceBase + "api/books/" + id);
        }
        this.deletebook = function (id) {
            return $http.delete(serviceBase + "api/books/" + id);
        }
        this.createbook = function (book) {
            return $http.post(serviceBase + "api/books", book);
        }
        this.updatebook = function (id, book) {
            return $http.put(serviceBase + "api/books/" + id, book);
        }
    })
       

    .controller('booksOverviewCtrl', function ($scope, booksSvc, $state) {
        booksSvc.getbooks().then(function (result) {
            $scope.books = result.data.books;
        }, function () { });

       $scope.delete = function (id) {
            booksSvc.deletebook(id).then(function () {
                $state.reload();
            });
        }

        $scope.profile = function (id) {
            $state.go('bookProfile', { id: id });
        }

        $scope.edit = function (id) {
            $state.go('updatebook', { id: id });
        }
    })
    .controller('bookProfileCtrl', function ($scope, booksSvc, $state, $stateParams) {
        booksSvc.getbook($stateParams.id).then(function (result) {
            $scope.book = result.data;
        })
    })
    .controller('newbookCtrl', function ($scope, booksSvc, userInfoService, $state) {
        $scope.book = {
            id: 0
        };

        $scope.addNewbook = function () {
            booksSvc.createbook($scope.book).then(function () {
                $state.go('booksOverview');
            });
        }
    })
    .controller('updatebookCtrl', function ($scope, booksSvc, $state, $stateParams) {
        booksSvc.getbook($stateParams.id).then(function (result) {
            $scope.book = result.data;
        })

        $scope.updatebook = function () {
            booksSvc.updatebook($stateParams.id, $scope.book).then(function () {
                $state.go("booksOverview");
            });
        }
    });