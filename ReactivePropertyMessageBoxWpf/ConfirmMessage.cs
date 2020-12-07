using Reactive.Bindings.Notifiers;
using System;
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
        public static T AddConfirmMessage<T>(this T self, Action<IDisposable> addTo = null)
            where T : IAsyncMessageSubscriber
        {
            var disposable = self.Subscribe<ConfirmMessage>((message) =>
            {
                message.MessageBoxResult = MessageBox.Show(message.Content, message.Title, MessageBoxButton.OKCancel);
                return Task.CompletedTask;
            });
            addTo?.Invoke(disposable);
            return self;
        }
    }
}
