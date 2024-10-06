using Microsoft.AspNetCore.Authorization;

namespace EmpolyerApp.Data.Helpers
{

    public class EmailDomainRequirement : IAuthorizationRequirement
    {
        public string EmailDomain { get; }

        public EmailDomainRequirement(string emailDomain)
        {
            EmailDomain = emailDomain;
        }
    }

}
