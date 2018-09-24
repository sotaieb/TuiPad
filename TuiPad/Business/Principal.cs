using System.Security.Principal;

namespace TuiPad.Business
{
    public class Principal : IPrincipal
    {
        public IIdentity Identity { get; private set; }

        public Principal()
        {
        }
        public Principal(IIdentity identity)
        {
            Identity = identity;
        }

        public bool IsInRole(string role)
        {
            switch (Identity?.Name)
            {
                case "user":
                    return false;
                case "admin":
                    return true;
                default:
                    return false;
            }
        }
    }
}