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
         //InitializeListDate();
        }
        private void InitializeListDate()
        {
            Data_listBox DT = new Data_listBox();
            for (int i = 0; i < 7; i++)
                data_list.Items.Add(DT.DT[i]);
            /*Окей я пока не знаю как програмно передать даты при запуске приложения,
             * отложу это на потом*/
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
            label_info.Content = "";

            /*Возвращает прежние цвета полей*/
            input_name.Background = Brushes.White;
            input_famile.Background = Brushes.White;
            input_father.Background = Brushes.White;
            input_tel.Background = Brushes.White;
            input_countDay.Background = Brushes.White;
        }

        private void But_input_Click(object sender, RoutedEventArgs e)
        {
            if (if_input_full())
            {
                camper temp = new camper();
                temp.record_FIO_T(input_name.Text, input_famile.Text, input_father.Text, input_tel.Text);
                /*В чем разница между bool? и просто bool? почему я не могу сразу передать значеие*/
                temp.record_room(0, add_futon.IsChecked == true, add_food.IsChecked == true);
                /*Не получается програмно в лсит бокс передать даты, 
                 * условно всегда будит только одна сегодняшняя*/
                
                //DateTime now_it = new DateTime(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);

                int count_num = Convert.ToInt32(input_countDay.Text);
                label_info.Content = $"Дата {DateTime.Now} Число: {count_num}";/*{now_it} */
                temp.record_DataTime(DateTime.Now, DateTime.Now.AddDays(count_num)); 

            }
            else
            {
                MessageBox.Show("Неполные данные"); 
            }
            
            /*if(проверка всех введений), если нет сменим цвет кнопки*/
            /*Ели все ок записываем данные в структуру, записывать буду методом а затем обект кидать в лист*/

            //List<camper> list_campers = new List<camper>();
            //list_campers.Add();

        }
        private bool if_input_full()
        {
            /*Проверка что все записи присутствуют перед началом записи*/
            if (input_name.Text == "") { input_name.Background = Brushes.Yellow; return false; }
            if (input_famile.Text == "") { input_famile.Background = Brushes.Yellow; return false; }
            if (input_father.Text == "") { input_father.Background = Brushes.Yellow; return false; }
            if (input_tel.Text == "") { input_tel.Background = Brushes.Yellow; return false; }
            if (input_countDay.Text == "") { input_countDay.Background = Brushes.Yellow; return false; }
            /*Короче для проверки на число нашел вот такую замудренную конструкцию*/
            int num = 0;
            if(!int.TryParse(input_countDay.Text, out num))
            {
                input_countDay.Background = Brushes.Yellow; return false;
            }       

            /*Надо добавить проверка что сило дне это число*/
            /*Еще нужно добавать, что выбрана конмната - отдельный метод*/
            return true;
        }
    }
    class Data_listBox
    {
        public List<DateTime> DT;
        public Data_listBox()
        {
            DT = new List<DateTime>();
            for(int i =0; i<7; i++)
            {
                /*Не знаю как еще по иному можно записать сегоднюшнюю дату в дату*/
                DateTime temp = new DateTime(DateTime.Now.Day, DateTime.Now.Month , DateTime.Now.Year);
                temp.AddDays(i);
                DT.Add(temp);
            }
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
        /*Запись данных в структуру*/
        public void record_FIO_T(string n, string f, string nfather, string tel)
        {
            name = n; famile = f; name_father = nfather; telefon = tel;
        }
        public void record_room(int n, bool futon, bool food)
        {
            number_room= n; if_futon = futon; if_food = food;
        }
        public void record_DataTime (DateTime begin, DateTime end)
        {
            data_input = begin; data_output = end;
        }
    }




}
