using Reactive.Bindings.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ReactivePropertyMessageBoxWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            var messageBroker = new AsyncMessageBroker();
            DataContext = new MainWindowViewModel(messageBroker);
            messageBroker.Subscribe<AlertMessage>((message) =>
            {
                message.MessageBoxResult = MessageBox.Show(message.Content, message.Title);
                return Task.CompletedTask;
            });
        }
    }
}
