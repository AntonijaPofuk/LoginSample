angular.module('authors', ['kendo.directives'])
    .service('authorsSvc', function ($http) {
        this.getAuthors = function () {
            return $http.get(serviceBase + "api/authors");
        }
        this.getAuthor = function (id) {
            return $http.get(serviceBase + "api/authors/" + id);
        }
        this.deleteAuthor = function (id) {
            return $http.delete(serviceBase + "api/authors/" + id);
        }
        this.createAuthor = function (author) {
            return $http.post(serviceBase + "api/authors", author);
        }
        this.updateAuthor = function (id, author) {
            return $http.put(serviceBase + "api/authors/" + id, author);
        }
    })

    .controller('authorsOverviewCtrl', function ($http, $scope, authorsSvc, $state) {
        authorsSvc.getAuthors().then(function (result) {
            $scope.authors = result.data.authors;
        }, function () { });

       $scope.delete = function (id) {
            authorsSvc.deleteAuthor(id).then(function () {
                $state.reload();
            });
        }

        $scope.onClick = function () {
            alert("Button click");
        };
     

        $scope.mainGrid = {
            dataSource: {
                transport: {
                    read: function (options) {
                        $http.get(serviceBase + "api/authors")
                            .then(function (result) {
                                options.success(result.data.authors);
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
                field: "firstName",
                title: "First Name",
                width: "120px"
            },
                {
                field: "lastName",
                title: "Last Name",
                },
                {
                    field: "note",
                    title: "Note",
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
            $state.go('authorProfile', { id: id });
        }

        $scope.edit = function (id) {
            $state.go('updateAuthor', { id: id });
        }
    })
    .controller('authorProfileCtrl', function ($scope, authorsSvc, $state, $stateParams) {
        authorsSvc.getAuthor($stateParams.id).then(function (result) {
            $scope.author = result.data;
        })
    })
    .controller('newAuthorCtrl', function ($scope, authorsSvc, userInfoService, $state) {
        $scope.author = {
            id: 0
        };

        $scope.addNewAuthor = function () {
            authorsSvc.createAuthor($scope.author).then(function () {
                $state.go('authorsOverview');
            });
        }
    })
    .controller('updateAuthorCtrl', function ($scope, authorsSvc, $state, $stateParams) {
        authorsSvc.getAuthor($stateParams.id).then(function (result) {
            $scope.author = result.data;
        })

        $scope.updateAuthor = function () {
            authorsSvc.updateAuthor($stateParams.id, $scope.author).then(function () {
                $state.go("authorsOverview");
            });
        }
    });