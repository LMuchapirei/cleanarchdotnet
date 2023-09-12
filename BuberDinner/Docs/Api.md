# Buber Dinner API

-[Buber Diner API](#buber-dinner-api)
 - [Auth](#auth)
    - [Register](#register)
      - [Register Request](#register-request)
      - [Register Response](#register-response)
    - [Login](#login)
      - [Login Request](#login-request)
      - [Login Response](#login-request)

## Auth 

### Register

```js
POST {{host}}/auth/register
```

#### Register Request

```json
{
    "firstName": "Linval",
    "lastName":"Muchapirei",
    "email":"muchapireil@gmail.com",
    "password":"zipassword"
}
```
#### Register Response

```js
200 OK
```

```json
{
    "id":"ddhd929-dhdj3-sdjd-383dd-393939ndjjs",
    "firstName": "Linval",
    "lastName":"Muchapirei",
    "email":"muchapireil@gmail.com",
    "token":"ecyJb..hshsQQ"
}
```

### Login

```js
POST {{host}}/auth/login
```
#### Login Request

```json
{
    "email":"muchapireil@gmail.com",
    "password":"zipassword"
}
```

#### Login Response

```js
200 OK
```

```json

{
    "id":"ddhd929-dhdj3-sdjd-383dd-393939ndjjs",
    "firstName": "Linval",
    "lastName":"Muchapirei",
    "email":"muchapireil@gmail.com",
    "token":"ecyJb..hshsQQ"
}