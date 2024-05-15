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
        public ObservableCollection<string> Messages { get; set; }
        public ObservableCollection<string> Connections { get; set; }

        public MainWindow()
        {
            InitializeComponent();
            DataContext = this;

            // Inicializace kolekcí
            Messages = new ObservableCollection<string>();
            Connections = new ObservableCollection<string>();

            // Přidat ukázková data
            Messages.Add("Zpráva 1 od klienta A");
            Messages.Add("Zpráva 2 od klienta B");
            Messages.Add("Zpráva 3 od klienta C");

            Connections.Add("Klient A připojen");
            Connections.Add("Klient B odpojen");
            Connections.Add("Klient C připojen");
        }
    }
}