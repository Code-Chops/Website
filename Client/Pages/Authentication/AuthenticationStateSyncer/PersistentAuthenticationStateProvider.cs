using System.Security.Claims;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;

namespace CodeChops.Website.Client.Pages.Authentication.AuthenticationStateSyncer;

public sealed class PersistentAuthenticationStateProvider(PersistentComponentState persistentState) : AuthenticationStateProvider
{
	private static Task<AuthenticationState> UnauthenticatedTask { get; }
		= Task.FromResult(new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity())));

	public override Task<AuthenticationState> GetAuthenticationStateAsync()
	{
		if (!persistentState.TryTakeFromJson<UserInfo>(nameof(UserInfo), out var userInfo) || userInfo is null)
			return UnauthenticatedTask;

		var claims = new Claim[]
		{
			new(ClaimTypes.NameIdentifier, userInfo.UserId),
			new(ClaimTypes.Name, userInfo.Name),
			new(ClaimTypes.Email, userInfo.Email ?? ""),
		};

		return Task.FromResult(
			new AuthenticationState(new ClaimsPrincipal(new ClaimsIdentity(claims,
				authenticationType: nameof(PersistentAuthenticationStateProvider)))));
	}
}
