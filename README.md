# ASP.NET Reverse Proxy Example

This repository contains an example of an ASP.NET Core reverse proxy using YARP (Yet Another Reverse Proxy).

## Medium Blog

For a detailed walkthrough on how to build this reverse proxy, read the [Medium Blog](https://medium.com/@manuel-io/building-a-asp-net-proxy-server-in-3-minutes-754679c442b6).

## Project Structure

- `Program.cs`: The main entry point of the application. Configures the reverse proxy and Kestrel server.
- `CustomTransformer.cs`: Contains custom request and response transformers for the reverse proxy.
- `appsettings.json`: Configuration file for the reverse proxy routes and clusters.
- `sample-reverse-proxy.csproj`: Project file containing dependencies and build configurations.
- `Properties/launchSettings.json`: Configuration for launching the application in different environments.

## Getting Started

### Prerequisites

- [.NET 8.0 SDK](https://dotnet.microsoft.com/download/dotnet/8.0)

### Running the Application

1. Clone the repository:

   ```sh
   git clone https://github.com/your-repo/sample-reverse-proxy.git
   cd sample-reverse-proxy
   ```

2. Update the destination URL in [appsettings.json](http://_vscodecontentref_/0):

   ```json
   "ReverseProxy": {
     "Clusters": {
       "testCluster": {
         "Destinations": {
           "testDestination": {
             "Address": "<your-destination-url>"
           }
         }
       }
     }
   }
   ```

3. Run the application:

   ```sh
   dotnet run
   ```

4. The reverse proxy will be available at `https://localhost:5027`.

### Custom Transformers

The [CustomTransformer](http://_vscodecontentref_/1) class in [CustomTransformer.cs](http://_vscodecontentref_/2) allows you to customize the request and response transformations. The example logs the request and response bodies to the console.

### Configuration

The reverse proxy configuration is defined in [appsettings.json](http://_vscodecontentref_/3). You can define routes and clusters to control how requests are proxied.

### Dependencies

- [YARP.ReverseProxy](https://www.nuget.org/packages/Yarp.ReverseProxy/)
- [Swashbuckle.AspNetCore](https://www.nuget.org/packages/Swashbuckle.AspNetCore/)
- [Microsoft.AspNetCore.OpenApi](https://www.nuget.org/packages/Microsoft.AspNetCore.OpenApi/)

## License

This project is licensed under the MIT License.
