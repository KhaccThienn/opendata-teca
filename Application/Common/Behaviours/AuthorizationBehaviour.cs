namespace Application.Common.Behaviours
{
    public class AuthorizationBehaviour<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : notnull
    {
        private readonly IUser _user;
        private readonly IIdentityService _identityService;

        public AuthorizationBehaviour(IUser user, IIdentityService identityService)
        {
            _user = user;
            _identityService = identityService;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            // Retrieve all AuthorizeAttribute instances applied to the request type
            var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();

            // Check if there are any authorization attributes
            if (authorizeAttributes.Any())
            {
                // If the user is not authenticated, throw an UnauthorizedAccessException
                if (_user.Id == null)
                {
                    throw new UnauthorizedAccessException();
                }

                // Role-based authorization
                var authorizeAttributesWithRoles = authorizeAttributes.Where(attr => !string.IsNullOrWhiteSpace(attr.Roles));

                // Check if there are any role-based authorization attributes
                if (authorizeAttributesWithRoles.Any())
                {
                    var authorized = false;

                    // Iterate through the roles and check if the user belongs to any of them
                    foreach (var roles in authorizeAttributesWithRoles.Select(attr => attr.Roles.Split(",")))
                    {
                        foreach (var role in roles)
                        {
                            var isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                            if (isInRole)
                            {
                                authorized = true;
                                break;
                            }
                        }
                    }
                    // Must be a member of at least one role in roles
                    if (!authorized)
                    {
                        throw new ForbiddenAccessException();
                    }
                }
                // Policy-based authorization
                var authorizeAttributesWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));

                // Check if there are any policy-based authorization attributes
                if (authorizeAttributesWithPolicies.Any())
                {
                    foreach (var policy in authorizeAttributesWithPolicies.Select(a => a.Policy))
                    {
                        var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);

                        if (!authorized)
                        {
                            throw new ForbiddenAccessException();
                        }
                    }
                }
            }

            // Continue to the next handler in the pipeline
            return await next();
        }
    }
}
