> [Home](/README.md) > API > Exemples > Create sale

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

Exemple:
<p align="center">
    <video width="600" controls>
        <source src="../assets/movies/create-sale.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>
