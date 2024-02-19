namespace CodeChops.Website.Client.Pages.Authentication.AuthenticationStateSyncer;

public sealed record UserInfo
{
	public required string UserId { get; init; }
	public required string Name { get; init; }
	public required string? Email { get; init; }
}
