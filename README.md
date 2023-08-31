# LogisticSolution

Pasos para ejecutar la solucion localmente
- Crear una bd en sql server 2019 con cualquier nombre deseado
- En el archivo Appsettings.json configurar la cadena de coneccion
- En el visual studio abrir la consola de paquetes y ejecutar el comando: Update-Database
- Ejecutar el projecto en visual studio

En el proyecto se crearon Crud para 4 tablas: DeliverySchedule, Location, User y ProductCategory
ademas de documentarse con swagger, el proyecto de test unitarios no funciona el error se debe a que 
debi implementar Interfaces y no entidades concretas y me di cuenta muy tarde como para refactorizar.
