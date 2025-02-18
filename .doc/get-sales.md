### Sale

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

Exemple:
<p align="center">
    <video width="600" controls>
        <source src="../assets/movies/get-sales.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>
