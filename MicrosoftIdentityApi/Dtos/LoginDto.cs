namespace MicrosoftIdentityApi.Dtos
{
    public sealed record LoginDto(
       string UserNameOrEmail,
       string Password);
}
