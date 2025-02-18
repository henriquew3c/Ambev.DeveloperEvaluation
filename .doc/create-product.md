> [Home](/README.md) > API > Exemples > Create Product

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

Exemple:

https://github.com/user-attachments/assets/d708ec0b-a84a-4709-9784-3aae900e3bbe

