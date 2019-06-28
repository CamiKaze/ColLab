# ColLab
Video Conferencing Application


## Getting started
### Installation
Clone ColLab from the master branch of Github repository

```bash
git clone git@github.com:CamiKaze/ColLab.git
```

Double click on Collab.csproj to open the solution via Visual Studio 2017/2019.

Run the application

```bash
go run main.go
```

The Websocket is now listening on the port `5000`, to change it just set it inside the applicationURL variable in launchSettings.json, found inside the Properties folder of the project.


### How to use
On startup, the application will open a browser and display data in JSON format found within the memory cached database.

```json
{
  "id":1,
  "productID":2125,
  "productName":"Cheese",
  "quantity":5,
  "createdDate":"0001-01-01T00:00:00",
  "shoppingCartID":1
}
```