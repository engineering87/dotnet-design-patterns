// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Proxy
{
    // Proxy
    public class ResourceProxy : IResource
    {
        private Resource _realResource;
        private readonly string _userRole;

        public ResourceProxy(string userRole)
        {
            _userRole = userRole;
        }

        public void Access()
        {
            if (HasAccess())
            {
                if (_realResource == null)
                {
                    _realResource = new Resource(); // Lazy initialization
                }
                Console.WriteLine("Proxy forwarding the request to the real resource.");
                _realResource.Access();
            }
            else
            {
                Console.WriteLine("Access denied.");
            }
        }

        private bool HasAccess()
        {
            // Simple access control based on user role
            return _userRole == "Admin";
        }
    }
}
