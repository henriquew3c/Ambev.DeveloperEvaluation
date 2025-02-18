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

Exemple:
<p align="center">
    <video width="600" controls>
        <source src="../assets/movies/auth.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>
