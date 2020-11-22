
using System;
using System.Collections;
using System.Collections.Generic;

namespace PermissionMatrix
{
    class Program
    {
        static void Main(string[] args)
        {
            Dictionary<string, bool> permissions = new Dictionary<string, bool>();
            permissions.Add(PermissionType.CUSTOMER_OWNER.ToString(), true);
            permissions.Add(PermissionType.CUSTOMER_ADMIN.ToString(), true);
            permissions.Add(PermissionType.CUSTOMER_EDITOR.ToString(), true);
            permissions.Add(PermissionType.CUSTOMER_VIEWER.ToString(), false);
            PermissionMatrix.Add(PermissionNames.SetOrderPriority, permissions);

            UserRoleNType userRoleNType = new UserRoleNType
            {
                IsCustomer = false,
                Role = UserRole.Viewer
            };

            var hasAccess = PermissionMatrix.HasAccess(PermissionNames.SetOrderPriority, userRoleNType);

            Console.WriteLine(hasAccess);
            Console.ReadKey();
        }
    }

    public static class PermissionMatrix
    {
        private static readonly Dictionary<string, Dictionary<string, bool>> Matrix = new Dictionary<string, Dictionary<string, bool>>();


        public static Dictionary<string, Dictionary<string, bool>> Get()
        {
            return Matrix;
        }

        public static void Add(string key, Dictionary<string, bool> value)
        {
            Matrix.Add(key, value);
        }

        public static bool HasAccess(string key,  UserRoleNType roleNType)
        {
            Matrix.TryGetValue(key, out Dictionary<string, bool> permissions);

            var permissionKey = roleNType.MakeKey();

            permissions.TryGetValue(permissionKey, out bool hasAccess);

            return hasAccess;
        }
    }

    public static class PermissionNames
    {
        public const string SetOrderPriority = "Set Order Priority";
    }
}
