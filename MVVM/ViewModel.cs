using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    internal class ViewModel : INotifyPropertyChanged
    {

        public event PropertyChangedEventHandler PropertyChanged;

        public RoutedCommand Command { get; set; } = new RoutedCommand();

        // обработчик события для Command (увеличение значения числа на 1)
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            
        }
        public CommandBinding bind; // создание объекта для привязки команды
        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }
    }
}
