using AutoMapper;
using Ambev.DeveloperEvaluation.Domain.Aggregate.User;

namespace Ambev.DeveloperEvaluation.Application.Users.GetUser;

/// <summary>
/// Profile for mapping between User entity and GetUserResponse
/// </summary>
public class GetUserProfile : Profile
{
    /// <summary>
    /// Initializes the mappings for GetUser operation
    /// </summary>
    public GetUserProfile()
    {
        CreateMap<User, GetUserResult>()
            .ForMember(userResult => userResult.Username, member => member.MapFrom(user => user.Username));
    }
}
