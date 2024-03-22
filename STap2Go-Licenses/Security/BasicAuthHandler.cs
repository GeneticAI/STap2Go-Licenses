using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using STap2Go_Licenses.Entities;
using System.Net.Http.Headers;
using System.Security.Claims;
using System.Text.Encodings.Web;
using System.Text;
using Microsoft.Extensions.Primitives;

namespace STap2Go_Licenses.Security
{
    public class BasicAuthHandler : AuthenticationHandler<AuthenticationSchemeOptions>
    {
        private readonly UserManager<User> _userManager;

        public BasicAuthHandler(IOptionsMonitor<AuthenticationSchemeOptions> options,
            ILoggerFactory logger,
            UrlEncoder encoder,
            ISystemClock clock,
            UserManager<User> userManager) : base(options, logger, encoder, clock)
        {
            _userManager = userManager;
        }

        protected override async Task<AuthenticateResult> HandleAuthenticateAsync()
        {
            if (!Request.Headers.TryGetValue("Authorization", out StringValues authHeaderValue))
                return AuthenticateResult.Fail("No viene el header");

            var authHeader = AuthenticationHeaderValue.Parse(authHeaderValue);
            var credentialsBytes = Convert.FromBase64String(authHeader.Parameter!);
            var credentials = Encoding.UTF8.GetString(credentialsBytes).Split(new[] { ':' }, 2);
            var email = credentials[0];
            var pass = credentials[1];

            //result = _userService.IsUser(email, pass);

            if (_userManager == null) return AuthenticateResult.Fail("_userManager es null!!!");

            var user = await _userManager.FindByNameAsync(email);

            if (user == null)
                return AuthenticateResult.Fail("No se ha encontrado el usuario en userManager");

            if (user is null || !await _userManager.CheckPasswordAsync(user, pass))
                return AuthenticateResult.Fail("Contraseña incorrecta");

            var claims = new List<Claim>
            {
                new(ClaimTypes.Name, user.UserName!),
            };

            var roles = await _userManager.GetRolesAsync(user);

            foreach(var role in roles)
            {
                claims.Add(new Claim(ClaimTypes.Role, role));
            }

            var identity = new ClaimsIdentity(claims, Scheme.Name);
            var principal = new ClaimsPrincipal(identity);
            var ticket = new AuthenticationTicket(principal, Scheme.Name);

            return AuthenticateResult.Success(ticket);
        }
    }
}
