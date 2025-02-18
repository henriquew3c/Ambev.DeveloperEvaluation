<p align="center">
  <img src="assets/img/logo.png" alt="Logo" />
</p>

# This Project

This project is part of the selection process for senior programmers at NTT Data, and consists of implementing prototypes of an API for handling users, products, sales and authentication.

See [Tech Stack](/.doc/tech-stack.md)\
See [Frameworks](/.doc/frameworks.md)

## Project setup

1. Run `docker-compose up` to initiate the containers.

__Exemple__:
<p align="center">
    <video width="600" controls>
        <source src="assets/movies/docker-compose-up-command.mp4" type="video/mp4">
        Your browser does not support the video tag.
    </video>
</p>

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

<table>
  <tr>
    <th>Functionaly</th>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>:link:</th>
  </tr>
  <tr>
    <td>Authorize</td>
    <td>POST</td>
    <td>/api/Auth</td>
    <td>200 (OK) 400 (Bad Request) 401 (Unauthorized)</td>
    <td><a href="/.doc/authorize.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>Create</td>
    <td>POST</td>
    <td>/api/User</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/create-your-user.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>Get</td>
    <td>GET</td>
    <td>/api/User/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-user.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>Delete</td>
    <td>DELETE</td>
    <td>/api/User/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/delete-user.md" targer="__blank">exemple</a></td>
  </tr>
</table>

## Product

<table>
  <tr>
    <th>Functionaly</th>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>:link:</th>
  </tr>
  <tr>
    <td>Create</td>
    <td>POST</td>
    <td>/api/Product</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/create-product.md" targer="__blank">exemple</a></td>
  </tr>
</table>

## Sale

<table>
  <tr>
    <th>Functionaly</th>
    <th>HTTP Method</th>
    <th>Endpoint</th>
    <th>Responses</th>
    <th>:link:</th>
  </tr>
  <tr>
    <td>Create</td>
    <td>POST</td>
    <td>/api/Sale</td>
    <td>201 (Created) 400 (Bad Request)</td>
    <td><a href="/.doc/create-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>Update</td>
    <td>PUT</td>
    <td>/api/Sale</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/update-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>Get</td>
    <td>GET</td>
    <td>/api/Sale/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sale.md" targer="__blank">exemple</a></td>
  </tr>
  <tr>
    <td>List</td>
    <td>GET</td>
    <td>/api/Sale</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sales.md" targer="__blank">exemple</a></td>
  </tr>
   <tr>
    <td>Delete</td>
    <td>DELETE</td>
    <td>/api/Sale/{id}</td>
    <td>200 (OK) 400 (Bad Request) 404 (Not Found)</td>
    <td><a href="/.doc/get-sales.md" targer="__blank">exemple</a></td>
  </tr>
</table>

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
