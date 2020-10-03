using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;



namespace WPF_HotWell
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void But_Cler_Click(object sender, RoutedEventArgs e)
        {
            label_info.Content = "";
            input_name.Text = "";
            input_famile.Text = "";
            input_father.Text = "";
            input_tel.Text = "";
            input_countDay.Text = "";
            add_futon.IsChecked = false;
            add_food.IsChecked = false;
        }

        private void But_input_Click(object sender, RoutedEventArgs e)
        {
            List<camper> list_campers = new List<camper>();


        }
    }

    static class campers
    {
        //? вынести колекция в стаитчный класс и сделать глобальной переменной
        static public List<camper> list_campers = new List<camper>();

    }


    class camper
    {
        string name;
        string famile;
        string name_father;
        string telefon;
        int number_room;
        bool if_futon;
        bool if_food;
        DateTime data_input;
        DateTime data_output;

        public override string ToString()
        {
            string temp = $"Гость: {name} {famile} {name_father}\n" +
                $"Контактный Телефон: {telefon}\n";
            if (if_futon || if_food)
            {
                temp += "Заказал";
                if (if_futon) temp += " Допольнительный футон;\n";
                if (if_futon) temp += " Еду в номер;\n";
                temp += "\n";
            }
            temp += $"Дата засиления: {data_input}, выселения {data_output}\n";
            temp += $"Номер будит занят еще {data_output - data_input} дней.";
            return temp;
        }
    }




}
