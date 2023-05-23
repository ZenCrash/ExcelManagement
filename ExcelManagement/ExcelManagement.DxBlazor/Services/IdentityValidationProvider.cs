using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Server;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using System.Security.Claims;

namespace ExcelManagement.DxBlazor.Services
{
	public class IdentityValidationProvider<TUser> : RevalidatingServerAuthenticationStateProvider where TUser : class
	{
		private readonly IServiceScopeFactory _scopedFactory;
		private readonly IdentityOptions _options;

		public IdentityValidationProvider(ILoggerFactory loggerFactory, IServiceScopeFactory scopeFactory, IOptions<IdentityOptions> optionsAccessor) : base(loggerFactory)
		{
			_scopedFactory = scopeFactory;
			_options = optionsAccessor.Value;
		}

		protected override TimeSpan RevalidationInterval => TimeSpan.FromSeconds(30);

		protected override async Task<bool> ValidateAuthenticationStateAsync(AuthenticationState authenticationState, CancellationToken cancellationToken)
		{
			var scope = _scopedFactory.CreateScope();
			try
			{
				var userManager = scope.ServiceProvider.GetRequiredService<UserManager<TUser>>();
				return await ValidateSecurityStampAsync(userManager, authenticationState.User);
			}
			finally
			{
				if (scope is IAsyncDisposable asyncDisposable)
				{
					await asyncDisposable.DisposeAsync();
				}
				else
				{
					scope.Dispose();
				}
			}
		}

		private async Task<bool> ValidateSecurityStampAsync(UserManager<TUser> userManager, ClaimsPrincipal principal)
		{
			var user = await userManager.GetUserAsync(principal);

			if (user == null)
			{
				return false;
			}
			else if (!userManager.SupportsUserSecurityStamp)
			{
				return true;
			}
			else
			{
				var principalStamp = principal.FindFirstValue(_options.ClaimsIdentity.SecurityStampClaimType);
				var userStamp = await userManager.GetSecurityStampAsync(user);
				return principalStamp == userStamp;
			}
		}


	}
}
