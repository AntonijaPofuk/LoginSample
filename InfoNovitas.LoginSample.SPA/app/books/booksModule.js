function generateObjectivesTemplate(id) {
    return '<span>' + id + ' </span>';
}

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
        $scope.profile = function (id) {
            $state.go('bookProfile', { id: id });
        }

        $scope.edit = function (id) {
            $state.go('updateBook', { id: id });
        }

        var grid = $("#grid").kendoGrid({
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
            toolbar: //dropDown and search
                [{ template: kendo.template($("#template").html()) }],
            height: 550,
            filterable: {
                mode: "row"
            },
            groupable: true,
            sortable: true,
            pageable: {
                refresh: true,
                pageSizes: true,
                buttonCount: 5,
            },
            columns: [
                {
                    field: "id",
                    title: "Id",
                    stickable: true
                },
                {
                    field: "author.fullName",
                    title: "Author",
                    filterable: {
                        cell: {
                            operator: "contains",
                            suggestionOperator: "contains"
                        }
                    },
                    stickable: true
                },
                {
                    field: "title",
                    title: "Title",
                    filterable: {
                        cell: {
                            operator: "contains",
                            suggestionOperator: "contains"
                        }
                    },
                    stickable: true
                },
                {
                    field: "description",
                    title: "Descripion",
                    filterable: {
                        cell: {
                            operator: "contains",
                            suggestionOperator: "contains"
                        }
                    }
                },
                {
                    field: "dateCreated",
                    title: "Date created",
                    format: "{0:MM/dd/yyyy}",
                    stickable: true
                },
                {
                    field: null,
                    template: '#= generateObjectivesTemplate(data.id) #',
                    stickable: true
                },
                {
                    command: [
                        {
                            name: "Edit",
                            text: "Edit",
                            click: function (e) {
                                var tr = $(e.target).closest("tr"); // get the current table row (tr)                            
                                var data = this.dataItem(tr); // get the data bound to the current table row
                                console.log("Details for: " + data.id);
                                $state.go('updateBook', { id: data.id });
                            }
                        },
                        {
                            name: "Delete",
                            text: "Delete",
                            click: function (e) {
                                var tr = $(e.target).closest("tr");
                                var data = this.dataItem(tr);
                                console.log("Details for: " + data.id);
                                booksSvc.deleteBook(data.id).then(function () {
                                    $state.reload();
                                });
                            }
                        }
                    ]
                },
                {
                    command: {
                        name: "edit",
                        text: "Details"
                    }
                }],
            editable: {
                mode: "popup",
                template: kendo.template($("#templateEdit").html())
            }
        });

        var dropDown = grid.find("#category").kendoDropDownList({
            dataTextField: "fullName",
            dataValueField: "id",
            autoBind: false,
            optionLabel: "All",
            dataSource: {
                transport: {
                    read: function (options) {
                        $http.get(serviceBase + "api/authors")
                            .then(function (result) {
                                options.success(result.data.authors);
                            }, function (error) {
                                //add error handling
                            });
                    }
                }
            },
            // dropDown
            change: function () {
                var value = this.value();
                if (value) {
                    grid.data("kendoGrid").dataSource.filter({
                        field: "author.id",
                        operator: "eq",
                        value: parseInt(value)
                    });
                } else {
                    grid.data("kendoGrid").dataSource.filter({});
                }
            }
        });
        //dropDown
        grid.find(".k-grid-toolbar").on("click", ".k-pager-refresh", function (e) {
            e.preventDefault();
            grid.data("kendoGrid").dataSource.read();
        });
    })

    .controller('bookProfileCtrl', function ($scope, booksSvc, $state, $stateParams) {
        booksSvc.getBook($stateParams.id).then(function (result) {
            $scope.book = result.data;
        })
    })
    .controller('newBookCtrl', function ($scope, booksSvc, userInfoService, $state, $http) {
        $scope.book = {
            id: 0
        };

        $scope.authors = {
            transport: {
                read: function (options) {
                    $http.get(serviceBase + "api/authors")
                        .then(function (result) {
                            options.success(result.data.authors);
                        }, function (error) {
                            //add error handling

                        });
                }
            }
        };

        $scope.addNewBook = function () {
            booksSvc.createBook($scope.book).then(function () {
                $state.go('booksOverview');
            });
        }
    })
    .controller('updateBookCtrl', function ($scope, booksSvc, $state, $stateParams, $http) {
        booksSvc.getBook($stateParams.id).then(function (result) {
            $scope.book = result.data;
        })
        $scope.authors = {
            transport: {
                read: function (options) {
                    $http.get(serviceBase + "api/authors")
                        .then(function (result) {
                            options.success(result.data.authors);
                        }, function (error) {
                            //add error handling

                        });
                }
            }
        };

        $scope.updateBook = function () {
            booksSvc.updateBook($stateParams.id, $scope.book).then(function () {
                $state.go("booksOverview");
            });
        }
    });


