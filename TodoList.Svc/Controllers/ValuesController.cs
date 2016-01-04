using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Security.Claims;
using System.Web.Http;

namespace TodoList.Svc.Controllers
{
	[Authorize]
    public class ValuesController : ApiController
    {
		public IEnumerable<string> Get()
		{
			// Ensure this is a valid user
			if (ClaimsPrincipal.Current.FindFirst("http://schemas.microsoft.com/identity/claims/scope").Value != "user_impersonation")
			{
				throw new HttpResponseException(
					new HttpResponseMessage {
						StatusCode = HttpStatusCode.Unauthorized,
						ReasonPhrase = "The Scope claim does not contain 'user_impersonation' or scope claim not found"
					});
			}

			// Get the unique login for the user.
			Claim subject = ClaimsPrincipal.Current.FindFirst(ClaimTypes.Name);

			return new[] {
				"Item 1",
				"Item 2",
				"Item 3",
				subject.Value
			};
		}
	}
}
