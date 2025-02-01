# Backend Prueba

### Requisitos

1.- Se usaron paquetes correspondientes a versiones de Net 6.0
- Swagger
- SqlClient

2.- Se utiliza la base de datos de SQL Server 2022 con las siguientes credenciales

#### Local
- **user:** sa
- **password:** 1234

#### Docker
- **user:** sa
- **password:** Abc!1234

3.- Se utiliza una version del Docker para Linux, el Dockerfile construira el contenedor para que se ejecute remotamente

### Funcionamiento

1.- El backend funciona con el puerto asignado por Docker (8085) o por el puerto local (44306)

2.- Se usa variables de entorno para la ejecución de la base de datos
- **DevConnection (Local): "Data Source=localhost, 1433;Initial Catalog=navegacion_dinamica;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"**
- **DevConnection (Docker): "Data Source=192.168.3.40, 1433;Initial Catalog=navegacion_dinamica;User ID=sa;Password=1234;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False"**
  
3.- Se utiliza un script SQL para la ejecución de creación de base de datos, tablas y procedimientos almacenados, sin necesidad de un Entity Framework

4.- Se utilizaron Controladores, Repositorios, Modelos y Servicios para una correcta arquitectura

5.- Se ejecuta el programa por medio de consola o por el Docker para que se proyecte el microservicio

### Local
![image](https://github.com/user-attachments/assets/f7c5eb1c-836b-4225-af13-d4427d18b88f)

### Docker

![image](https://github.com/user-attachments/assets/2048731c-f64d-4682-9a28-7480063ad45e)

## Contenedor Docker

![image](https://github.com/user-attachments/assets/6091fae4-c986-4f9d-85ed-9a5f0915a3e5)


