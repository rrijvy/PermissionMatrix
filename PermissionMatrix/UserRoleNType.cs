namespace PermissionMatrix
{
    public class UserRoleNType
    {
        public bool IsCustomer { get; set; }
        public UserRole Role { get; set; }

        public string MakeKey()
        {
            string userType = IsCustomer ? "CUSTOMER" : "SUPPLIER";
            string userRole = Role.ToString().ToUpper();
            return $"{userType}_{userRole}";
        }
    }
}
