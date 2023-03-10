# EjercicioPasanteHexacta

Es probable que la URL del servidor generada difiera de la utilizada durante el desarrollo de este proyecto <code>(https://localhost:7055)</code>, por lo que sería conveniente modificar la propiedad <code>baseUrl</code> ubicada en <code>ClientApp > src > environments > environment.ts</code> por la URL del servidor actual.</p>

# Preguntas teóricas

Parte B: 
Pensar que diferencia hay entre eso y hacer el filtro en frontend sin resolverlo a nivel BD. Explicar esto con sus palabras.

**La diferencia entre filtrar los datos en el backend y el frontend es que al hacerlo en el fronend estamos obteniendo todos los datos de una tabla de la bd, lo que es muy ineficiente , ralentizando el programa. Al hacer el filtro desde el backend obtenemos solo los registros que queremos utilizar agilizando la petición.**

Parte C: Formulario para alta de Personas con validaciones de campos. Pregunta: que tipos de validaciones puede tener un sistema? donde se debieran implementar?

### Tipos de validaciones: 

***De tipo:* validar si el tipo del dato ingresado es válido. Por ejemplo: si el dato a ingresar es un nombre no se deberían aceptar numeros.**

***Obligatoriedad*: validar si el dato es necesario u opcional.**

***De rango:* validar si el dato se encuentra dentro de un rango establecido. Por ejemplo: La edad de una persona debe estar entre los 0 y 200 años.**

***De autenticación:* validar si el usuario actual tiene acceso a distintas fucionalidades del sistema.**

**Se deberían implementar en el backend dentro de los controladores, aunque tambien es muy importante realizar validaciones en el frontend para evitar que lleguen datos inválidos al servidor.**

Otras preguntas:

1. ¿Qué es un ORM? Ventajas y desventajas.

**Un ORM es un modelo de programación que se utiliza para mappear a los objetos de un dominio determinado con sus datos correspondientes que se encuentran en una base de datos relacional. Ejs: Hibernate, EntityFramework, etc.**

***Ventajas:*  simplifica la cantidad de codigo necesaria para realizar el mappeo entre la base de datos y los objetos,  facilitando la persistencia de los datos.**

***Desventajas:* En sistemas con mucha carga puede llegar a reducir el rendimiento ya que se está agregando una capa extra al sistema.**

2. Diferencias entre: cliente de BD vs driver de conexión de BD vs motor de base de datos (Dar ejemplos)

**Cliente de BD:  programa que tiene el fin de facilitar el uso de los servicios brindados por un motor de base de datos.** Ejs: DBeaver, Sql Server Managment Studio, MySqlWorkbench.

**Motor de BD: software capaz de agregar, eliminar y leer datos de una base de datos.** Ejs: MySql, SQLServer.

**Driver de Conexión de BD:  programa utilizado para conectar una aplicación a una base de datos. Funciona como un adaptador entre ambos entornos** Ejs: JDBC, ODBC.

4. ¿Qué es la integridad referencial de una BD? ¿Cómo se logra?

**La integridad referencial es una propiedad de las bases de datos que hace alusión a que si un registro de la tabla A tiene como atributo una referencia a un registro de la tabla B, este último debe existir. Por lo que no se puede crear un registro en la tabla A sin que existan todos los registros a los que este hace referencia y tampoco se pueden eliminar registros de la tabla B que contengan relaciones con otras tablas.**

**Se puede lograr estableciendo las PK y FK correspondientes en cada tabla y validar que existen las referencias necesarias al crear un nuevo registro.**

5. ¿Qué es un índice en una BD? ¿Cuándo se usa?

**Un índice es un puntero a un registro determinado que nos permite la organizacion de la información con el fin de optimizar una busqueda de registros, comenzando la busqueda en un registro particular. Este puntero es una referencia que asocia el valor que se encuentra en un registro de la tabla con el valor determinado del puntero. Se usa en las tablas que tienen una gran cantidad de registros, ya que una busqueda lineal por toda la tabla sería ineficiente.**

6. ¿Qué son las transacciones de una BD? 

**Acciones que se realizan sobre una base de datos (insertar, eliminar o modificar registros)**

7. ¿Qué es normalizar una base de datos? ¿Para qué sirve? ejemplos

**Normalizar una base de datos consiste en aplicar determinadas reglas para que la misma no tenga datos redundantes o complejos inncesariamente**
Ej: 
(1FN): 

| PersonaId | Nombre   | Edad | GrupoEtarioYEstadoCivil | CodigoArticulo | Precio | Ubicacion |
|-----------|----------|------|-------------------------|----------------|--------|-----------|
| 1         | Pepe     | 10   | Niños-Soltero           | 001            | 150    | 2500      |
| 2         | Pablo    | 25   | Adolescentes-Soltero    | 001            | 150    | 2500      |
| 3         | Patricio | 58   | Adultos-Casado          | 002            | 300    | 4590      |

==> Separar GrupoEtarioYEstadoCivil en dos columnas, generar FK para CodigoArticulo y crear otra tabla que contiene los datos del Articulo

| PersonaId | Nombre   | Edad | GrupoEtario  | EstadoCivil |CodigoArticulo|
|-----------|----------|------|--------------|-------------|--------------|
| 1         | Pepe     | 10   | Niños        | Soltero     |001     	  |
| 2         | Pablo    | 25   | Adolescentes | Soltero     |001    	 	  |
| 3         | Patricio | 58   | Adultos      | Casado      |002           |

| CodigoArticulo | Precio | Ubicacion |
|----------------|--------|-----------|
| 001            | 150    | 2500      |
| 001            | 150    | 2500      |
| 002            | 300    | 4590      |

 
8. ¿Qué son los stored procedures?

**Es código SQL que está almacenado para ser reutilizado.  Se utiliza para no repetir la creación de una query idéntica una y otra vez.**

9. ¿Cuáles son los tipos de queries de BD más comunes? ¿Para que sirve cada uno? ejemplos
 
 CREATE TABLE  (crea una tabla)
 Ej: CREATE TABLE persona (id INTEGER PRIMARY KEY, nombre TEXT, edad INTEGER);

SELECT (seleccionar y ver todos los registros de una tabla)
Ej: SELECT * FROM persona; (en este caso todos los campos)

INSERT INTO (insertar registros en una tabla)
Ej: INSERT INTO persona (id,nombre,edad) VALUES ('1','Julian',22);

ORDER BY (definir el orden de los registros al seleccionarlos)
Ej: SELECT * FROM personas ORDER BY edad; (de menor a mayor edad)
Ej: SELECT * FROM personas DESC ORDER BY edad; (de mayor a menor edad)

DELETE (eliminar registros de la tabla)
Ej: DELETE FROM persona WHERE name ='Julian' (utilizando la clausula WHERE para tomar los registros que cumplan la condicion establecida)

UPDATE (cambiar algun campo de un registro)
Ej: UPDATE persona SET edad = 77 WHERE nombre = "Julian"

11. ¿Qué es una API REST?

**Es una interfaz que permite la comunicación entre dos sistemas utilizando el protocolo HTTP para obtener o enviar datos mediante distintos formatos, como por ejemplo el JSON**
### Verbos más utilizados:
- GET: Obtener información de un recurso (puede contener parametros para filtrar los datos a recibir)
- POST: Crear un recurso (enviando datos en el body)
- PUT:  Actualizar un recurso
- PATCH: Actualizar parcialmente un recurso
- DELETE: Eliminar un recurso

12. Diferencias entre un test unitario vs un test de integración

**La diferencia entre un test unitario y un test de integración es que el primero es utilizado para probar un método o funcionalidad concreta y el de integración tiene como fin comprobar que los componentes que forman parte de un proceso funcionan bien al trabajar en conjunto.**

13. ¿Para que se usan los mocks en los unit test?

**Los mocks tienen el fin de imitar el comportamiento de clases específicas, pudiendo definir lo que devolverá un método. Se utilizan para no necesitar dependencias externas a la hora de realizar tests.  Son muy útiles en las situaciónes que se necesite testear una funcionalidad que hace uso de un servicio que pueda generar algún costo.**

