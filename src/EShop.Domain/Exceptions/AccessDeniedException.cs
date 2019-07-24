using System;

namespace EShop.Domain.Exceptions
{
    public class AccessDeniedException : Exception
    {
        public AccessDeniedException() : base("Access to this action denied.") { }
    }
}