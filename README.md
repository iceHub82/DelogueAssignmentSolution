# DelogueAssignment

## Getting Started

This project is a .NET 8 REST API that runs within Docker using `docker-compose`. It includes:

- A **.NET 8 API** container
- A **SQL Server** container
- **Entity Framework Core** for database management

## Requirements

- Docker
- dotnet

> **Note:** Your submission **must be fully runnable using `docker-compose` only**. Any changes you make should be reflected in the build process so that no manual setup is required.

## Running the Project

To start the project, simply run:

```sh
docker-compose up --build
```

This will:
1. **Build** the API container.
2. **Start** the SQL Server container.
5. **Expose the API** on `http://localhost:8080`.

## Testing

Once running, you can test the API by hitting the `/ping` endpoint:

```sh
curl http://localhost:8080/ping
```

Expected response:

```
pong
```

## Development Notes

- **Ensure all changes are covered in the `Dockerfile` and `docker-compose.yml`**, so that the project remains fully runnable via Docker Compose.
- **Do not require manual setup steps**. Migrations, seeding, and configuration should all be handled within the build process.

Happy coding! 🚀
