# The Bookies

A place to buy, rent and avail various offers on books.
Special priveledges for admin and library card holder.


## Getting Started

+ Clone or extract the repo locally
+ Install entity framework if not done so already
+ `enable-migrations` from package manager console if migrations are not enabled
+ Run migrations and update database with `update-database`
+ Build and run the project using `Ctrl + F5`
+ In case of database error Delete and Add `App_Data` to root directory of the repo and update database


## Specifications

+ Used the MVC structure for the working of the project
+ Create user and admin user and buy and rent books
+ Admins can add and delete books
+ Library Card feature will let you rent books for free
+ Anonymous users can view the books and offers
+ API's available for external support
+ User profile will show all the purchase history and account info


## API's

Api endpoints should be prefixed by `api/`
<dl class="dl-horizontal">
    <dt>/genre</dt>
    <dd>
        <strong>Genre</strong> model
        <dl class="dl-horizontal">
            <dt>GET</dt>
            <dd>
                Fetch all Genres
            </dd>
            <dt>POST</dt>
            <dd>
                Add Genre
            </dd>
            <dt>PUT/{id}</dt>
            <dd>
                Update Genre with specified id from uri
            </dd>
            <dt>DELETE/{id}</dt>
            <dd>
                Delete Genre with specified id from uri
            </dd>
        </dl>
    </dd>
    <dt>/author</dt>
    <dd>
        <strong>Author</strong> model
        <dl class="dl-horizontal">
            <dt>GET</dt>
            <dd>
                Fetch all Authors
            </dd>
            <dt>POST</dt>
            <dd>
                Add Author
            </dd>
            <dt>PUT/{id}</dt>
            <dd>
                Update Author with specified id from uri
            </dd>
            <dt>DELETE/{id}</dt>
            <dd>
                Delete Author with specified id from uri
            </dd>
        </dl>
    </dd>
    <dt>/book</dt>
    <dd>
        <strong>Book</strong> model
        <dl class="dl-horizontal">
            <dt>GET</dt>
            <dd>
                Fetch all Books
            </dd>
            <dt>POST</dt>
            <dd>
                Add Book
            </dd>
            <dt>PUT/{id}</dt>
            <dd>
                Update Book with specified id from uri
            </dd>
            <dt>DELETE/{id}</dt>
            <dd>
                Delete Book with specified id from uri
            </dd>
        </dl>
    </dd>
    <dt>/rents</dt>
    <dd>
        <strong>Rent</strong> model
        <dl class="dl-horizontal">
            <dt>GET</dt>
            <dd>
                Fetch all Rents
            </dd>
            <dt>POST</dt>
            <dd>
                Add Rents
            </dd>
            <dt>PUT/{id}</dt>
            <dd>
                Update Rents with specified id from uri
            </dd>
            <dt>DELETE/{id}</dt>
            <dd>
                Delete Rents with specified id from uri
            </dd>
        </dl>
    </dd>
    <dt>/sales</dt>
    <dd>
        <strong>Sale</strong> model
        <dl class="dl-horizontal">
            <dt>GET</dt>
            <dd>
                Fetch all Sales
            </dd>
            <dt>POST</dt>
            <dd>
                Add Sales
            </dd>
            <dt>PUT/{id}</dt>
            <dd>
                Update Sales with specified id from uri
            </dd>
            <dt>DELETE/{id}</dt>
            <dd>
                Delete Sales with specified id from uri
            </dd>
        </dl>
    </dd>
</dl>
