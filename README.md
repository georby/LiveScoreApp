# Live Score Sheet


##### Project Setup
> The solution contains 2 projects.
  - Scoreboard Project (`ScoreboardApp`).
  - Console Project (`ConsoleApp`).
  - The solution is configured to run both the projects together.

##### Prerequisites
  - Visual Studio 2019
  - .NET Framework 4.7.2

##### Bin Folder Details
  - `ScoreboardApp.exe` is the first application to be run. Then run the `ConsoleApp.exe` for sending the score details to the Scoreboard.

###### Note
> Since no input validations are specified, alphanumeric characters are allowed for all the console details (except for the status).
> In order to ensure the data integrity, the ScoreboardApp will be storing the scoreboard data in an `xml` file. And, the same will be loaded during the application launch.
