// Helpers/Settings.cs
using Plugin.Settings;
using Plugin.Settings.Abstractions;

namespace Flags.Helpers
{
  /// <summary>
  /// This is the Settings static class that can be used in your Core solution or in any
  /// of your client applications. All settings are laid out the same exact way with getters
  /// and setters. 
  /// </summary>
  public static class Settings
  {
    private static ISettings AppSettings
    {
      get
      {
        return CrossSettings.Current;
      }
    }

        #region Setting Constants

        private const string ServerAddressKey = "server_address";
        private static readonly string ServerAddressDefault = string.Empty;

        private const string RoomKey = "room";
        private static readonly string RoomDefault = string.Empty;

        #endregion


        public static string ServerAddress
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(ServerAddressKey, ServerAddressDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(ServerAddressKey, value);
            }
        }

        public static string Room
        {
            get
            {
                return AppSettings.GetValueOrDefault<string>(RoomKey, RoomDefault);
            }
            set
            {
                AppSettings.AddOrUpdateValue<string>(RoomKey, value);
            }
        }

    }
}