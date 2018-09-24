using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace TuiPad.Business
{
    public class Identity : IIdentity
    {
        public Identity(string name)
        {
            this.Name = name;
        }
        public string AuthenticationType => throw new NotImplementedException();

        public bool IsAuthenticated => throw new NotImplementedException();

        public string Name { get; set; }
    }
}
