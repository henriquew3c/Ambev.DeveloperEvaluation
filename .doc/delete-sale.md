> [Home](/README.md) > API > Exemples > Delete sale

## Delete Sale. Delete to /api/Sale/{id}

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

Exemple:

https://github.com/user-attachments/assets/21aa9825-8f0f-4e9c-a5f8-f4d15ea70404

