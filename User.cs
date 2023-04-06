using System.DirectoryServices.AccountManagement;
using System.Security.Cryptography;
using System.Runtime.InteropServices;
using System;
using System.Windows;

namespace AuditHelper3
{
    class User
    {
        // Nazwa użytkownika
        private const string username = "BITAdmin_test";
        public static string Username => username;
        private const string fullname = "Administrator lokalny BetterIT";
        public bool userCreated = false;

        public string Password { get; } = "";

        public User()
        {
            if (!RuntimeInformation.IsOSPlatform(OSPlatform.Windows))
            {
                _ = MessageBox.Show("Aplikacja działa wyłącznie w systemie Windows");
                return;
            }

            // Tworzenie kontekstu maszyny lokalnej
            PrincipalContext context = new(ContextType.Machine);

            // Check if a user with the specified username already exists
            UserPrincipal existingUser = UserPrincipal.FindByIdentity(context, username);
            if (existingUser != null)
            {
                _ = MessageBox.Show("Użytkownik BITAdmin już istnieje");
                return;
            }

            // Generowanie hasła
            Password = GenerateRandomPassword;

            // Tworzenie obiektu użytkownika
            UserPrincipal user = new(context)
            {
                // Ustawienie właściwości użytkownika
                SamAccountName = username,
                DisplayName = fullname
            };
            user.SetPassword(Password);
            user.Enabled = true;

            // Zapisanie użytkownika
            user.Save();

            // Dodanie użytkownika do grupy administratorów
            // Check if the "Administrators" group exists
            GroupPrincipal group = GroupPrincipal.FindByIdentity(context, "Administrators") ?? GroupPrincipal.FindByIdentity(context, "Administratorzy");

            // Add the new user to the group
            if (group == null)
            {
                _ = MessageBox.Show("Nie znaleziono grupy administratorów");
                return;
            }
            else
            {
                group.Members.Add(user);
                group.Save();
            }

            userCreated = true;
        }

        private static string GenerateRandomPassword
        {
            get
            {
                const int passwordLength = 12;
                const string validChars =
                    "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz123456789!@#$%&*?-";

                using RandomNumberGenerator rng = RandomNumberGenerator.Create();
                byte[] uintBuffer = new byte[sizeof(uint)];

                char[] chars = new char[passwordLength];
                int validCharsCount = validChars.Length;
                for (int i = 0; i < passwordLength; i++)
                {
                    rng.GetBytes(uintBuffer);
                    uint num = BitConverter.ToUInt32(uintBuffer, 0);
                    chars[i] = validChars[(int)(num % (uint)validCharsCount)];
                }

                return new string(chars);
            }
        }
    }
}
