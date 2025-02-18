> [Home](/README.md) > API > Exemples > Update sale

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

Exemple:

https://github.com/user-attachments/assets/beead841-7524-4062-bd4c-0a9dd1158e16

