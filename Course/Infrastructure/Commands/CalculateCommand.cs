using Course.Infrastructure.Commands.Base;
using System.Windows;

namespace Course.Infrastructure.Commands
{
    internal class CalculateCommand : Command
    {
        public override bool CanExecute(object parameter) => true;

        public override void Execute(object parameter) => Application.Current.Shutdown();
    }
}