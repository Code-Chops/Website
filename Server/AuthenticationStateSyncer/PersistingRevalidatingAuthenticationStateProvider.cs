using System.Diagnostics;
using System.Security.Claims;
using CodeChops.Website.Client.Pages.Authentication.AuthenticationStateSyncer;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;

namespace CodeChops.Website.Server.AuthenticationStateSyncer;

public sealed class PersistingRevalidatingAuthenticationStateProvider : RevalidatingServerAuthenticationStateProvider
{
	private IServiceScopeFactory ScopeFactory { get; }
	private PersistentComponentState State { get; }
	private IdentityOptions Options { get; }
	private PersistingComponentStateSubscription Subscription { get; }
	private Task<AuthenticationState>? AuthenticationStateTask { get; set; }

	public PersistingRevalidatingAuthenticationStateProvider(
		ILoggerFactory loggerFactory,
		IServiceScopeFactory scopeFactory,
		PersistentComponentState state,
		IOptions<IdentityOptions> options)
		: base(loggerFactory)
	{
		this.ScopeFactory = scopeFactory;
		this.State = state;
		this.Options = options.Value;

		this.AuthenticationStateChanged += this.OnAuthenticationStateChanged;
		this.Subscription = state.RegisterOnPersisting(this.OnPersistingAsync, RenderMode.InteractiveWebAssembly);
	}

	protected override TimeSpan RevalidationInterval => TimeSpan.FromMinutes(30);

	protected override async Task<bool> ValidateAuthenticationStateAsync(
		AuthenticationState authenticationState, CancellationToken cancellationToken)
	{
		// Get the user manager from a new scope to ensure it fetches fresh data
		await using var scope = this.ScopeFactory.CreateAsyncScope();
		return ValidateSecurityStampAsync(authenticationState.User);
	}

	private static bool ValidateSecurityStampAsync(ClaimsPrincipal principal)
	{
		return principal.Identity?.IsAuthenticated is not false;
	}

	private void OnAuthenticationStateChanged(Task<AuthenticationState> authenticationStateTask)
	{
		this.AuthenticationStateTask = authenticationStateTask;
	}

	private async Task OnPersistingAsync()
	{
		if (this.AuthenticationStateTask is null)
			throw new UnreachableException($"Authentication state not set in {nameof(RevalidatingServerAuthenticationStateProvider)}.{nameof(this.OnPersistingAsync)}().");

		var authenticationState = await this.AuthenticationStateTask;
		var principal = authenticationState.User;

		if (principal.Identity?.IsAuthenticated is true)
		{
			var userId = principal.FindFirst(this.Options.ClaimsIdentity.UserIdClaimType)?.Value;
			var name = principal.FindFirst("name")?.Value;
			var email = principal.FindFirst("email")?.Value;

			if (userId is not null && name is not null)
			{
				this.State.PersistAsJson(nameof(UserInfo), new UserInfo()
				{
					UserId = userId,
					Name = name,
					Email = email!,
				});
			}
		}
	}

	protected override void Dispose(bool disposing)
	{
		this.Subscription.Dispose();
		this.AuthenticationStateChanged -= this.OnAuthenticationStateChanged;
		base.Dispose(disposing);
	}
}
