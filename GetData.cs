using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Management;
using System.Windows;

namespace AuditHelper3
{
    class GetData
    {
        private string? hostname;
        private string? name;
        private string? user;
        private string? note;
        private string? anyDeskID;
        private IDictionary<string, string> shares = new Dictionary<string, string>();

        public GetData(string nameE, string userE, string noteE)
        {
            // Zapisanie podanych informacji do zmiennych
            name = nameE;
            user = userE;
            note = noteE;

            // Sprawdzenie hostname urządzenia
            hostname = System.Net.Dns.GetHostName();

            // Sprawdzanie AnyDeskID
            CheckAnyDesk();

            // Sprawdzenie mapowanych dysków
            ChceckShares();
        }

        private void CheckAnyDesk()
        {
            // Tworzenie pliku ze skryptem
            string script = "@echo off\r\npath=C:\\Program Files (x86)\\AnyDesk-c035baa3;%path%\r\nfor /f \"delims=\" %%i in ('AnyDesk-c035baa3 --get-id') do set CID=%%i\r\necho %CID%";

            File.WriteAllText("script.bat", script);

            // Uruchomienie skryptu
            ProcessStartInfo psi = new ProcessStartInfo("cmd.exe")
            {
                Arguments = "/c script.bat",
                RedirectStandardOutput = true,
                UseShellExecute = false,
                CreateNoWindow = true
            };
            Process p = Process.Start(psi);

            // Zapisanie wyniku
            anyDeskID = p.StandardOutput.ReadToEnd();
            p.WaitForExit();

            // Usunięcie pliku ze skryptem
            File.Delete("script.bat");
        }

        private void ChceckShares()
        {
            // Dokumentacja: https://learn.microsoft.com/en-us/windows/win32/cimwin32prov/win32-mappedlogicaldisk
            var searcher = new ManagementObjectSearcher("root\\CIMV2",
                                                        $"SELECT * FROM Win32_MappedLogicalDisk");

            foreach (ManagementObject queryObj in searcher.Get())
            {
                // Litera dysku jako klucz, ścieżka sieciowa jako wartość
                shares.Add(queryObj["Name"].ToString(), queryObj["ProviderName"].ToString());
            }

        }


        public string? Hostname { get => hostname; set => hostname = value; }
        public string? Name { get => name; set => name = value; }
        public string? User { get => user; set => user = value; }
        public string? Note { get => note; set => note = value; }
        public string? AnyDeskID { get => anyDeskID; set => anyDeskID = value; }
        public IDictionary<string, string> Shares { get => shares; set => shares = value; }
    }
}
