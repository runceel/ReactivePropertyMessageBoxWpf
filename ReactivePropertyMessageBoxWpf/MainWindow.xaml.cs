using Reactive.Bindings.Extensions;
using Reactive.Bindings.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reactive.Disposables;
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
        private CompositeDisposable Disposables { get; } = new CompositeDisposable();
        private AsyncMessageBroker AsyncMessageBroker { get; }
        public MainWindow()
        {
            InitializeComponent();

            AsyncMessageBroker = new AsyncMessageBroker().AddTo(Disposables);
            DataContext = new MainWindowViewModel(AsyncMessageBroker);
            AsyncMessageBroker.AddConfirmMessage().AddTo(Disposables);
        }

        private void Window_Closed(object sender, EventArgs e) => Disposables.Dispose();
    }
}
