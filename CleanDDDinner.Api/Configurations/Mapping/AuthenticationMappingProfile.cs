using AutoMapper;
using CleanDDDinner.Application.Authentication.Commands.Register;
using CleanDDDinner.Application.Authentication.Common;
using CleanDDDinner.Application.Authentication.Queries.Login;
using CleanDDDinner.Contracts.Authentication;

namespace CleanDDDinner.Api.Configurations.Mapping;

public class AuthenticationMappingProfile : Profile
{
    public AuthenticationMappingProfile()
    {
        CreateMap<AuthenticationResult, AuthenticationResponse>()
            .ForCtorParam("Id", expression => expression.MapFrom(result => result.User.Id))
            .ForCtorParam("FirstName", expression => expression.MapFrom(result => result.User.FirstName))
            .ForCtorParam("LastName", expression => expression.MapFrom(result => result.User.LastName))
            .ForCtorParam("Email", expression => expression.MapFrom(result => result.User.Email))
            .ForCtorParam("Token", expression => expression.MapFrom(result => result.Token));
        CreateMap<RegisterRequest, RegisterCommand>();
        CreateMap<LoginRequest, LoginQuery>();
    }
}