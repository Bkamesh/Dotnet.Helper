
# Dotnet.Helper

A utility library for common helper classes, extensions, and custom exceptions to simplify .NET development.

---

## 📦 Project Structure

```
Dotnet.Helper/
├── BaseEntity/                 # Base entity classes (if applicable)
├── Encryptions/                # Encryption-related utilities
├── Exceptions/                 # Custom exception classes
│   ├── BadRequestException.cs
│   ├── NotFoundException.cs
│   └── TimeOutException.cs
├── Extensions/                 # Extension methods
│   ├── ApplicationExtensions.cs
│   └── BuilderExtensions.cs
├── Helpers/                    # Helper utilities
│   ├── HealthCheckHelper.cs
│   └── RedisHelper.cs
├── dotnet.helper.csproj         # Project file
```

---

## ⚡ Features

✅ Custom exception classes for consistent error handling  
✅ Useful extension methods for applications and builders  
✅ Health check utilities  
✅ Redis helper functions (for caching or distributed operations)  
✅ Placeholder for encryption utilities (implement as needed)  

---

## 🛠 Requirements

- .NET 8.0 SDK or higher

---

## 🚀 Usage

You can include this project as a library in your .NET applications:

```bash
dotnet add reference path/to/dotnet.helper.csproj
```

Then, use the helpers and extensions as needed:

```csharp
using Dotnet.Helper.Exceptions;
using Dotnet.Helper.ApplicationExtensions;
using Dotnet.Helper.BuilderExtensions;
using Dotnet.Helper.Helpers;
```

---

## 🧩 Example

```csharp
if (data == null)
{
    throw new NotFoundException("Data not found");
}

services.AddRedisHelper(configuration);
```
### 📦 Create NuGet Package (`.nupkg`)

Ensure your `dotnet.helper.csproj` includes:

```xml
<PropertyGroup>
  <GeneratePackageOnBuild>true</GeneratePackageOnBuild>
  <PackageId>Dotnet.Helper</PackageId>
  <Version>1.0.0</Version>
  <Authors>YourName</Authors>
  <Description>Helper utilities for .NET projects</Description>
  <TargetFramework>net8.0</TargetFramework>
</PropertyGroup>
```

Build the NuGet package:

```bash
dotnet pack -c Release -o ./dotnet.helper.nupkg
```

---

### 📤 Publish to GitHub Packages

#### 1. Add GitHub NuGet Source

```bash
dotnet nuget add source \
  --username <your-username> \
  --password <your-personal-access-token> \
  --store-password-in-clear-text \
  --name github \
  "https://nuget.pkg.github.com/<your-username>/index.json"
```

> Replace `<your-username>` and `<your-personal-access-token>` (with `write:packages` + `repo` scopes).

#### 2. Push the `.nupkg` to GitHub Packages

```bash
dotnet nuget push ./dotnet.helper.nupkg/*.nupkg -s github
```

---
