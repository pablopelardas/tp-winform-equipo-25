# tp-winform-equipo-25 - Gestor de artículos

### Grupo
- Braian Alejandro Valor
- Maria Paula Livingston
- Pablo Martin Pelardas


## Características del programa
- Listado de artículos con conexión a base de datos
- Búsqueda de artículos por distintos criterios
- ABM Artículos
- ABM Categorías / Marcas
- Detalle Artículos

## Conexión a base de datos
Para poder utilizar todos nuestra propia connection string y no exponer nuestras credenciales en github decidimos utilizar un archivo de configuración que no está subido aqui.
Para poder levantar el proyecto con la base de datos hay que:

### 1. Crear el archivo connectionStrings.config
![image](https://github.com/pablopelardas/tp-winform-equipo-25/assets/31576799/0d669dd7-b734-41c1-b3ed-7ae55b3e360a)

Ya que este es llamado en el App.config

![image](https://github.com/pablopelardas/tp-winform-equipo-25/assets/31576799/3e909b36-b02a-4a27-8f1a-03f4ae64102e)

### 2. Escribir en el connectionStrings.config 
![image](https://github.com/pablopelardas/tp-winform-equipo-25/assets/31576799/9830afeb-c3e3-4852-a1d1-40257bfe2b39)

```
<connectionStrings>
  <add name="DefaultConnection" connectionString="TU_CONNECTION_STRING" providerName="System.Data.SqlClient" />
</connectionStrings>
```

NOTA: Si estas usando la connection string escapando la \ por ejemplo: .\\SQLEXPRESS;... Aca no es necesario, va con una barra sola -> .\SQLEXPRESS

## Imagenes Proyecto
![image](https://github.com/pablopelardas/tp-winform-equipo-25/assets/31576799/9a1e25ad-7e97-4d57-97bf-e6b195b90c84)
![image](https://github.com/pablopelardas/tp-winform-equipo-25/assets/31576799/010aedca-59e7-4609-aa64-88feb6229e41)
![image](https://github.com/pablopelardas/tp-winform-equipo-25/assets/31576799/34128514-c250-4b96-a38f-06c4f8858771)

