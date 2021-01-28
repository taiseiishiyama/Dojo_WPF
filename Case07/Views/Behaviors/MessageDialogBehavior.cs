using System.Windows;

namespace Case07.Views.Behaviors
{
    public interface IMessageDialogParameter
    {
        string Message { get; }
    }

    internal class MessageDialogBehavior
    {
        public static readonly DependencyProperty MessageDialogParameterProperty = DependencyProperty.RegisterAttached(
           "MessageDialogParameter",
           typeof(IMessageDialogParameter),
           typeof(MessageDialogBehavior),
           new PropertyMetadata(default(IMessageDialogParameter), OnCallbackPropertyChanged)
       );

        public static IMessageDialogParameter GetMessageDialogParameter(DependencyObject target) => (IMessageDialogParameter)target.GetValue(MessageDialogParameterProperty);

        public static void SetMessageDialogParameter(DependencyObject target, IMessageDialogParameter value) => target.SetValue(MessageDialogParameterProperty, value);

        private static void OnCallbackPropertyChanged(DependencyObject sender, DependencyPropertyChangedEventArgs e)
        {
            if ((e.NewValue as IMessageDialogParameter)?.Message == null)
            {
                return;
            }

            MessageBox.Show((e.NewValue as IMessageDialogParameter).Message);
        }
    }
}
