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

        public List<string> ComboChange // свойство для заполнения Combobox
        {
            get
            {
                return Model.dataList;
            }
        }
        int cbIndex = -1;
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                cbIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("CBIndex"));  // событие, которое реагирует на изменение свойства
            }
        }
        public string CBIndex // свойство для отображения фамилии в Combobox
        {
            get
            {
                if (cbIndex == -1)
                {
                    return "";
                }
                else
                {
                   return Model.dataList[cbIndex];
                }

            }
        }
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
