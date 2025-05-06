using Medi.API.Contracts;
using Medi.Application.Services;

namespace Medi.API.Endpoints
{
    public static class UserEndpoints
    {
        public static IEndpointRouteBuilder MapUsersEndpoints(this IEndpointRouteBuilder app)
        {
            app.MapPost("register", Register);

            app.MapPost("login", Login);

            return app;
        }

        private static async Task<IResult> Register(RegisterUserRequest request, UserService userService)
        {
            await userService.Register(request.UserName, request.Email, request.Password);

            return Results.Ok();
        }

        private static async Task<IResult> Login(LoginUserRequest request, UserService userService)
        {
            var token = await userService.Login(request.email, request.password);

            return Results.Ok(token);    
        }
    }
}
