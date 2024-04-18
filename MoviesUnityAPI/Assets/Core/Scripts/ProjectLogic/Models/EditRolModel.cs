using SharedLibrary.Interfaces.Entities;

namespace Models
{
    public class EditRolModel : IEditRoleDTO
    {
        public string UserId { get; set; }
        public string RoleName { get; set; }

        public EditRolModel(string userId, string roleName)
        {
            UserId = userId;
            RoleName = roleName;
        }
    }
}