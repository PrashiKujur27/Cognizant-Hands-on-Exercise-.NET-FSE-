# JWT Authentication Lab

## Run
```bash
dotnet restore
dotnet run
```

Open Swagger.

POST `/api/Auth/login`

```json
{
 "username":"admin",
 "password":"admin123"
}
```

Copy the returned JWT.

Click **Authorize** in Swagger and paste:

`Bearer <token>`

Then call:

`GET /api/Auth/secure`
