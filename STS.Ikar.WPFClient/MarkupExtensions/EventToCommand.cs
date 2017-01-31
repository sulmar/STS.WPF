using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Markup;

namespace STS.Ikar.WPFClient.MarkupExtensions
{
    /// <summary>
    /// Inspired by
    /// http://blogs.microsoft.co.il/pavely/2012/04/07/wpf-45-markup-extension-for-events/
    /// </summary>
    public class EventToCommand : MarkupExtension
    {
        public string BindingCommandPath { get; set; }

        // not that useful
        public ICommand Command { get; set; }

        //private string _commandPath;
        //private ICommand _command;
        private Type _eventArgsType;

        public EventToCommand(string bindingCommandPath)
        {
            BindingCommandPath = bindingCommandPath;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var pvt = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;
            if (pvt != null)
            {
                var evt = pvt.TargetProperty as EventInfo;
                var doAction = GetType().GetMethod("DoAction", BindingFlags.NonPublic | BindingFlags.Instance);
                Type dlgType = null;
                if (evt != null)
                {
                    dlgType = evt.EventHandlerType;
                }
                var mi = pvt.TargetProperty as MethodInfo;
                if (mi != null)
                {
                    dlgType = mi.GetParameters()[1].ParameterType;
                }
                if (dlgType != null)
                {
                    _eventArgsType = dlgType.GetMethod("Invoke").GetParameters()[1].ParameterType;
                    return Delegate.CreateDelegate(dlgType, this, doAction);
                }
            }
            return null;
        }

        void DoAction(object sender, RoutedEventArgs e)
        {
            var dc = (sender as FrameworkElement).DataContext;
            if (BindingCommandPath != null)
            {
                Command = (ICommand)ParsePropertyPath(dc, BindingCommandPath);
            }
            Type eventArgsType = typeof(EventCommandArgs<>).MakeGenericType(_eventArgsType);
            var cmdParams = Activator.CreateInstance(eventArgsType, sender, e);
            if (Command != null && Command.CanExecute(cmdParams))
                Command.Execute(cmdParams);
        }


        static object ParsePropertyPath(object target, string path)
        {
            var props = path.Split('.');
            foreach (var prop in props)
            {
                target = target.GetType().GetProperty(prop).GetValue(target);
            }
            return target;
        }
    }
}
