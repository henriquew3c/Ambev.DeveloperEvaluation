using Ambev.DeveloperEvaluation.Domain.Aggregate.User;

namespace Ambev.DeveloperEvaluation.Domain.Aggregate.User.Events
{
    public class UserRegisteredEvent
    {
        public User User { get; }

        public UserRegisteredEvent(User user)
        {
            User = user;
        }
    }
}
