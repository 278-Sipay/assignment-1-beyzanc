# Sipay&Patika.dev .NET Bootcamp - Case #1: FluentValidation

This project demonstrates the basic usage of FluentValidation library in an ASP.NET 6.0 application to perform validations in a more flexible and expressive manner compared to attributes. It includes a PersonController with a POST method that validates incoming Person objects using FluentValidation rules.

## Project Structure 

- **Person.cs**: Defines the **Person model class** with properties such as Name, Lastname, Phone, AccessLevel, and Salary.

- **PersonController.cs**: Contains the **PersonController class**, which is responsible for handling **HTTP POST** requests for creating a new person. It uses an instance of **IValidator<Person>** for validating the input Person object.

- **PersonValidator.cs**: Defines the **PersonValidator class**, which extends **AbstractValidator<Person>**. It contains validation rules for each property of the Person model using **FluentValidation's fluent API**.


## Usage

1.  Clone the project from Github by running the following command in a terminal:
   
    `https://github.com/beyzanc/fluent-validation-demo.git`
    
2. Install the .NET Core SDK by following the instructions on the [.NET Core website](https://dotnet.microsoft.com/en-us/download/dotnet-core)
3. Install the FluentValidation NuGet package by running the following command in a terminal:
   
   `dotnet add package FluentValidation`
4. Run the project in Visual Studio by pressing F5 or by using the this command in a terminal:
   
   `dotnet run`
   
   Then, the application will launch and start listening on a local development server.

5. Open your web browser or a tool like Postman.

   Navigate to `http://localhost:<port>/sipy/api/Person`, where <port> is the port number assigned by the development server.

   Use the Swagger UI to interact with the API and test the PersonController's POST method.

7. Enjoy!


## Additional Notes

- The project uses Swagger for API documentation and testing. You can access the Swagger UI by appending /swagger to the application URL (e.g. `http://localhost:<port>/swagger`).

- The validation rules for the Person model are defined in the PersonValidator class located in the Validators folder. You can modify these rules to suit your requirements.

- The project follows the principles of Object-Oriented Programming (OOP) by separating concerns into different classes, such as the Person model, PersonValidator, and PersonController and adheres to SOLID principles.

- The project integrates FluentValidation to provide a more flexible and expressive way of defining validation rules compared to using attributes.

## Fluent Validation Rules with Same Examples

| Property | Validation Rule                                                  | 200 (OK) Request Examples | 400 (Bad Request) Examples |
| -------------- | ---------------------------------------------------------------- | -------------------------------- | ---------------------------- |
| Name           | NotEmpty(), Length(5, 100)                                       | "Beyza", "Michael", "patika.dev"        | "", "Jo", "A"                 |
| Lastname       | NotEmpty(), Length(5, 100)                                       | "Cabuk", "Haneke", "Sipay"          | "", "Li", "A"                 |
| Phone          | NotEmpty(), Must(IsPhoneNumber)                                  | "1234567890", "9876543210", "5555555555" | "", "123", "abcdefghi"        |
| AccessLevel    | NotEmpty(), InclusiveBetween(1, 5)                               | 3, 2, 4                          | 0, 6, -1                      |
| Salary         | NotEmpty(), InclusiveBetween(5000, 50000), Must(IsValidSalary)   | 5000, 30000, 50000     | 0.00, 3000, 10000     |


### **An example of the success status request and response scenario with a 200(OK) code:**

![](https://github.com/beyzanc/fluent-validation-demo/blob/master/200%20success.png)

### **An example of the failed status request and response scenario with a 400(Bad Request) code:**

![](https://github.com/beyzanc/fluent-validation-demo/blob/master/400%20failed.png)

## Object Oriented Programming

Here are the uses of OOP in this project:

- **Encapsulation**: The Person.cs class is an example of encapsulation. It groups together the properties of a person into a single class.
```  
public class Person
{
    public string Name { get; set; }
    // ...
}
```

- **Abstraction**: The PersonController class provides an abstraction layer for handling HTTP requests related to the Person object.

```
public class PersonController : ControllerBase
{
    // ...
    [HttpPost]
    public IActionResult Post([FromBody] Person person)
    {
        // ...
    }
}
```
- **Inheritance**: The PersonValidator class inherits from the AbstractValidator<Person> class provided by FluentValidation.
```
public class PersonValidator : AbstractValidator<Person>
{
    // ...
}
```

- **Polymorphism**: The IValidator<Person> interface is used to define a common interface for validating Person objects. In this code, the specific implementation of the IValidator<Person> interface is provided to the PersonController class with dependency injection.

```
public PersonController(IValidator<Person> validator)
{
    _validator = validator;
}
```


## SOLID Principles 

- **Single Responsibility Principle**: Each class has a clear and well-defined one responsibility.

- **Open-Closed Principle**: The PersonController class uses an interface to validate Person objects, allowing new validation rules to be added without modifying existing code.

- **Liskov Substitution Principle**: The PersonValidator class is a subclass of the AbstractValidator<Person> class and can be used wherever an instance of the AbstractValidator<Person> class is expected.

- **Interface Segregation Principle**: The PersonController class depends only on the minimal IValidator<Person> interface, avoiding unnecessary dependencies.

- **Dependency Inversion Principle**: The PersonController class depends on an abstraction (the IValidator<Person> interface) rather than on a specific implementation.
  
## Idempotence

The **HTTP POST** method, which is the only method used in the project, is ***not idempotent***. A POST request is used to create a new resource or replace an existing resource each time. Therefore, repeating the same POST request will result in creating a new resource each time or replacing the existing resource. So the HTTP POST method is not idempotent.


## Built With

- ASP.NET 6.0
- Fluent Validation Library
- Swagger
- .NET 6.0 SDK
- Visual Studio 2022

