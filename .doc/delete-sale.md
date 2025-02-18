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
<p align="center">
    <video width="600" controls>
        <source src="../assets/movies/get-sales.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>
