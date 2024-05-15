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

namespace IT3B_Chat.Server
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            // Přidat ukázková data
            MessagesListBox.Items.Add("Zpráva 1 od klienta A");
            MessagesListBox.Items.Add("Zpráva 2 od klienta B");
            MessagesListBox.Items.Add("Zpráva 3 od klienta C");

            ConnectionsListBox.Items.Add("Klient A připojen");
            ConnectionsListBox.Items.Add("Klient B odpojen");
            ConnectionsListBox.Items.Add("Klient C připojen");
        }
    }
}