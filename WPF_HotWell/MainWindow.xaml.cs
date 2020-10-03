using System;
using System.IO;
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

using campersClass;

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

            calor_Room_Back(); //востановит цвета кнопкам
        }

        private void But_input_Click(object sender, RoutedEventArgs e)
        {
            if (if_input_full())
            {
                camper temp = new camper();
                temp.record_FIO_T(input_name.Text, input_famile.Text, input_father.Text, input_tel.Text);
                /*В чем разница между bool? и просто bool? почему я не могу сразу передать значеие*/
                temp.record_room(campers.current_room.Value, add_futon.IsChecked == true, add_food.IsChecked == true);
                /*Не получается програмно в лсит бокс передать даты, 
                 * условно всегда будит только одна сегодняшняя*/
                
                //DateTime now_it = new DateTime(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);  
                int count_num = Convert.ToInt32(input_countDay.Text);
                label_info.Content = $"Дата {DateTime.Now} Число: {count_num}"; /*для проверки */
                temp.record_DataTime(DateTime.Now, DateTime.Now.AddDays(count_num));
                using (var file = new StreamWriter("info.log", true))
                {
                    file.WriteLine(temp.file_save());
                }                
                campers.list_campers.Add(temp);
                label_info.Content = campers.find_nuber_room_STR(campers.current_room.Value);
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

            /*Проверка занятости комнаты*/
            if (campers.current_room == null) return false;
            if (campers.find_nuber_room(campers.current_room.Value)) return false;

            return true;
        }


        private void B_101_Click(object sender, RoutedEventArgs e)
        { /*Это для каждой кнопки получается придется обработчик делать... */
          /*Что я хочу: если никто там не живет то при нажатии меняется на желтый желтый цвет,
           * и выводит инфомрацию в лейб, если живет красный цвет и информацию о жильце*/

            campers.current_room = 101;
            obrabotka_komnat(b_101);
        }
        private void B_102_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 102;
            obrabotka_komnat(b_102);
            
        }
        private void B_103_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 103;
            obrabotka_komnat(b_103);
        }
        private void B_104_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 104;
            obrabotka_komnat(b_104);
        }
        private void B_105_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 105;
            obrabotka_komnat(b_105);
        }
        private void B_106_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 106;
            obrabotka_komnat(b_106);
        }
        private void B_201_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 201;
            obrabotka_komnat(b_201);
        }
        private void B_202_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 202;
            obrabotka_komnat(b_202);
        }
        private void B_203_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 203;
            obrabotka_komnat(b_203);
        }
        private void B_204_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 204;
            obrabotka_komnat(b_204);
        }
        private void B_205_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 205;
            obrabotka_komnat(b_205);
        }
        private void B_206_Click(object sender, RoutedEventArgs e)
        {
            campers.current_room = 206;
            obrabotka_komnat(b_206);
        }


        private void obrabotka_komnat(Button b)
        {/*Повторяющаяяся часть для всех комнат*/
            calor_Room_Back();
            if (campers.find_nuber_room(campers.current_room.Value))
            {
                b.Background = Brushes.Red;
                label_info.Content = campers.find_nuber_room_STR(campers.current_room.Value);
            }
            else
            {
                b.Background = Brushes.Yellow;
                label_info.Content = $"Комната {campers.current_room.Value} свободна";
            }
        }

        private void calor_Room_Back()
        { /*Этот метод должен востанавливать цвет все другим комнатам-кнопкам*/
          /*А какой цвет был изначально на кнопке??*/
            b_101.Background = campers.find_nuber_room(101) ? Brushes.Red : Brushes.White;
            b_102.Background = campers.find_nuber_room(102) ? Brushes.Red : Brushes.White;
            b_103.Background = campers.find_nuber_room(103) ? Brushes.Red : Brushes.White;
            b_104.Background = campers.find_nuber_room(104) ? Brushes.Red : Brushes.White;
            b_105.Background = campers.find_nuber_room(105) ? Brushes.Red : Brushes.White;
            b_106.Background = campers.find_nuber_room(106) ? Brushes.Red : Brushes.White;

            b_201.Background = campers.find_nuber_room(201) ? Brushes.Red : Brushes.White;
            b_202.Background = campers.find_nuber_room(202) ? Brushes.Red : Brushes.White;
            b_203.Background = campers.find_nuber_room(203) ? Brushes.Red : Brushes.White;
            b_204.Background = campers.find_nuber_room(204) ? Brushes.Red : Brushes.White;
            b_205.Background = campers.find_nuber_room(205) ? Brushes.Red : Brushes.White;
            b_206.Background = campers.find_nuber_room(206) ? Brushes.Red : Brushes.White;
            /*Короче где нет жильцов белые, где уже есть красные*/
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



    
}
