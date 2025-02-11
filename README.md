# LubriSoft

Este sistema fue creado para un lubricentro como una alternativa al uso de planillas de calculo para registrar la información de los servicios de aceite y mecanica. 

Funciones Principales:
- Alta, baja y modificación de Service, Mecanica, Clientes y Vehiculos
- Búsqueda de Service, Mecanica, Clientes y Vehiculos por distintos parametros
- Impresion de comprobantes de Service y Mecanica

Caracteristicas Destacables:
- Seguro y testeado para el uso de multiples usuarios en simultaneo
- Fully responsive (PC o Tablet para mejor experiencia)
- Ligero, compacto y fácil de escalar

Software requerido para su desarrollo:
- Microsoft Visual Studio 2022 + Paquete de desarrollo .NET 8 con Blazor.
- Microsoft SQL Server Management Studio (opcional, pero altamente recomendado).
- Microsoft SQL Server Express (requerido en la configuración actual del proyecto, opcional si se usa otra base de datos).

Pasos para la primera ejecución:

1) Si usa Microsoft SQL Server Express con su configuración predeterminada entonces puede saltar directamente al paso 3.
2) Modificar el string de conexión en el archivo "appsettings.json" para usar la base de datos de su preferencia.
3) Desde la consola del administrador de paquetes ejecutar "update-database" para crear una instancia nueva de la base de datos.
4) Ejecutar la aplicación en HTTP o HTTPS según lo requiera y probar que las operaciones CRUD funcionen correctamente.

