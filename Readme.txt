run this command to run html on localhost: python -m SimpleHTTPServer
command http server kassablad.front_02 : http-server -p 8000

- Run this command to scaffold Controller: dotnet aspnet-codegenerator controller -name KassaNominationsController -m KassaNomination -dc KassabladContext --relativeFolderPath Controllers -udl --referenceScriptLibraries;

- To remove fields from table: 
	1) remove db file
	2) dotnet ef migrations remove (until none left)
	3) dotnet ef migrations add InitialCreate
	4) dotnet ef database update