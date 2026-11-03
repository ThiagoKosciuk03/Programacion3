# Programacion3 — Web API de Productos

Trabajo Práctico Integrador de **Programación 3**.

Web API desarrollada en **ASP.NET Core (.NET 9)** y **C#** que permite consultar productos almacenados en una base de datos **SQL Server**, usando una arquitectura en capas con **Controllers, Services, Repository, Inyección de Dependencias y ADO.NET**.

---

## Endpoints

| Método | Ruta | Descripción | Respuestas |
|---|---|---|---|
| GET | `/api/productos` | Devuelve todos los productos | `200 OK` |
| GET | `/api/productos/{id}` | Devuelve el producto con ese ID | `200 OK` si existe · `404 Not Found` si no existe |

Si ocurre un error al acceder a la base de datos (por ejemplo, SQL Server no disponible), la API responde `500` con un mensaje genérico, sin mostrar información sensible.

Ejemplo de respuesta de `GET /api/productos/1`:

```json
{ "id": 1, "nombre": "Notebook Lenovo", "precio": 850000.00, "stock": 10 }
```

---

## Arquitectura

```
Cliente → ProductosController → IProductoService → ProductoService
        → IProductoRepository → ProductoRepository → ADO.NET → SQL Server
```

| Carpeta | Contenido | Responsabilidad |
|---|---|---|
| `Controllers` | `ProductosController.cs` | Recibe las solicitudes HTTP y devuelve las respuestas (200, 404, 500) |
| `Services` | `IProductoService.cs`, `ProductoService.cs` | Lógica de la aplicación. No contiene SQL |
| `Data` | `IProductoRepository.cs`, `ProductoRepository.cs` | Acceso a datos con ADO.NET (`SqlConnection`, `SqlCommand`, `SqlDataReader`) |
| `Models` | `Producto.cs` | Representa un producto |
| `Database` | `ScriptBaseDatosSQL.sql` | Script para crear la base, la tabla y los datos de prueba |

Las dependencias se registran en `Program.cs` con `AddScoped`.

---

## Requisitos

- [.NET 9 SDK](https://dotnet.microsoft.com/download/dotnet/9.0)
- Visual Studio 2022 (versión 17.12 o superior) con la carga de trabajo **ASP.NET y desarrollo web**
- SQL Server (Express, Developer o un servidor remoto) y SQL Server Management Studio (SSMS)

---

## Cómo ejecutar el proyecto

### 1. Clonar el repositorio

```bash
git clone <URL-DEL-REPOSITORIO>
```

### 2. Crear la base de datos

1. Abrir SQL Server Management Studio y conectarse al servidor.
2. Abrir el archivo `Programacion3/Database/ScriptBaseDatosSQL.sql`.
3. Ejecutarlo (F5).

El script crea la base `Programacion3`, la tabla `Productos` y carga 5 productos de prueba. Solo crea lo que no existe, por lo que se puede ejecutar más de una vez sin duplicar datos.

### 3. Configurar la Connection String

Por seguridad, la connection string real **no se sube al repositorio**. En `appsettings.json` hay solo un valor de ejemplo:

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=SERVIDOR;Database=Programacion3;User Id=USUARIO;Password=PASSWORD;Encrypt=False;"
}
```

La connection string real se configura con **User Secrets** de .NET, que se guardan fuera de la carpeta del proyecto.

**Opción A — Visual Studio:** clic derecho sobre el proyecto `Programacion3` → **Administrar secretos de usuario**, y pegar:

```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=SERVIDOR;Database=Programacion3;User Id=USUARIO;Password=PASSWORD;Encrypt=False;"
  }
}
```

**Opción B — Terminal**, desde la carpeta del proyecto:

```bash
dotnet user-secrets set "ConnectionStrings:DefaultConnection" "Server=SERVIDOR;Database=Programacion3;User Id=USUARIO;Password=PASSWORD;Encrypt=False;"
```

Reemplazar `SERVIDOR`, `USUARIO` y `PASSWORD` por los datos del SQL Server a usar. Ejemplos de `Server`: `localhost\SQLEXPRESS` para un SQL Server Express local, o `IP,PUERTO` para un servidor remoto.

> Si se usa un SQL Server local con **autenticación de Windows**, la cadena es:
> `Server=localhost\SQLEXPRESS;Database=Programacion3;Trusted_Connection=True;TrustServerCertificate=True;`

### 4. Ejecutar

**Visual Studio:** abrir `Programacion3.sln`, elegir el perfil **https** (al lado del botón ▶) y ejecutar.

**Terminal:**

```bash
dotnet run --project Programacion3 --launch-profile https
```

La consola muestra la dirección, por ejemplo `Now listening on: https://localhost:7040`.

### 5. Probar

Abrir en el navegador (o en Postman):

- `https://localhost:7040/api/productos` → lista de productos
- `https://localhost:7040/api/productos/1` → producto con ID 1
- `https://localhost:7040/api/productos/9999` → 404 Not Found

---

## Tecnologías

- ASP.NET Core Web API (.NET 9) · C#
- ADO.NET con el paquete NuGet `Microsoft.Data.SqlClient`
- SQL Server
- Git y GitHub
