using System.Security.Claims;

namespace Pegasus.Web.Helpers
{
    public static class Identity 
    {
        public static Guid GetUserId(this ClaimsPrincipal user) 
        {
            var nameIdentifierClaim = user.Claims.FirstOrDefault(c => c.Type == ClaimTypes.NameIdentifier);

            if (nameIdentifierClaim != null)
                return new Guid(nameIdentifierClaim.Value);
            throw new Exception("No user loged");
        }
    }
}
