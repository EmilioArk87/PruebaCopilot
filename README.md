# 🐍 Snake Game App

Aplicación web desarrollada con .NET 8 y C# para registrar puntajes de Snake Game con conexión a SQL Server.

## 📋 Características

- **Registro de puntajes**: Guarda nickname, tiempo de juego (segundos) y puntaje logrado
- **Tabla de líderes**: Visualización ordenada por puntaje (mayor a menor)
- **Interfaz amigable**: Diseño responsive con Bootstrap y emojis
- **Base de datos**: Integración con SQL Server usando Entity Framework Core
- **Validación**: Validación de datos tanto del lado cliente como servidor

## 🛠️ Tecnologías Utilizadas

- **.NET 8** - Framework principal
- **ASP.NET Core Razor Pages** - Framework web
- **Entity Framework Core** - ORM para base de datos
- **SQL Server** - Base de datos principal
- **SQLite** - Opción alternativa para desarrollo/testing
- **Bootstrap 5** - Framework CSS para diseño responsive
- **C#** - Lenguaje de programación

## 📁 Estructura del Proyecto

```
SnakeGameApp/
├── Models/
│   └── GameRecord.cs          # Modelo de datos para registros de juego
├── Data/
│   └── GameDbContext.cs       # Contexto de base de datos
├── Pages/
│   ├── GameRecords/
│   │   ├── Index.cshtml       # Lista de registros (tabla de líderes)
│   │   ├── Index.cshtml.cs
│   │   ├── Create.cshtml      # Formulario para nuevo registro
│   │   └── Create.cshtml.cs
│   ├── Shared/
│   │   └── _Layout.cshtml     # Layout principal
│   └── Index.cshtml           # Página de inicio
├── Program.cs                 # Configuración de la aplicación
└── appsettings.json          # Configuración (cadenas de conexión)
```

## ⚙️ Configuración

### 1. Base de Datos

#### SQL Server (Producción)
```json
{
  "ConnectionStrings": {
    "DefaultConnection": "Server=(localdb)\\mssqllocaldb;Database=SnakeGameDB;Trusted_Connection=true;MultipleActiveResultSets=true"
  }
}
```

#### SQLite (Desarrollo/Testing)
Para usar SQLite, modifica `Program.cs` comentando la configuración de SQL Server y descomentando:
```csharp
builder.Services.AddDbContext<GameDbContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("SQLiteConnection")));
```

### 2. Instalación de Dependencias

```bash
# Restaurar paquetes NuGet
dotnet restore

# Instalar herramientas de Entity Framework (si no están instaladas)
dotnet tool install --global dotnet-ef
```

### 3. Migración de Base de Datos

```bash
# Crear migración inicial
dotnet ef migrations add InitialCreate

# Aplicar migración a la base de datos
dotnet ef database update
```

## 🚀 Ejecución

```bash
# Compilar el proyecto
dotnet build

# Ejecutar la aplicación
dotnet run
```

La aplicación estará disponible en `https://localhost:5001` o `http://localhost:5000`

## 📊 Modelo de Datos

### GameRecord
```csharp
public class GameRecord
{
    public int Id { get; set; }                    // ID único
    public string Nickname { get; set; }           // Nickname del jugador (máx. 50 caracteres)
    public int PlayTimeSeconds { get; set; }       // Tiempo de juego en segundos
    public int Score { get; set; }                 // Puntaje logrado
    public DateTime CreatedAt { get; set; }        // Fecha y hora de creación
}
```

## 🏆 Funcionalidades

### Página Principal
- Bienvenida con enlaces a las funciones principales
- Navegación intuitiva con iconos

### Tabla de Líderes
- Ordenación automática por puntaje (mayor a menor)
- Medallas para las primeras 3 posiciones (🥇🥈🥉)
- Información completa: posición, nickname, puntaje, tiempo y fecha

### Registro de Nuevo Puntaje
- Formulario validado para ingresar:
  - Nickname (requerido, máx. 50 caracteres)
  - Puntaje (requerido, número entero)
  - Tiempo de juego en segundos (requerido, número entero)
- Redirección automática a la tabla de líderes después del registro

## 🎮 Capturas de Pantalla

La aplicación incluye una interfaz moderna y amigable con:
- Diseño responsive que se adapta a diferentes dispositivos
- Uso de emojis para una experiencia visual atractiva
- Colores y badges para destacar información importante
- Navegación clara y accesible

## 👨‍💻 Desarrollo

### Comandos Útiles

```bash
# Limpiar y reconstruir
dotnet clean && dotnet build

# Ejecutar en modo de desarrollo con hot reload
dotnet watch run

# Crear nueva migración
dotnet ef migrations add NombreMigracion

# Revertir migración
dotnet ef migrations remove
```

## 📝 Notas Adicionales

- La aplicación crea automáticamente la base de datos al iniciar si no existe
- Los registros se ordenan por puntaje de mayor a menor, y en caso de empate, por menor tiempo de juego
- El diseño es completamente responsive y compatible con dispositivos móviles
- Incluye validación tanto del lado cliente como del servidor para garantizar la integridad de los datos