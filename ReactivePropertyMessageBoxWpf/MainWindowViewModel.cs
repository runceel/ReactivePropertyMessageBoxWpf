using Reactive.Bindings;
using Reactive.Bindings.Notifiers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;

namespace ReactivePropertyMessageBoxWpf
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
#pragma warning disable 0067
        public event PropertyChangedEventHandler PropertyChanged;
#pragma warning restore 0067

        public IAsyncMessagePublisher MessagePublisher { get; }

        public AsyncReactiveCommand AlertCommand { get; }
        public ReactivePropertySlim<string> Message { get; }

        public MainWindowViewModel(IAsyncMessagePublisher messagePublisher)
        {
            MessagePublisher = messagePublisher;
            Message = new ReactivePropertySlim<string>();

            AlertCommand = new AsyncReactiveCommand()
                .WithSubscribe(async () =>
                {
                    var alertMessage = new AlertMessage
                    {
                        Title = "Info",
                        Content = "Hello world",
                    };
                    await MessagePublisher.PublishAsync(alertMessage);
                    Message.Value = $"{alertMessage.MessageBoxResult} が押されました。";
                });
        }
    }
}
