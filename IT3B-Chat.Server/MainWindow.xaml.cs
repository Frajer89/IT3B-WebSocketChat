using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;


namespace IT3B_Chat.Server
{
    public partial class MainWindow : Window
    {
        private ObservableCollection<string> messages = new ObservableCollection<string>();
        private ObservableCollection<string> clientActions = new ObservableCollection<string>();

        public MainWindow()
        {
            InitializeComponent();
            MessagesListBox.ItemsSource = messages;
            ClientActionsListBox.ItemsSource = clientActions;
        }

        private void AddMessage(string message)
        {
            messages.Add(message);
        }

        private void AddClientAction(string action)
        {
            clientActions.Add(action);
        }

        private void SendMessageButton_Click(object sender, RoutedEventArgs e)
        {
            string message = MessageTextBox.Text;
            if (!string.IsNullOrWhiteSpace(message))
            {
                AddMessage(message);
                // Zde by měla být logika pro odeslání zprávy všem klientům pomocí WebSocketu
            }
            MessageTextBox.Text = string.Empty;
        }

        private void HandleClientConnected(string clientName)
        {
            AddClientAction($"Client '{clientName}' connected.");
        }

        private void HandleClientDisconnected(string clientName)
        {
            AddClientAction($"Client '{clientName}' disconnected.");
        }
    }
}