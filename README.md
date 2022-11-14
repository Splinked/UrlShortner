Create a local SQL using SSMS, set a desired username and password. These details will be required in your connection string.

<add name="UrlShortnerDB" connectionString="Data Source=.;Initial Catalog=UrlShortner;Integrated Security=False;User ID=UrlShortnerUser;Password=p@55wOrd;MultipleActiveResultSets=True" providerName="System.Data.SqlClient" />

Open the package manager console

Make sure the default project is set "UrlShortner.Data".

Next, execute the command: "enable-migrations". This will create th migrations configuration file in the UrlShortner Data project.

Next, execute the command: add-migration "InitialCreate"

This will add an initial migration to your Data project. When you execute the following command: update-database

If all successfully completes, run the solution. At the home screen enter the long url, as an additional piece of functionality a custom segment can also be provided (the will replace the short url code).
