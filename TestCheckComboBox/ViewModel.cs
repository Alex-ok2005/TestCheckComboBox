using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace TestCheckComboBox
{
    public class ViewModel : INotifyPropertyChanged
    {
        private Client selectedClient;
        public Client SelectedClient
        {
            get { return selectedClient; }
            set
            {
                selectedClient = value;
                OnPropertyChanged("SelectedClient");
            }
        }
        public class Client : INotifyPropertyChanged
        {
            private string clientName;
            public string ClientName
            {
                get { return clientName; }
                set
                {
                    clientName = value;
                    OnPropertyChanged("ClientName");
                }
            }
            public ObservableCollection<string> OrderItems { get; set; }
            public ObservableCollection<string> SelectedOrderItems { get; set; }
            public Client(string newClient)
            {
                ClientName = newClient;
                OrderItems = new ObservableCollection<string>();
                SelectedOrderItems = new ObservableCollection<string>();
            }
            public event PropertyChangedEventHandler PropertyChanged;
            public void OnPropertyChanged([CallerMemberName]string prop = "")
            {
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
            }
        }
        public ObservableCollection<Client> Clients { get; set; }
        public ViewModel()
        {
            Clients = new ObservableCollection<Client>();
            Client _client = new Client("Client No.1");
            _client.OrderItems.Add("Order No.1");
            _client.SelectedOrderItems.Add("Order No.1");
            Clients.Add(_client);

            _client = new Client("Client No.2");
            _client.OrderItems.Add("Order No.1");
            _client.OrderItems.Add("Order No.2");
            _client.SelectedOrderItems.Add("Order No.1");
            _client.SelectedOrderItems.Add("Order No.2");
            Clients.Add(_client);

            _client = new Client("Client No.3");
            _client.OrderItems.Add("Order No.1");
            _client.OrderItems.Add("Order No.2");
            _client.OrderItems.Add("Order No.3");
            _client.SelectedOrderItems.Add("Order No.1");
            _client.SelectedOrderItems.Add("Order No.2");
            _client.SelectedOrderItems.Add("Order No.3");
            Clients.Add(_client);

            SelectedClient = Clients.FirstOrDefault();
        }
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChanged([CallerMemberName]string prop = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(prop));
        }
    }
}
