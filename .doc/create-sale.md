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

https://github.com/user-attachments/assets/833c3832-7e87-4067-915b-9b6119291038

### View message events into RabbitMQ queue

RabbitMQ is a message broker that allows applications to communicate with each other by sending and receiving messages through queues. A topic in RabbitMQ is a type of exchange that routes messages to one or more queues based on a routing key.

> [!IMPORTANT]
> User and password into .env.

To access and view message events in a RabbitMQ queue, follow these steps:

1. **Access RabbitMQ Management Console**: Open the RabbitMQ Management Console by navigating to `http://localhost:15672/` in your web browser. Log in with the default credentials (`guest`/`guest`).

<p align="center">
  <img src="/assets/img/sale-registered-queue.png" alt="sale-registered-queue" />
</p>
