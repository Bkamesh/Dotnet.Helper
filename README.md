
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

---
