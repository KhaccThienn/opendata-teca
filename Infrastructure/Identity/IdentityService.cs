namespace Infrastructure.Identity
{
    /// <summary>
    /// Dịch vụ quản lý các hoạt động liên quan đến danh tính.
    /// </summary>
    public class IdentityService : IIdentityService
    {
        private readonly UserManager<ApplicationUser>                 _userManager;
        private readonly IUserClaimsPrincipalFactory<ApplicationUser> _userClaimsPrincipalFactory;
        private readonly IAuthorizationService                        _authorizationService;

        public IdentityService(
            UserManager<ApplicationUser>                 userManager,
            IUserClaimsPrincipalFactory<ApplicationUser> userClaimsPrincipalFactory,
            IAuthorizationService                        authorizationService)
        {
            _userManager                = userManager;
            _userClaimsPrincipalFactory = userClaimsPrincipalFactory;
            _authorizationService       = authorizationService;
        }

        /// <summary>
        /// Ủy quyền người dùng dựa trên chính sách được chỉ định.
        /// </summary>
        /// <param name="userId">ID người dùng.</param>
        /// <param name="policyName">Tên chính sách.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động không đồng bộ. Kết quả tác vụ chứa một boolean chỉ ra liệu ủy quyền có thành công hay không.</returns>
        public async Task<bool> AuthorizeAsync(string userId, string policyName)
        {
            var user = await _userManager.FindByIdAsync(userId);

            if (user == null)
            {
                return false;
            }

            var principal = await _userClaimsPrincipalFactory.CreateAsync(user);

            var result = await _authorizationService.AuthorizeAsync(principal, policyName);

            return result.Succeeded;
        }

        /// <summary>
        /// Tạo một người dùng mới với tên người dùng và mật khẩu được chỉ định.
        /// </summary>
        /// <param name="userName">Tên người dùng.</param>
        /// <param name="password">Mật khẩu.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động không đồng bộ. Kết quả tác vụ chứa một tuple với kết quả của hoạt động và ID người dùng.</returns>
        public async Task<(Result Result, string UserId)> CreateUserAsync(string userName, string password)
        {
            var user = new ApplicationUser
            {
                UserName = userName,
                Email    = userName,
            };

            var result = await _userManager.CreateAsync(user, password);

            return (result.ToApplicationResult(), user.Id);
        }

        /// <summary>
        /// Xóa người dùng với ID được chỉ định.
        /// </summary>
        /// <param name="userId">ID người dùng.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động không đồng bộ. Kết quả tác vụ chứa kết quả của hoạt động.</returns>
        public async Task<Result> DeleteUserAsync(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);

            return user != null ? await DeleteUserAsync(user) : Result.Success();
        }

        /// <summary>
        /// Xóa người dùng được chỉ định.
        /// </summary>
        /// <param name="user">Người dùng.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động không đồng bộ. Kết quả tác vụ chứa kết quả của hoạt động.</returns>
        public async Task<Result> DeleteUserAsync(ApplicationUser user)
        {
            var result = await _userManager.DeleteAsync(user);

            return result.ToApplicationResult();
        }

        /// <summary>
        /// Lấy tên người dùng cho ID người dùng được chỉ định.
        /// </summary>
        /// <param name="userId">ID người dùng.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động không đồng bộ. Kết quả tác vụ chứa tên người dùng.</returns>
        public async Task<string?> GetUserNameAsync(string userId)
        {
            var user = await _userManager.Users.FirstAsync(u => u.Id == userId);

            return user != null ? user.UserName : string.Empty;
        }

        /// <summary>
        /// Xác định liệu người dùng được chỉ định có trong vai trò được chỉ định hay không.
        /// </summary>
        /// <param name="userId">ID người dùng.</param>
        /// <param name="role">Vai trò.</param>
        /// <returns>Một tác vụ đại diện cho hoạt động không đồng bộ. Kết quả tác vụ chứa một boolean chỉ ra liệu người dùng có trong vai trò hay không.</returns>
        public async Task<bool> IsInRoleAsync(string userId, string role)
        {
            var user = _userManager.Users.SingleOrDefault(u => u.Id == userId);

            return user != null && await _userManager.IsInRoleAsync(user, role);
        }
    }
}
