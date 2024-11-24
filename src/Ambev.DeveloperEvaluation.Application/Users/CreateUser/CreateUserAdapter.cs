using Ambev.DeveloperEvaluation.Domain.Aggregate.User;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Factory;

namespace Ambev.DeveloperEvaluation.Application.Users.CreateUser;

public static class CreateUserAdapter
{
    public static User Map(this CreateUserCommand request)
    {
        return UserFactory.Create(request.Username, request.Email, request.Phone, request.Password, request.Role, request.Status);
    }
}