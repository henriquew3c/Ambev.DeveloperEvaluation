<p align="center">
  <img src="assets/img/logo.png" alt="Logo" />
</p>

# This Project

This project is part of the selection process for senior programmers at NTT Data, and consists of implementing prototypes of an API for handling users, products, sales and authentication.

## Technologies:

See Tech Stack [Tech Stack](/.doc/tech-stack.md)
See Frameworks [Frameworks](/.doc/frameworks.md)

## Instructions for use

1. Run `docker-compose up` to initiate the containers.

Exemple:
https://github.com/henriquew3c/Ambev.DeveloperEvaluation/blob/master/assets/movies/docker-compose-up-command.mp4

2. Run the command `update-database` to create tables in the database. If it doesn't work, check the appsettings connection string. By default, the PostgreSQL port 5432 is exposed.

Exemple:
<p align="center">
    <video width="600" controls>
        <source src="assets/movies/update-database-command.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>

3. Use Swagger (or another tool) to create your user. Post to `/api/Users`.

# Endpoints Prototype Sales API

## User

See [Create User. Post to /api/User](/.doc/create-your-user.md)

## Get User. Get to /api/User/{id}

See [Get User. Get to /api/User/{id}](/.doc/get-user.md)

## Delete User. Delete to /api/User/{id}

See [Delete User. Delete to /api/User/{id}](/.doc/delete-user.md)

## Authorize

### Auth User. Post to /api/Auth

See [Auth User. Post to /api/Auth](/.doc/authorize.md)

## Product

### Create one product to usage in sale. Post to /api/Product.

See [Create one product to usage in sale. Post to /api/Product](/.doc/create-product.md)

## Sale

### Create sales. Post to /api/Sale.

See [Create sales. Post to /api/Sale](/.doc/create-sale.md)

### Update sale. Put to /api/Sale.

See [Create sales. Post to /api/Sale](/.doc/update-sale.md)

### Get sale. Get to /api/Sale/{id}.

See [Get sale. Get to /api/Sale/{id}](/.doc/get-sale.md)

### Get all sales. Get to /api/Sales.

See [Get all sales. Get to /api/Sales](/.doc/get-sales.md)

## Additional Improvements

Here are some potential improvements for this project:

1. **Enhanced Documentation**: Expand the documentation to include more detailed setup instructions, examples, and troubleshooting tips.
2. **Automated Testing**: Implement more comprehensive unit and integration tests to ensure the reliability of the API.
3. **Continuous Integration/Continuous Deployment (CI/CD)**: Set up a CI/CD pipeline to automate testing and deployment processes.
4. **API Rate Limiting**: Implement rate limiting to prevent abuse and ensure fair usage of the API.
5. **Error Handling**: Improve error handling to provide more informative and user-friendly error messages.
6. **Security Enhancements**: Add more security features such as input validation, encryption, and improved authentication mechanisms.
7. **Performance Optimization**: Optimize the API for better performance, including database query optimization and caching strategies.
8. **Scalability**: Design the API to be more scalable to handle increased load and traffic.
9. **User Interface**: Develop a user-friendly front-end interface to interact with the API.
10. **Logging and Monitoring**: Implement logging and monitoring to track the API's performance and usage.

These improvements can help enhance the functionality, security, and user experience of the project.

### Testing

To run the tests, use the following command:

```bash
dotnet test
```

### Contributing

If you would like to contribute to this project, please follow these steps:

1. Fork the repository.
2. Create a new branch (`git checkout -b feature-branch`).
3. Make your changes.
4. Commit your changes (`git commit -m 'Add some feature'`).
5. Push to the branch (`git push origin feature-branch`).
6. Open a pull request.

### License

This project is licensed under the MIT License - see the [LICENSE](LICENSE) file for details.

### Contact

For any questions or feedback, please contact [Honório Henrique](mailto:henriquew3c@gmail.com).
