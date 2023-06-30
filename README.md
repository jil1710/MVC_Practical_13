# MVC_Practical_13
ASP.NET MVC Practical -13 Usin EF Core

* In this practical we have multiple projects so we have to chage the between so you have to change between them. And here we used diffrent databases so do you have to make the migrations for them.
* Befor the migartion you have to change the connection string in DataContext folder and put you server connection string.
* After that open package manager console and write the following command in package manager console : But in this practical there are two practical so before write below commange make sure to select appropriate practical in package manager console.
```
  Update-Database
```  

* Remember that you have to fire the update-databse command for all project and you have to update the connection string according to your pc.

* If you get the some error after performing all the above steps about roslyn error than you have to fire the below command in package manager console then you are ready to go....
```
Update-Package Microsoft.CodeDom.Providers.DotNetCompilerPlatform -r
```
