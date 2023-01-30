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
        public CommandBinding bind; // создание объекта для привязки команды
        public RoutedCommand Command { get; set; } = new RoutedCommand();
        private static int CBIndex = -1;
        private bool CheckStart = true;

        public ViewModel()
        {
            bind = new CommandBinding(Command);  // инициализация объекта для привязки данных
            bind.Executed += Command_Executed;  // добавление обработчика событий
        }

        public List<string> ComboBoxChange // свойство для заполнения Combobox
        {
            get
            {
                return Model.OperationList;
            }
        }
      
        public int IndexSelected // свойство для нахождения индекса выбранного в Combobox элемента
        {
            set
            {
                // индек - это необходимое значение, которое нужно получить
                CBIndex = value;
                PropertyChanged(this, new PropertyChangedEventArgs("Operation"));  // событие, которое реагирует на изменение свойства
            }
        }
  
        public void Command_Executed(object sender, ExecutedRoutedEventArgs e)
        {
            PropertyChanged(this, new PropertyChangedEventArgs("Result"));
        }

        public string Result
        {
            get => GetResult(Model.one.Text, Model.two.Text);
            set
            {
            }
        }

        private string GetResult(string one, string two)
        {
            try
            {
                double One = Convert.ToDouble(one);
                double Two = Convert.ToDouble(two);

                if(CBIndex == 3 && Two == 0)
                {
                    return "Ошибка деления на 0";
                }

                else return Calculation(One, Two);
            }
            catch
            {
                if (CheckStart)
                {
                    CheckStart = false;
                    return "";
                }
                return "Введите числа корректно";
            }
        }

        private string Calculation(double one, double two)
        {
            switch (CBIndex)
            {
                case 0:
                    return (one + two).ToString();
                case 1:
                    return (one - two).ToString();
                case 2:
                    return (one * two).ToString();
                case 3:
                    return (one / two).ToString();
                default:
                    return "Действие не выбрано";
            }
        }
        public string Operation // свойство для отображения фамилии в Combobox
        {
            get
            {
                if (CBIndex == -1)
                {
                    return "";
                }
                else
                {
                    return Model.dataList[CBIndex];
                }

            }
        }
    }
}

