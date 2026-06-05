# CampaignApp

## Get started

### CampaignApi

* To run the api, start the CampaignApi-project from an IDE or run the command `dotnet run --launch-profile https` from the CampaignApi root folder.

* To test the api by itself, in a web browser go to https://localhost:7043/scalar.


### campaign-client

**Prerequisites:** Have [Node.js](https://nodejs.org) installed.

1. Run the command `npm install` from the campaign-client root folder to install any dependencies.
2. Start the app by running the command `npm run serve` from the campaign-client root folder.


## Assumptions

- The "Active/Inactive status" can only have one of two possible values, which is why i chose to represent it as a boolean (true for "Active" and false for "Inactive").

## Future improvements

### CampaignApi

* For the database model `Campaign.cs` I would add data annotations and/or override the `OnModelCreating()` method in `CampaignDbContext` to define datatypes for the properties and add eventual constraints.
* I would probably change the `Active` property in `Campaign.cs` from boolean type to enum.
* Implement logging.
* Create DTOs/ViewModels so that the database model is not used outside the repository and database context.
* Separate the project into layers. In current state the Controller could access the repository, database context and database model although it only needs to know about the `CampaignService` and DTOs/ViewModels.
* Implement error handling. For example try-catch blocks to catch and handle exceptions, an exception handler middleware for custom exceptions and use of `Microsoft.AspNetCore.Mvc.ProblemDetails` for returning error responses in api-requests.
* Add unit tests.

### campaign-client

* Improve styling to get a more appealing and consistent look.
* Make the app responsive so that the UI looks and feels good on different sized screens.
* Implement error handling. In current state, if an error arises when sending a request the user is not notified in the UI.
* In the future, components will most likely need to share the same state so I would implement state management with for example Vuex.
