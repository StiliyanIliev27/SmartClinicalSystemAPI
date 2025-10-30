# SmartClinicalSystem


- Smart Clinical System API is built with ASP.NET Core Web Api following best practices for optimized code - Best design patterns such as Repository pattern, Factory pattern. 
- The bussiness logic in the code is organized on top of CQRS pattern with Clean Architecture making the codebase easy to read, scale and debug. 
- I am also using packages such as Entity Framework for mapper between the backend and the database.
- Fluent Validation for validating input data, Mapster for mapping different types of objects which have many similar columns and needs to be mapped. I think Mapster is a great lightweight library for helping this out. 
- I am also using MediatR to send the command/query from the endpoint to the handler.
