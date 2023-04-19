# **Taller API**
## **Documentation**
### **Clients**
You can create, get, update and delete clients.
#### **Create a client**
##### Request

    Method: POST
    Endpoint: /api/v1/Client
    Body:
    {   "id": 0,
        "name": "String",
        "idNum": "String",
        "email": "String",
        "phone": "String",
    }
##### Response
    
    200 OK
    Client created


#### **Get clients**
Ypu can get all clients with this endpoint.
##### Request

    Method: GET
    Endpoint: /api/v1/Client

##### Response
        
        200 OK
        [
            {
                "id": "int",
                "name": "String",
                "idNum": "String",
                "email": "String",
                "phone": "String",
            },
            ...
            
        ]

You can also get a client by any of its properties using query parameters in the url.

##### Request

    Method: GET
    Endpoint: /api/v1/Client?name&idNum&email&phone

##### Response
        
        200 OK
        [
            {
                "id": "int",
                "name": "String",
                "idNum": "String",
                "email": "String",
                "phone": "String",
            },
            ...
            
        ]

#### **Update a client**
##### Request

    Method: PUT
    Endpoint: /api/v1/Client
    Body:
    {   "id": 0,
        "name": "String",
        "idNum": "String",
        "email": "String",
        "phone": "String",
    }

##### Response
        
        200 OK
        Client updated
    

#### **Delete a client**
##### Request

    Method: DELETE
    Endpoint: /api/v1/Client/{id}

##### Response
        
        200 OK
        Client deleted