# Api definition

- [Api definition](#api-definition)
    - [Menu](#menu)
        - [Create Menu](#create-menu)
            - [Request](#request)
            - [Response](#response)


## Menu

### Create Menu

```http request
POST /hosts/{hostId}/menus
```

#### Request

```json
{
  "name": "Common Menu",
  "description": "A menu with common food",
  "sections": [
    {
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "name": "Fried Pickles",
          "description": "Deep fried pickles"
        }
      ]
    }
  ]
}
```

#### Response

```http request
201 Created
```