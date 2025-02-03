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

# **DelogueAssignment.Api**
### **Info**
- **Version**: 1.0

---
### **Paths**
### /api/auth/token

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: TokenRequest

- text/json:

    - $schema: TokenRequest

- application/*+json:

    - $schema: TokenRequest

**Example Value**:

```json
{
    "role" : string
}
```

**[ Responses ]**

code: 200

description: OK

### /ping

**GET**

**[ Responses ]**

code: 200

description: OK

- text/plain:

    - type: string

### /api/Notes/{id}

**GET**

**[ Parameters ]**

| name | in | description | type | required |
|:-----|:-----:|:-----|:-----:|:-----:|
| id | path |  | integer | * |

**[ Responses ]**

code: 200

description: OK

### /api/Notes

**GET**

**[ Parameters ]**

| name | in | description | type | required |
|:-----|:-----:|:-----|:-----:|:-----:|
| take | query |  | integer |  |
| skip | query |  | integer |  |
| sort | query |  | string |  |
| dir | query |  | string |  |

**[ Responses ]**

code: 200

description: OK

### /api/Notes/Create

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: NoteDto

- text/json:

    - $schema: NoteDto

- application/*+json:

    - $schema: NoteDto

**Example Value**:

```json
{
    "id" : integer,
    "content" : string,
    "authorId" : integer,
    "author" : string,
    "taskId" : integer,
    "taskTitle" : string
}
```

**[ Responses ]**

code: 200

description: OK

### /api/Tasks/{id}

**GET**

**[ Parameters ]**

| name | in | description | type | required |
|:-----|:-----:|:-----|:-----:|:-----:|
| id | path |  | integer | * |

**[ Responses ]**

code: 200

description: OK

### /api/Tasks

**GET**

**[ Parameters ]**

| name | in | description | type | required |
|:-----|:-----:|:-----|:-----:|:-----:|
| take | query |  | integer |  |
| skip | query |  | integer |  |
| sort | query |  | string |  |
| dir | query |  | string |  |

**[ Responses ]**

code: 200

description: OK

### /api/Tasks/Create

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: TaskDto

- text/json:

    - $schema: TaskDto

- application/*+json:

    - $schema: TaskDto

**Example Value**:

```json
{
    "id" : integer,
    "title" : string,
    "description" : string,
    "status" : string
}
```

**[ Responses ]**

code: 200

description: OK

### /api/Users/{id}

**GET**

**[ Parameters ]**

| name | in | description | type | required |
|:-----|:-----:|:-----|:-----:|:-----:|
| id | path |  | integer | * |

**[ Responses ]**

code: 200

description: OK

### /api/Users

**GET**

**[ Parameters ]**

| name | in | description | type | required |
|:-----|:-----:|:-----|:-----:|:-----:|
| take | query |  | integer |  |
| skip | query |  | integer |  |
| sort | query |  | string |  |
| dir | query |  | string |  |

**[ Responses ]**

code: 200

description: OK

### /api/Users/Create

**POST**

**[ Request Body ]** 

- application/json:

    - $schema: UserDto

- text/json:

    - $schema: UserDto

- application/*+json:

    - $schema: UserDto

**Example Value**:

```json
{
    "id" : integer,
    "name" : string,
    "email" : string
}
```

**[ Responses ]**

code: 200

description: OK


---
### **Components**
### Schemas
**NoteDto**

**id**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**content**:

- **string**

    - _required: false_

    - _nullable: true_

**authorId**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**author**:

- **string**

    - _required: false_

    - _nullable: true_

**taskId**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**taskTitle**:

- **string**

    - _required: false_

    - _nullable: true_





**TaskDto**

**id**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**title**:

- **string**

    - _required: false_

    - _nullable: true_

**description**:

- **string**

    - _required: false_

    - _nullable: true_

**status**:

- **string**

    - _required: false_

    - _nullable: true_





**TokenRequest**

**role**:

- **string**

    - _required: false_

    - _nullable: true_





**UserDto**

**id**:

- **integer**

    - _format: int32_

    - _required: false_

    - _nullable: false_

**name**:

- **string**

    - _required: false_

    - _nullable: true_

**email**:

- **string**

    - _required: false_

    - _nullable: true_






---
### Security Schemes
**Bearer**

- type: http

- description: Enter 'Bearer {your JWT token}'

- scheme: Bearer

- bearerFormat: JWT

