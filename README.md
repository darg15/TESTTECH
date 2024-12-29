# TEST_DEF

## Pasos para la ejecucion 
En la raiz del proyecto se encuentra el script con los datos de ejemplo para la ejecucion del mismo, es un script de sql

- Al clonar el repositorio se descarga Script.sql, ir a SQL Server y ejecutar el comando **CREATE DATABASE TechCard**, luego abrir el archivo Script.sql y darle en **Ejecutar Consulta** o **F5**
- Una vez realizado el primer paso, abrir la consola PS de Visual Studio (Ctrl + ñ), y digitar **cd TechnicalAPI**


![image](https://github.com/user-attachments/assets/0269c3f1-8075-4f90-b39e-0edd1a27fda8)

- Una vez en la ruta TechnicalAPI, ejecutar el comando **dotnet run**, esto ejecutara el proyecto de la API
- Luego podemos ejecutar el proyecto cliente llamado **Test**

## Detalles

### API (TechnicalAPI)
- Tanto el proyecto API como el Cliente, tienen su configuracion en el archivo *appsettings.json*, que (en el caso del TechnicalAPI), apunta hacia el servidor de base de datos

![image](https://github.com/user-attachments/assets/7096db72-437c-4fcc-b12c-cd20c378bf7c)

el servidor esta representado de manera local con el nombre de la instancia por defecto de SQL Server (SQLEXPRESS)

#### 1. CQRS (Command Query Responsibility Segregation)
CQRS es un patrón de diseño de software que separa las operaciones de lectura (consultas) de las de escritura (comandos). Esto permite optimizar y escalar cada operación de manera independiente, mejorando el rendimiento y la mantenibilidad de la aplicación.

#### 2. UnitOfWork
El patrón UnitOfWork se utiliza para gestionar transacciones en una aplicación. Mantiene un registro de todas las operaciones de base de datos que se realizan en una unidad de trabajo y permite hacer commit o rollback de todas las operaciones en conjunto, asegurando la consistencia de los datos.

#### 3. FluentValidation
FluentValidation es una biblioteca para .NET que permite definir reglas de validación de manera fluida y expresiva. Se utiliza para validar objetos de manera sencilla y mantener el código limpio y organizado.

#### 4. Swagger
Swagger es una herramienta que permite describir la estructura de una API. Genera documentación interactiva y puede crear automáticamente bibliotecas cliente la misma

#### 5. GlobalException
GlobalException se refiere a la gestión global de excepciones en una aplicación. Permite manejar errores de manera consistente en toda la aplicación, reduciendo la duplicación de código y proporcionando un único punto de control para las excepciones.

#### 6. Inyeccion de dependencias
La inyección de dependencias es un patrón de diseño que permite a un objeto recibir sus dependencias de una fuente externa en lugar de crearlas por sí mismo. Esto ayuda a reducir el acoplamiento entre componentes y facilita la prueba y el mantenimiento del código.
Por ejemplo, en la clase *ConnectionDB* hay declarados metodos que funcionan de forma parecida a un UnitOfWork, estan declarados metodos que funcionan para lectura y/o escritura

![image](https://github.com/user-attachments/assets/7d641ddb-38a2-4c60-8257-90eee6d58c9c)


Este método Post toma un objeto MovDTO, prepara los parámetros necesarios, llama a un procedimiento almacenado en la base de datos para obtener y/o escribir datos, y devuelve esos datos en un nuevo objeto MovDTO. El metodo *Read* en este caso funciona como escritura y lectura, ya que hace el post y automaticamente retorna el recurso guardado, los parametros para poder usarlo son un string (que seria el nombre del store procedure de la DB) y una coleccion Hashtable (para declarar los parametros que requiere el sp, importante que los parametros se llamen igual a como se declararon en el procedimiento almacenado)

### CLIENTE (Test)

El proyecto cliente es de tipo ASP.NET Core MVC y sigue el patrón modelo-vista-controlador (MVC).

Utiliza tecnologías simples como HTML, CSS y JavaScript:

HTML: Estructura de la página.
CSS: Para estilos.
JavaScript: Utilizando la biblioteca jQuery para algunos estilos y funcionalidades de las tablas.

Al igual que el proyecto API, la configuración de la URL donde se consumirá la API está declarada en el archivo appsettings.json.

![image](https://github.com/user-attachments/assets/ae9aa4c0-adc7-4b58-a20f-5381af176712)

Por lo general, cuando se ejecuta el comando dotnet run en la ruta TechnicalAPI, se ejecuta automáticamente en el puerto 7014. Sin embargo, esto se puede cambiar dentro de este archivo. Al igual que la API, se ejecuta de manera local.

#### Patrón ViewModel
El patrón ViewModel se utiliza para representar los datos que una vista necesita mostrar. Actúa como un intermediario entre el modelo de datos y la vista, proporcionando una forma estructurada de pasar datos desde el controlador a la vista. Todas las vistas contienen un modelo, algunas de tipo lista, generalmente para la lectura de datos.

Vistas vistas que se pueden observar: 


El "Index" del proyecto, al ejecutarlo se mostrara la vista con los datos de las cards

**Estado de cuenta**: Esta vista representa el estado de cuenta de la card seleccionada 

**Registrar compra**: Esta vista es para registrar nueva compra


**Registrar Pago**: Esta vista es para poder generar un nuevo pago


**Transacciones**: Esta vista tiene las transacciones realizadas

#### Carpeta Util
Las utilidades, que son funciones comunes que se pueden utilizar en alguna parte del proyecto, se encuentran en la carpeta Util


