# Animal Shelter
Version 1.0 - August 21, 2020  
JohnNils Olson  
Web API with Swagger UI implementation for storing and retreving data about animals available for adoption in an animal shelter.  

## Animals
### HTTP Request
```
GET /api/animals
```
### Path Parameters
None.
### Example Query
```
http://localhost:5000/api/animals
```
### Sample JSON Response
```
[
...
  {
    "canineBreed": "germanshepard",
    "animalId": 2,
    "name": "Ramona",
    "gender": "Female",
    "age": 2,
    "weight": 55,
    "bio": "Needs leash training!"
  },
...
]
```
### Status Codes
200: Success.  
400: Bad Request.  
404: Not Found.

****

## Animal by Type (Bird, Canine, Equine, Feline, Reptile, Rodent)
### HTTP Request
```
GET /api/{type}
POST /api/{type}
GET /api/{type}/{id}
PUT /api/{type}/{id}
DELETE /api/{type}/{id}
```
### GET /api/{type} Query Parameters
| Parameter | Data Type | Required | Description |
| ---- | ---- | ---- | ---- |
| Name | string | Optional | Returns matching animals of specified type by name |
| Gender | string | Optional | Returns matching animals of specified type by gender |
| Breed | string | Optional | Returns matching animals of specified type by breed |
| Age | int | Optional | Returns matching animals of specified type by age |
### Example Query
```
http://localhost:5000/api/canines/?breed=germanshepard&gender=female
```
### Sample JSON Response
```
{
  "canineBreed": "germanshepard",
  "animalId": 2,
  "name": "Ramona",
  "gender": "Female",
  "age": 2,
  "weight": 55,
  "bio": "Needs leash training!"
}
```
### Example POST/PUT JSON Body Injection
```
{
  "canineBreed": "German Shepard",
  "name": "Ramona",
  "gender": "Female",
  "age": 2,
  "weight": 55,
  "bio": "Needs leash training!"
} 
```
### Status Codes
200: Success.  
400: Bad Request.  
404: Not Found.

## _Technologies Used_
C#  
.NETCore  
Entity Framework Core  
MySql Server
Swagger  

## _Installation Instructions_
* Project Cloning Instructions.
  1. Open Git Bash.
  2. Change the current working directory to the location where you would like to clone the repository.
  3. Type "git clone" followed by "https://github.com/JohnNilsOlson/AnimalShelter.Solution" (without quotes) and hit enter.
  4. Open directory with code editor of choice.

* Project Download Instructions.
  1. Visit "https://github.com/JohnNilsOlson/AnimalShelter.Solution".
  2. Click the green "code" button and download zip file of project.
  3. Extract zip file to directory of choice.
  4. Open project directory in code editor of choice.

* MySql Database Initialization Instructions with Seeded Data.
  1. In the terminal, change working directory to ./AnimalShelter.
  2. In the terminal, type "dotnet ef database update" to build schema.

* MySql Database Initilization Instructions with No Seeded Data.
  1. In the terminal, change working directory to ./AnimalShelter.
  2. Open AnimalShelterContext.cs file.
  3. Comment out or delete lines 7-57.
  4. In the terminal, type "dotnet ef database update" to build schema.

* Instructions to Run the Web API.
  1. In the terminal, change working directory to ./AnimalShelter.
  2. Type "dotnet run" to run the Web API at http://localhost:5000.
  3. API can be utilized through Postman (see postman.com for more information), or by opening http://localhost:5000 in web browser through Swagger UI.

## _Bugs_
No known issues.

## _Contact Information_
JohnNils Olson - johnnils@gmail.com  

## _License_
The [MIT] license.
Copyright (c) 2020 JohnNils Olson