using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        private string? localShare;
        private string? remoteShare;

        public GetData(string nameE, string userE, string noteE)
        {
            name = nameE;
            user = userE;
            note = noteE;

            _ = MessageBox.Show("Tutaj będzie zbieranie danych");
            SeeData();
        }

        public string? Name { get => name; set => name = value; }

        public void SeeData()
        {
            _ = MessageBox.Show(name);
        }

    }
}
