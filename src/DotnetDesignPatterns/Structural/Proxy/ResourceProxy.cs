// (c) 2024 Francesco Del Re <francesco.delre.87@gmail.com>
// This code is licensed under MIT license (see LICENSE.txt for details)
namespace DotnetDesignPatterns.Structural.Proxy
{
    /// <summary>
    /// Stands in front of the real resource. It checks the role, and creates the resource only when access is granted.
    /// </summary>
    public class ResourceProxy : IResource
    {
        /// <summary>
        /// Where this example writes its narration. It defaults to the console, and a
        /// caller, or a test, can point it somewhere else.
        /// </summary>
        public TextWriter Output { get; init; } = Console.Out;

        // The real resource is created on the first authorised access, so the field
        // is nullable until then. Deferring that cost is what the proxy is for.
        private Resource? _realResource;
        private readonly string _userRole;

        /// <summary>
        /// Creates a proxy that answers for the given role.
        /// </summary>
        /// <param name="userRole">The role of the caller, checked before the resource is reached.</param>
        public ResourceProxy(string userRole)
        {
            ArgumentException.ThrowIfNullOrWhiteSpace(userRole);

            _userRole = userRole;
        }

        /// <summary>
        /// Checks the role, then forwards to the real resource.
        /// </summary>
        public void Access()
        {
            if (HasAccess())
            {
                // Lazy initialization
                _realResource ??= new Resource { Output = Output };
                Output.WriteLine("Proxy forwarding the request to the real resource.");
                _realResource.Access();
            }
            else
            {
                Output.WriteLine("Access denied.");
            }
        }

        private bool HasAccess()
        {
            // Simple access control based on user role
            return _userRole == "Admin";
        }
    }
}
