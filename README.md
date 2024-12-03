# Prototype Sales API

Implementation of a Restfull API prototype for sales handling.

## Tech Stack

Technologies in this project:

Backend:
- **.NET 8.0**: A free, cross-platform, open source developer platform for building many different types of applications.
  - Git: https://github.com/dotnet/core
- **C#**: A modern object-oriented programming language developed by Microsoft.
  - Git: https://github.com/dotnet/csharplang

Testing:
- **xUnit**: A free, open source, community-focused unit testing tool for the .NET Framework.
  - Git: https://github.com/xunit/xunit

Databases:
- **PostgreSQL**: A powerful, open source object-relational database system.
  - Git: https://github.com/postgres/postgres
- **MongoDB**: A general purpose, document-based, distributed database.
  - Git: https://github.com/mongodb/mongo
 
## Frameworks

Frameworks in this project:

Backend:
- **Mediator**: A behavioral design pattern that helps reduce chaotic dependencies between objects. It allows loose coupling by encapsulating object interaction.
  - Git: https://github.com/jbogard/MediatR
- **Automapper**: A convention-based object-object mapper that simplifies the process of mapping one object to another.
  - Git: https://github.com/AutoMapper/AutoMapper

Testing:
- **Faker**: A library for generating fake data for testing purposes, allowing for more realistic and diverse test scenarios.
  - Git: https://github.com/bchavez/Bogus
- **NSubstitute**: A friendly substitute for .NET mocking libraries, used for creating test doubles in unit testing.
  - Git: https://github.com/nsubstitute/NSubstitute

Database:
- **EF Core**: Entity Framework Core, a lightweight, extensible, and cross-platform version of Entity Framework, used for data access and object-relational mapping.
  - Git: https://github.com/dotnet/efcore

## Instructions for use

1) Run docker compose to iniciate the conteiners
2) Run the command update-database to create tables in database. If it doesn't work look the appsettings conection string. By default the port postgresql 5432 is exposed.
3) Use swagger (or another toool) to create your user. Post to /api/Users

## User

 ### Create User. Post to /api/User 
   
Request:

```json
{
  "username": "Henrque Souza",
  "password": "dC<88?9n^!,r",
  "phone": "+556393409293",
  "email": "email@gvalid.com",
  "status": 1,
  "role": 1
}
```

Respose:

```json
{
    "data": {
        "id": "5f3cd73d-ba5f-4dbd-85f5-ebb871eb6e71",
        "username": "Henrique Souza",
        "email": "email@valid.com",
        "phone": "+556393409293",
        "role": 1,
        "status": 1
    },
    "success": true,
    "message": "User created successfully",
    "errors": []
}
```

## Get User. Get to /api/User/{id}

Response:

```json
{
  "data": {
    "data": {
      "id": "5f3cd73d-ba5f-4dbd-85f5-ebb871eb6e71",
      "username": "",
      "email": "email@valid.com",
      "phone": "+5563992028333",
      "role": 1,
      "status": 1
    },
    "success": true,
    "message": "User retrieved successfully",
    "errors": []
  },
  "success": true,
  "message": "",
  "errors": []
}
```

## Delete User. Delete to /api/User/{id}

```json
{
  "data": {
    "success": true,
    "message": "User deleted successfully",
    "errors": []
  },
  "success": true,
  "message": "",
  "errors": []
}
```

## Authorize

### Auth User. Post to /api/Auth 
   
Request:

```json
{
   {
    "email": "email@gvalid.com",
    "password": "dC<88?9n^!,r"
  }
}
```

Response:

```json
{
  "data": {
    "data": {
      "token": "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1laWQiOiI1ZjNjZDczZC1iYTVmLTRkYmQtODVmNS1lYmI4NzFlYjZlNzEiLCJ1bmlxdWVfbmFtZSI6IkhlbnJpcXVlIFNpbHZhIiwicm9sZSI6IkN1c3RvbWVyIiwibmJmIjoxNzMyNjQ0NzAzLCJleHAiOjE3MzI2NzM1MDMsImlhdCI6MTczMjY0NDcwM30.mSpA37DyiIG9jHf5vcLF1EmQJEzdqVMzknJNEoLh-DE",
      "email": "email@valid.com",
      "name": "Henrique Silva",
      "role": "Customer"
    },
    "success": true,
    "message": "User authenticated successfully",
    "errors": []
  },
  "success": true,
  "message": "",
  "errors": []
}
```

## Product

### Create one product to usage in sale. Post to /api/Product. 
   
Request:

```json
{
  "name": "Fantastic Cotton Hat",
  "price": 100
}
```

Responde:

```json
{
    "data": {
        "id": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
        "name": "Fantastic Cotton Hat",
        "price": 100
    },
    "success": true,
    "message": "Product created successfully",
    "errors": []
}
```

## Sale

### Create sales. Post to /api/Sale. 
   
Request:

```json
{
  "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
  "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
  "date": "2024-11-25T02:20:06.442Z",
  "products": [
    {
      "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
      "quantity": 20
    }
  ]
}
```

Response:

```json
"data": {
        "id": "e8666c40-f913-410e-8c77-537b66559996",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "products": [
            {
                "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
                "quantity": 20
            }
        ]
    },
    "success": true,
    "message": "Sale created successfully",
    "errors": []
}
```

### Update sale. Put to /api/Sale. 
   
Request:

```json
{
  "saleId": "e8666c40-f913-410e-8c77-537b66559996",
  "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
  "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
  "updateAt": "2024-11-25T21:15:11.262Z",
"status": 2,
  "products": [
    {
      "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
      "quantity": 15
    }
  ]
}
```

Response:

```json
{
  "data": {
      "data": {
          "id": "e8666c40-f913-410e-8c77-537b66559996",
          "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
          "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
          "createAt": "2024-11-25T02:20:06.442Z",
          "products": [
               {
                  "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
                  "quantity": 15
                }
          ],
          "status": "Pending"
      },
      "success": true,
      "message": "Sale updated successfully",
      "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
}
```

PS.: Satatus supported: 1 (Pending), 2 (Cancelled) or 3 (Finish). 

### Get sale. Get to /api/Sale/{id}. 
   
Response:

```json
{
    "data": {
        "data": {
            "id": "e8666c40-f913-410e-8c77-537b66559996",
            "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
            "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
            "createAt": "2024-11-25T02:20:06.442Z",
            "totalAmount": 1600.00,
            "discountAmount": 400.00,
            "discountPercent": 0.20
        },
        "success": true,
        "message": "Sale retrieved successfully",
        "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
}
```

### Get all sales. Get to /api/Sales. 

Params: pageNumber, pageSize. Defalt values: 1, 10

Response:

```json
{
  "data": {
    "currentPage": 1,
    "totalPages": 1,
    "totalCount": 6,
    "data": [
      {
        "id": "4a47b943-fe83-46fb-93d5-ca9d705c97a8",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "totalAmount": 1520,
        "discountAmount": 380,
        "discountPercent": 0.2,
        "products": [
          {
            "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
            "quantity": 19
          }
        ]
      },
      {
        "id": "8b48a961-4c64-417d-9985-dcaec3ee60dc",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "totalAmount": 1520,
        "discountAmount": 380,
        "discountPercent": 0.2,
        "products": [
          {
            "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
            "quantity": 19
          }
        ]
      },
      {
        "id": "9166aa1e-4c2d-4946-9902-ecd271633811",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "totalAmount": 1520,
        "discountAmount": 380,
        "discountPercent": 0.2,
        "products": [
          {
            "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
            "quantity": 19
          }
        ]
      },
      {
        "id": "9496297f-1850-4df0-994a-fdd6f4f09301",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "totalAmount": 1600,
        "discountAmount": 400,
        "discountPercent": 0.2,
        "products": [
          {
            "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
            "quantity": 20
          }
        ]
      },
      {
        "id": "e0b097a5-5ba2-40ce-a929-d62a06617ab9",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "totalAmount": 1600,
        "discountAmount": 400,
        "discountPercent": 0.2,
        "products": [
          {
            "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
            "quantity": 20
          }
        ]
      },
      {
        "id": "e8666c40-f913-410e-8c77-537b66559996",
        "customerId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "branchId": "122c618e-adb6-4dd6-a545-b48b9d42117a",
        "createAt": "2024-11-25T02:20:06.442Z",
        "totalAmount": 1600,
        "discountAmount": 400,
        "discountPercent": 0.2,
        "products": [
          {
            "productId": "262baec5-50e8-4abb-8e7a-6c6470d3560a",
            "quantity": 20
          }
        ]
      }
    ],
    "success": true,
    "message": "",
    "errors": []
  },
  "success": true,
  "message": "",
  "errors": []
}
```

### Delete Sale. Delete to /api/Sale/{id}

Response:

```json
{
    "data": {
        "success": true,
        "message": "Sale deleted successfully",
        "errors": []
    },
    "success": true,
    "message": "",
    "errors": []
}
```

PS.: Row not removed, only soft delete update. Status changed to Deleted and DeleteAt filled.
