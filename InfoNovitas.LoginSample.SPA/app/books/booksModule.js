angular.module('books', ['kendo.directives'])
    .service('booksSvc', function ($http) {
        this.getBooks = function () {
            return $http.get(serviceBase + "api/books");
        }
        this.getBook = function (id) {
            return $http.get(serviceBase + "api/books/" + id);
        }
        this.deleteBook = function (id) {
            return $http.delete(serviceBase + "api/books/" + id);
        }
        this.createBook = function (book) {
            return $http.post(serviceBase + "api/books", book);
        }
        this.updateBook = function (id, book) {
            return $http.put(serviceBase + "api/books/" + id, book);
        }
    })
       

    .controller('booksOverviewCtrl', function ($scope, booksSvc, $state, $http) {
        booksSvc.getBooks().then(function (result) {
            $scope.books = result.data.books;
        }, function () { });

       $scope.delete = function (id) {
            booksSvc.deleteBook(id).then(function () {
                $state.reload();
            });
        }

        $scope.mainGrid = {
            dataSource: {
                transport: {
                    read: function (options) {
                        $http.get(serviceBase + "api/books")
                            .then(function (result) {
                                options.success(result.data.books);
                            }, function (error) {
                                //add error handling
                            });
                    },
                },
                pageSize: 5
            },
            sortable: true,
            pageable: true,
            columns: [{
                field: "title",
                title: "Title",
                width: "120px"
            },
            {
                field: "author.fullName",
                title: "Author",
            },
            
            {
                field: "description",
                title: "Descripion",
            },
            {
                field: "dateCreated",
                title: "Date created",
                format: "{0:dd/MM/yyyy}"

            },
            {
                template: `
                        <kendo-button class="k-primary" ng-click="profile(#: id#)">Profil</kendo-button>
                        <kendo-button class="k-primary" ng-click="edit(#: id#)">Uredi</kendo-button>
                        <kendo-button class="k-primary" ng-click="delete(#: id#)">Obriši</kendo-button>
                    `,
                headerTemplate: '<label> Edit </label>',
                width: "200px"
            }]
        }


        $scope.profile = function (id) {
            $state.go('bookProfile', { id: id });
        }

        $scope.edit = function (id) {
            $state.go('updateBook', { id: id });
        }
    })
    .controller('bookProfileCtrl', function ($scope, booksSvc, $state, $stateParams) {
        booksSvc.getBook($stateParams.id).then(function (result) {
            $scope.book = result.data;
        })
    })
    .controller('newBookCtrl', function ($scope, booksSvc, userInfoService, $state) {
        $scope.book = {
            id: 0
        };

        $scope.addNewBook = function () {
            booksSvc.createBook($scope.book).then(function () {
                $state.go('booksOverview');
            });
        }
    })
    .controller('updateBookCtrl', function ($scope, booksSvc, $state, $stateParams) {
        booksSvc.getBook($stateParams.id).then(function (result) {
            $scope.book = result.data;
        })

        $scope.updateBook = function () {
            booksSvc.updateBook($stateParams.id, $scope.book).then(function () {
                $state.go("booksOverview");
            });
        }
    });