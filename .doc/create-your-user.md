> [Home](/README.md) > API > Exemples > Create user

 ## Create User. Post to /api/User

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

Exemple:

https://github.com/user-attachments/assets/638b740e-9134-4c91-bb82-9817f8df419d

