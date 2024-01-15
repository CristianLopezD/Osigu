# Sistema de Gestión de Vuelos

Este proyecto en C# .NET, desarrollado con WPF con MVVM, proporciona una solución completa para la gestión de vuelos salientes desde un aeropuerto. 

# Guía de Instalación
## Requisitos Previos

Antes de comenzar con la instalación, asegúrate de tener los siguientes requisitos instalados:

.NET Framework 8: Asegúrate de tener instalada la versión 8 del .NET Framework
SQL Server: Asegúrate de tener una instancia válida de SQL Server instalada en tu entorno.

## Creación de la Base de Datos
Abre SQL Server Management Studio (SSMS) y conéctate a tu instancia de SQL Server.

En la carpeta BD del proyecto, ejecuta el script 0_InitTables.sql para inicializar las tablas necesarias.

Luego, ejecuta el script 1_Inserts.sql para insertar datos de ejemplo en las tablas.

## Configuración de la Conexión a la Base de Datos
Abre el archivo App.config ubicado en el proyecto.

Agrega la siguiente configuración dentro del bloque <configuration> para especificar la cadena de conexión:


```bash
<setting name="DB" serializeAs="String">
     <value>Server=localhost;Database=osiguDB;User Id=osiguapp;password=123456.;Trusted_Connection=False;MultipleActiveResultSets=true;</value>
</setting>
```
Asegúrate de modificar los valores de Server, Database, User Id, y password según tu entorno de SQL Server.

## Ejecución de la Aplicación
Compila y Ejecuta la aplicación resultante.

Inicia sesión con las credenciales proporcionadas o registrarse segun se requiera.

Explora las funciones de programación de vuelos e información.
