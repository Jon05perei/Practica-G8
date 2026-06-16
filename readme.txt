1. Integrantes del grupo:
	Josué Mora Salas
	Jeustyn Sánchez Ruiz
	Jonatan Pereira Guevara

2. Enlace del repositorio en GitHub:  https://github.com/Jon05perei/Practica-G8.git

3. Especificación básica del proyecto:

a. Arquitectura del proyecto
El proyecto es una aplicación web ASP.NET Core MVC (.NET 10) desarrollada con una arquitectura por capas:

	* DAL (Data Access Layer): contiene las entidades del modelo de datos (Cliente, Telefono), el ApplicationDbContext (EF Core), y el repositorio 	(ClienteRepository) que encapsula todas las operaciones contra la base de datos SQLite

	* BLL (Business Logic Layer): contiene los servicios (ClienteService) que aplican las reglas de negocio y validaciones antes de delegar al repositorio. 	También contiene ResultadoOperacion, clase auxiliar para comunicar el resultado de las operaciones al controlador

	* Controllers: reciben las peticiones HTTP, convierten los datos del formulario (ViewModels) en entidades de dominio, y llaman a la BLL. No contienen lógica 	de negocio

	* Models: contienen los ViewModels (ClienteViewModel, ClienteFormViewModel) específicos para las vistas, con anotaciones de validación de formularios

	* Views: vistas Razor (.cshtml) para Listado, Detalle, Registrar y Modificar clientes


b. Libraries o paquetes de NuGet utilizados

	* Microsoft.EntityFrameworkCore.Sqlite: proveedor de base de datos SQLite para Entity Framework Core. Permite trabajar con un archivo .db local sin 	necesidad de un servidor de base de datos externo

	* Microsoft.EntityFrameworkCore.Design: herramientas en tiempo de diseño para EF Core, necesario para generar migraciones

	* Microsoft.EntityFrameworkCore.Tools: comandos de consola (Add-Migration, Update-Database) para gestionar las migraciones y la creación de la base de datos

c. Principios de SOLID y patrones de diseño utilizados

	* Single Responsibility Principle (SRP): cada capa tiene una única responsabilidad. ClienteRepository solo accede a datos; ClienteService solo aplica reglas 	de negocio; ClienteController solo orquesta la petición HTTP

	* Open/Closed Principle (OCP): las interfaces IClienteRepository e IClienteService permiten extender el comportamiento (por ejemplo, cambiar SQLite por SQL 	Server) sin modificar el código que depende de ellas

	* Dependency Inversion Principle (DIP): los controladores dependen de IClienteService (abstracción), no de ClienteService (implementación concreta). 	Igualmente, ClienteService depende de IClienteRepository, no de ClienteRepository directamente. La inyección de dependencias de ASP.NET Core resuelve estas 	dependencias en tiempo de ejecución

	* Patrón Repository: ClienteRepository centraliza toda la lógica de acceso a datos, aislando al resto del sistema de los detalles de EF Core y SQLite

	* Patrón MVC (Model-View-Controller): separación entre los datos (Models/DAL), la presentación (Views) y la lógica de control (Controllers)
