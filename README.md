# ASP.NET Core Auth API

A simple ASP.NET Core API with **user registration and login** using **JWT authentication**, **PostgreSQL**, and **BCrypt password hashing**.

---

## Prerequisites

* [.NET 7 SDK](https://dotnet.microsoft.com/download/dotnet/7.0)
* [PostgreSQL](https://www.postgresql.org/download/)
* [Visual Studio Code](https://code.visualstudio.com/) or Visual Studio
* `dotnet-ef` tool for migrations:

```bash
dotnet tool install --global dotnet-ef
```

---

## Setup Instructions

### 1. Clone the repository

```bash
git clone https://github.com/saveyear01/dotnet-simple-api.git
cd dotnet-simple-api
```

### 2. Configure PostgreSQL

* Create a database:

```sql
CREATE DATABASE "AuthApiDb";
```

* Update the connection string in `appsettings.json`:

```json
"ConnectionStrings": {
  "DefaultConnection": "Host=localhost;Port=5432;Database=AuthApiDb;Username=postgres;Password=yourpassword"
},
```

---

### 3. Install dependencies

```bash
dotnet restore
dotnet add package Npgsql.EntityFrameworkCore.PostgreSQL
dotnet add package Microsoft.EntityFrameworkCore.Design
dotnet add package BCrypt.Net-Next
dotnet add package Microsoft.IdentityModel.Tokens
dotnet add package System.IdentityModel.Tokens.Jwt
```

---

### 4. Run EF Core migrations

```bash
dotnet ef migrations add InitialCreate
dotnet ef database update
```

---

### 5. Build and run the application

```bash
dotnet build
dotnet run
```

The API should now be running at:

```
https://localhost:7045/swagger
http://localhost:5216/swagger
```

---

### Notes

* Passwords are hashed with **BCrypt** before storing.
* JWT tokens are generated using **HS256** with a 32+ character key.
* Make sure PostgreSQL credentials and database names match your `appsettings.json`.
