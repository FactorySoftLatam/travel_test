# Travel Library
- Test o prueba práctica .Net MainSoft
- Miércoles, 08 de febrero de 2023
- Por: Petronio José Peña Amell  

# Instrucciones 

* Crear la Base de Datos, usando para ello el Script **"Script-Database-dbTravel.LIBsql.sql"** ubicado en Script. Incluye datos de prueba. 
* Abrir la solución **"TravelLibrary.sln"** en Visual Studio 2022, compile la solución y ejecute la APP. 
* Test NUnit se incluyo para el controlador AutoresController ubicado en el Lado o proyecto "Server" **TravelLibrary.Server**

![image](https://user-images.githubusercontent.com/122890191/217345436-97f7a941-a9eb-4f93-8809-936f0644ed3c.png)

# Estrcutura de la Solución

Solución cons tres (3) proyectos: 

![image](https://user-images.githubusercontent.com/122890191/217349619-2e54f7da-be38-4c62-85a3-5de659a96026.png)

que contiene: 

* TravelLibrary.Server = App del Lado del Servidor ("Backend")
* TravelLibrary.Client = App del Lado del Servidor ("Front")
* TravelLibrary.Server.Test = Prubas unitarias con nUnit

# Recursos Básicos Utilizados

* [Visual studio 2022 Community]()
* [Visual studio Code](https://code.visualstudio.com/Download)
* [SQL Server Express 2019](https://www.microsoft.com/es-co/download/details.aspx?id=101064)
* Blazor [Tutorial](https://dotnet.microsoft.com/en-us/learn/aspnet/blazor-tutorial/install)
* [Angular-Cli](https://angular.io/cli)
* [Radzen Components y Radzen Studio Versión Libre](https://www.radzen.com/blazor-studio/)
* [.Net 6.0] (https://dotnet.microsoft.com/en-us/download/dotnet/6.0)
* MVC (Model/View/Controller)  Model/Controller =A Server, View (Pages) => Client. 
* [TortoiseGit para el versionamiento](https://tortoisegit.org/download/), auqnue se puede usar tambien Visual Sutudio (Git)

# Pruebas con nUnit

![image](https://user-images.githubusercontent.com/122890191/217351397-bb8371eb-35b1-41e2-b5ad-e58412e7a9f0.png)

# Usuarios
Al sistema en modo de desarrollo se puede ingresar con login = admin, contraseña = admin

![image](https://user-images.githubusercontent.com/122890191/217352322-fec5614a-262a-4110-a0ae-7ba2e8ff32b6.png)


# Menú Principal 

![image](https://user-images.githubusercontent.com/122890191/217352205-dfac3e5e-3544-4a32-8fce-81aef0638f8e.png)


# Publicación APP Blazor

Para publicar la aplicación Blazor en IIS, primero asegúrese de haber instalado la siguiente característica IIS:

![image](https://i.stack.imgur.com/w3DaY.png)

* .NET Core hosting bundle
* ASP.NET Core Runtime

Descargue e instale el paquete de tiempo de ejecución y alojamiento según su versión.

https://dotnet.microsoft.com/download/dotnet-core/6.0

Después de instalar paquetes de alojamiento, no olvide reiniciar la máquina. Si instaló un paquete de alojamiento Bore Installing IIS, debe repararlo.

ahora abra la aplicación blazor en Visual Studio, haga clic con el botón derecho en un proyecto desde el explorador de soluciones y seleccione la opción "Publicar.."

![image](https://i.stack.imgur.com/r3AY8.png)

Haga clic en Publicar > Iniciar > carpeta > elija una ruta de carpeta y haga clic en el botón "Crear perfil".

![image](https://i.stack.imgur.com/0DW4W.png)

Haga clic en el botón "Publicar".

![image](https://i.stack.imgur.com/reLfK.png)

Ahora, abra IIS.

Haga clic derecho en "SItes" > "Agregar sitio web ...".

Establezca todos los detalles como "Nombre del sitio", "Ruta física", "Dirección IP", etc., y haga clic en el botón "Aceptar".

![image](https://i.stack.imgur.com/yTniV.png)

¡Listo!, ahora haga clic derecho en Examinar y podrá ver su aplicación alojada dentro del navegador.