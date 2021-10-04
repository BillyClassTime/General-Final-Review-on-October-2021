# Generating C# HTTP Clients by Using AutoRest

La siguiente demostración nos ayuda a entender la generación del cliente Http desde un API WEB (API Rest)

## Instalamos el AutoRest

Para generar un cliente Http (HttpClient) usando Autorest hemos de realizar lo siguiente:

1 - Instalamos la ultima version de Autorest con parametro global:

```
npm install -g autorest
```

2 - Después de la instalación, desinstalamos cualquier versión anterior

```
autorest --reset
```

3 - Actualizamos la ultima versión y extensiones

```
autorest --latest
```



Creamos una Web API (API Rest)

Para la demostración hemos utilizado el siguiente código:

1 - Creamos un proyecto web api

```powershell
mkdir AutoRest
```
```powershell
cd AutoRest
mkdir AutoRest.Host
mkdir AutoRest.Sdk
mkdir AutoRest.Client
```
2 - Creamos y editamos el Proyecto Host en la carpeta AutoRest.Host

```powershell
dotnet new webapi
```
3 - Creamos una carpeta Model y movemos el fichero WeatherForecast allí, y creamos un fichero Destination.cs con el siguiente contenido:
```csharp
namespace AutoRest.Host.Models
{
    public class Destination
    {
        public int Id { get; set; }

        public string CityName { get; set; }

        public string Airport { get; set; }
    }
}
```
El fichero Destination.cs deberá quedar con el siguiente namespace:
```csharp
namespace AutoRest.Host.Models
```
4 - Movemos el fichero WeatherForecastController.cs a la carperta Controllers, las lineas antes del namespace deberán quedar así:
```csharp
using AutoRest.Host.Models;
namespace AutoRest.Host.Controllers
```
5 - El fichero Program.cs deberá quedar así
```csharp
using Microsoft.AspNetCore.Hosting;
namespace AutoRest.Host
{
    using Microsoft.Extensions.Hosting;
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }
        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
```
