# Descripción del Repositorio Backend.

## Tecnologías utilizadas:

- --Framework de desarrollo: .Net Core 2.2
- --Lenguaje Programación C#.
- --Servicios utlizados: WebAPI Rest.
- --Frameworks para la utilización de datos: Entity Framework Core.
- --Visualización de datos: JSON utilizando el paquete o librería Newtonsoft.Json.
- --Deploy del Backend: Si se usa Windows, ocupar &quot;WebAPI&quot; y no IIS, ya que IIS no funcionará con el frontend o habría que realizar cambios en la URL base del front.
- --Acceso a Base de datos: Se utilizó un archivo de SQLite para generarción de datos, se ecuentra en WebApi/Storage.

## Requisitos:

- --Tener instalado .Net Core 2.2 SDK 2.2.401, puede ser obtenido desde: [https://dotnet.microsoft.com/download/dotnet-core/2.2](https://dotnet.microsoft.com/download/dotnet-core/2.2)
- --Algún IDE que pueda ejecutar el código en .Net Core 2.2, con sus respectivos paquetes Nuget, pueden ser Visual Studio 2017, Visual Studio 2019 o Rider 2017+.
- --Opcional: Tener en cuenta para ejecutar el Script, necesita Entity Framework Core.

## Estructura del repositorio:

El repositorio consta de varias capas o proyectos en si los cuales se detallarán a continuación:

- **WebApi** : es el proyecto principal del repositorio, en el cual se interactúa con las peticiones que realice el usuario, es donde se encuentran los controladores o los diferentes sub-sitios para que se llamen a las distintas clases que se tienen el proyecto, consta de la siguiente estructura:
  - _Properties_: carpeta donde se almacenan los archivos de configuración de propiedades para la iniciación de servicios.
  - _Controllers_: carpeta que contiene a los controladores donde el usuario o sistemas puede hacer las peticiones para traspasar datos o recibir datos.
  - _Extensions_: carpeta que contiene las extensiones de las clases que configuran el backend, contiene los métodos necesarios para que pueda funcionar correctamente.
  - _UtilExtensions_: carpeta que contiene las clases de utilidad para poder ser ocupadas en los diferentes métodos de este proyecto.
  - _Principal, Raíz o WebApi_: carpeta que contiene las clases que inician los servicios, como también las clases que llaman a métodos para configurar estos servicios, además contiene un archivo json para almacenar los diferentes datos que son de petición global al repositorio.

- **BusinessRules** : es el proyecto que contiene toda la lógica de los negocios, es la cual ayuda a las peticiones a que ser realicen correctamente, utilizando diferentes métodos para hacer de manera satisfactoria las diferentes transacciones entre las capas, esta divido en los diferentes módulos que se ocuparan en los sistemas o aplicaciones.

- **Entities** : es el proyecto que contiene todas las clases necesarias para la interacción con la base de datos, es la capa donde se crean las diferentes clases que crean las entidades necesarias para obtener datos de la base de datos. Este proyecto consta de la siguiente estructura:
  - _Models_: carpeta que contiene todas las clases que son entidades para la base de datos.
  - _Extensions_: carpeta que contiene todas las extensiones de las clases con los métodos que se ocuparan en el CRUD con la base de datos.
  - _Utils_: carpeta que contiene las clases que se ocuparan para la ayuda de la visualización de datos.
  - _Migrations_: carpeta que contiene las clases que se crean automáticamente a partir de los comandos para que las clases de los modelos puedan crearse las entidades en la base de datos, además contiene el histórico de cuantas veces a sido llamado el comando para actualizar la base de datos.
  - _Principal, Raíz o Entities_: carpeta que contiene todas las carpetas mencionadas anteriormente, además de la interfaz IEntity, la cual es la base para poder crear las clases e implementar el Id de todas ellas, y la clase RepositoryContext, es la que ayuda a EntityFramework a que se relacione todas las clases de _Models_ con la Base de datos.

- **Contracts** : es el proyecto que contiene todas las interfaces que van a ser implementadas por las diferentes clases del proyecto **Repository**. En este proyecto se definen las interfaces con los diferentes prototipos de métodos, también es una ayuda para poder crear la inyección de dependencias para que sean llamadas por los métodos de las clases de la lógica de negocios y así que sean un medio de interacción no directa entre negocios y datos, además al igual que **Entities** y **BusinessRules** ,:
  - _Interfaces_: carpeta que contiene las interfaces con los prototipos de métodos para ser implementadas por las clases correspondientes de **Repository**.

- **Repository:** Es el proyecto que contiene todas las clases que se interactúan con la base de datos, la cual además se crean las consultas, implementan las interfaces del proyecto **Contracts** e implementa Entity Framework Core para poder realizar el Mapeo necesario para que enlacen con las distintas entidades/clases que se definen en **Entities** :
  - _Base_: Carpeta que contiene la clase base, que será ocupada por las diferentes clases compuestas, además tiene los métodos CRUD generales para las entidades puedan interactuar con la base de datos.
  - _Utils_: Carpeta que contiene las clases que serán de ayuda para interactuar con las clases de Repositorio, está presente una extensión que interactúa para la paginación de los resultados.
  - _Wrappers_: Carpeta que contiene contenedores de repositorios, esta permite la ayuda entre el lazo de la capa de Negocios con la de Datos, además permite la ayuda de la implementación de inyección de dependencias y que cualquier repositorio, pueda tener una relación directa con la entidad definida.

- **SQL** : Esta carpeta contiene las los diferentes Scripts para la generacion de la Base de datos.