using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Enums;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User.Validations;


namespace Ambev.DeveloperEvaluation.Domain.Aggregate.User.Factory
{

    public static class UserFactory
    {
        public static Aggregate.User.User Create(string username, string email, string phone, string password, UserRole role, UserStatus status)
        {
            var user = new Aggregate.User.User(username, email, phone, password, role, status);

            user.Validate(user, new UserValidator());

            return user;
        }
    }
}

