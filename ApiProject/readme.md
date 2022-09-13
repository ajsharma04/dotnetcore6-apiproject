This Api is made in .net 6

To build the project you will need

	  1.   VS 2022
	  2.   Docker Desktop

Once the projects run successfully in Docker. Open this URL - https://localhost:64899/swagger

Step 1 - Create a Grid with `battleship/creategrid` endpoint

Request
```json
{
  "gridX": 10,
  "gridY": 10
}
```
Response
```json
{
  "gridId": "e1f73c02-2a2e-467c-8ef9-2ca4d619b3b5",
  "gridX": 10,
  "gridY": 10,
  "gridLayout": "0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0;0,0,0,0,0,0,0,0,0,0"
}
```

Step 2 - Create a batlleship with `battleship/createbattleship` endpoint

Request
```json
{
  "startCoordinatesXY": {
    "xCoordinate": 5,
    "yCoordinate": 8
  },
  "endingCoordinatesXY": {
    "xCoordinate": 8,
    "yCoordinate": 8
  }
}
```

Response
```json
{
  "battleshipId": "aa926e47-6d7f-458a-aa6d-1ece8b90da4f",
  "startCoordinatesXY": {
    "xCoordinate": 5,
    "yCoordinate": 8
  },
  "endingCoordinatesXY": {
    "xCoordinate": 8,
    "yCoordinate": 8
  }
}
```

Step 3 - Create an attack with ` battleship/launchattack` endpoint

Request
```json
{
  "gridX": 5,
  "gridY": 1
}
```

Response - 2 = "MISS"
```json
{
  "status": 2
}
```

Request
```json
{
  "gridX": 6,
  "gridY": 8
}
```

Response - 1 = "HIT"
```json
{
  "status": 1
}
```

At any point after Step 1 if you wish to see the grid call `battleship/getgridbyid` endpoint

Request
```
57b8a321-a34e-483f-ac83-3f061df321c2
```

Response - 1 = "HIT"
Note: Just changing the reponse layout manually to represent more graphically
```
{
  "gridId": "57b8a321-a34e-483f-ac83-3f061df321c2",
  "gridX": 10,
  "gridY": 10,
  "gridLayout": "0,0,0,0,0,0,0,0,0,0;
                 0,0,0,0,0,0,0,0,0,0;
                 0,0,0,0,0,0,0,0,0,0;
                 0,0,0,0,0,0,0,0,0,0;
                 -,0,0,0,0,0,0,1,0,0;
                 0,0,0,0,0,0,0,X,0,0;
                 0,0,0,0,0,0,0,1,0,0;
                 0,0,0,0,0,0,0,1,0,0;
                 0,0,0,0,0,0,0,0,0,0;
                 0,0,0,0,0,0,0,0,0,0"
}
```