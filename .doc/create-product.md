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
<p align="center">
    <video width="600" controls>
        <source src="../assets/movies/create-product.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>
