using System.Collections.Generic;
using VirtoCommerce.Platform.Core.Settings;

namespace Golrang.Province.Core;

public static class ModuleConstants
{
    public static class Security
    {
        public static class Permissions
        {
            public const string Access = "Province:access";
            public const string Create = "Province:create";
            public const string Read = "Province:read";
            public const string Update = "Province:update";
            public const string Delete = "Province:delete";

            public static string[] AllPermissions { get; } =
            {
                Access,
                Create,
                Read,
                Update,
                Delete,
            };
        }
    }

    public static class Settings
    {
        public static class General
        {
            public static SettingDescriptor ProvinceEnabled { get; } = new SettingDescriptor
            {
                Name = "Province.ProvinceEnabled",
                GroupName = "Province|General",
                ValueType = SettingValueType.Boolean,
                DefaultValue = false,
            };

            public static SettingDescriptor ProvincePassword { get; } = new SettingDescriptor
            {
                Name = "Province.ProvincePassword",
                GroupName = "Province|Advanced",
                ValueType = SettingValueType.SecureString,
                DefaultValue = "qwerty",
            };

            public static IEnumerable<SettingDescriptor> AllGeneralSettings
            {
                get
                {
                    yield return ProvinceEnabled;
                    yield return ProvincePassword;
                }
            }
        }

        public static IEnumerable<SettingDescriptor> AllSettings
        {
            get
            {
                return General.AllGeneralSettings;
            }
        }
    }
}
