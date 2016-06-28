#### How to Run Asp.NET Core application as a Windows service

* Clone the source and execute following commands([.NET Core SDK required](https://www.microsoft.com/net/core#windows))
* dotnet restore
* dotnet build
* dotnet publish -o=C:\Dev\publish 
* sc create MusicStoreAsService binPath= "C:\Dev\publish\MusicStoreAsService.exe"
* http://localhost:5000/ should work now.

##### References : 
  * http://stackoverflow.com/a/37464074/857956
  * https://github.com/aspnet/Home/issues/1386
