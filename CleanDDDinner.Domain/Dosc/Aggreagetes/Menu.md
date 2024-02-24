# Domain Models

## Menu

```csharp
class Menu
{
    Menu Create();
    void AddDinner(Dinner dinner);
    void RemoveDinner(Dinner dinner);
    void UpdateSection(MenuSection section);
}
```

```json
{
  "id": {"value": "00000000-0000-0000-0000-000000000000"},
  "name": "Some Menu",
  "description": "A menu with some food",
  "averageRating": 4.5,
  "sections": [
    {
      "id": {"value": "00000000-0000-0000-0000-000000000000"},
      "name": "Appetizers",
      "description": "Starters",
      "items": [
        {
          "id": {"value": "00000000-0000-0000-0000-000000000000"},
          "name": "Fried Pickles",
          "description": "Deep fried pickles",
          "price": 5.99
        }
      ]
    }
  ],
  "createdDateTime": "2024-01-01T00:00:00.0000000Z",
  "updatedDateTime": "2024-01-01T00:00:00.0000000Z",
  "hostId": {"value": "00000000-0000-0000-0000-000000000000"},
  "dinnerIds": [
    {"value": "00000000-0000-0000-0000-000000000000"}
  ],
  "menuReviewIds": [
    "00000000-0000-0000-0000-000000000000"
  ]
}
```
