# Api definition

- [Api definition](#api-definition)
  - [Auth](#auth)
    - [Register](#register)
      - [Request](#request)
      - [Response](#response)
    - [Login](#login)
      - [Request](#request)
      - [Response](#response)

## Auth

### Register

```http
POST {{host}}/auth/register
```

#### Request

```json
{
  "firstName": "string",
  "lastName": "string",
  "email": "string",
  "password": "string"
}
```

#### Response

```http
200 OK
```

```json
{
"id": "string",
"firstName": "string",
"lastName": "string",
"email": "string",
"token": "string"
}
```

### Login

```http
POST {{host}}/auth/login
```

#### Request

```json
{
  "email": "string",
  "password": "string"
}
```

#### Response

```http
200 OK
```

```json
{
"id": "string",
"firstName": "string",
"lastName": "string",
"email": "string",
"token": "string"
}
```
