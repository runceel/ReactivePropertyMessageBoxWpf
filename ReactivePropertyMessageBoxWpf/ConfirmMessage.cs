using Reactive.Bindings.Notifiers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ReactivePropertyMessageBoxWpf
{
    public class ConfirmMessage
    {
        public string Title { get; init; }
        public string Content { get; init; }
        public MessageBoxResult MessageBoxResult { get; set; }
    }

    public static class IAsyncMessageSubscriberExtensions
    {
        public static IDisposable AddConfirmMessage(this IAsyncMessageSubscriber self) => 
            self.Subscribe<ConfirmMessage>((message) =>
            {
                message.MessageBoxResult = MessageBox.Show(message.Content, message.Title, MessageBoxButton.OKCancel);
                return Task.CompletedTask;
            });
    }
}
