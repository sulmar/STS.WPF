using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace STS.Ikar.WPFClient.MarkupExtensions
{
    public sealed class EventCommandArgs<TEventArgs> where TEventArgs : RoutedEventArgs
    {
        public TEventArgs EventArgs { get; private set; }
        public object Sender { get; private set; }

        public EventCommandArgs(object sender, TEventArgs args)
        {
            Sender = sender;
            EventArgs = args;
        }
    }
}
