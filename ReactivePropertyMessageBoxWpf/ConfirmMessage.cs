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
}
