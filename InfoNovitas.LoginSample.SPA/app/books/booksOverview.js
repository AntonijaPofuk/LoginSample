    <script type="text/x-kendo-template" id="templateEdit">
        <form class="k-form k-form-vertical">
            <ul id="fieldlist">
                <li class="k-form-field">
                    <label for="id" class="k-form-label">Id</label>
                    <span class="k-form-field-wrap">
                        <input readonly class="form-control" k-data-source="id" data-bind="value: id" name="id" id="id" />
                    </span>
                </li>
                <li class="k-form-field">
                    <label for="fullname" class="k-form-label">Naziv</label>
                    <span class="k-form-field-wrap">
                        <input readonly class="form-control" k-data-source="title" data-bind="value: title" name="title" id="title" />
                    </span>
                </li>
                <li class="k-form-field">
                    <label for="search" class="k-form-label">Autor</label>
                    <span class="k-form-field-wrap">
                        <input readonly class="form-control" k-data-source="author.fullName" data-bind="value: author.fullName" name="author" id="author" />
                    </span>
                </li>
                <li class="k-form-field">
                    <label for="search" class="k-form-label">Opis</label>
                    <span class="k-form-field-wrap">
                        <input readonly class="form-control" ng-model="book.description" name="description" id="description" />
                    </span>
                </li>
                <li class="k-form-field">
                    <span class="k-form-field-wrap">
                        <label for="userCreated">Kreirao</label>
                        <input readonly name="usercreated" type="text" class="form-control" [required="string" ] k-data-source="userCreated.id" data-bind="value: userCreated.id" />
                </span>
                </li>
                <li class="k-form-field">
                    <label for="search" class="k-form-label">Zadnje ažurirao</label>
                    <span class="k-form-field-wrap">
                        <input readonly name="userlastmodified" type="text" class="form-control" [required="string" ] k-data-source="userLastModified" data-bind="value: userLastModified" />
                </span>
                </li>
            </ul>
        </form>
    </script>

