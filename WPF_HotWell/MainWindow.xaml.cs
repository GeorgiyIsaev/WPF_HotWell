using campersClass;
using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;

namespace WPF_HotWell
{

    public delegate void Info_deleg(string str);
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string info_message;
        public Info_deleg info_deleg;
        public MainWindow()
        {
            InitializeComponent();
            recet_full();
            //InitializeListDate();
        }
        private void InitializeListDate()
        {
            Data_listBox DT = new Data_listBox();
            for (int i = 0; i < 7; i++)
                data_list.Items.Add(DT.DT[i]);
            /*Окей я пока не знаю, как программно передать даты при запуске приложения,
             * отложу это на потом*/
        }

        private void But_Cler_Click(object sender, RoutedEventArgs e)
        {
            recet_full();

            label_info.Content = "";
            input_name.Text = "";
            input_famile.Text = "";
            input_father.Text = "";
            input_tel.Text = "";
            input_countDay.Text = "";
            add_futon.IsChecked = false;
            add_food.IsChecked = false;
            label_info.Content = "";
        }
        private void recet_full()
        {
            info_deleg = messege; //добавил метод для делегата
            //info_message = "";
            campers.read(); // прочесть из файла
            /*Возвращает прежние цвета полей*/
            input_name.Background = Brushes.White;
            input_famile.Background = Brushes.White;
            input_father.Background = Brushes.White;
            input_tel.Background = Brushes.White;
            input_countDay.Background = Brushes.White;
            calor_Room_Back(); //восстановит цвета кнопкам   
        }

        private void But_input_Click(object sender, RoutedEventArgs e)
        {
            recet_full();
            if (if_input_full())
            {
                camper temp = new camper();
                temp.record_FIO_T(input_name.Text, input_famile.Text, input_father.Text, input_tel.Text);
                /*В чем разница между bool? и просто bool? почему я не могу сразу передать значение*/
                temp.record_room(campers.current_room.Value, add_futon.IsChecked == true, add_food.IsChecked == true);
                /*Не получается программное в лист бокс передать даты, 
                 * условно всегда будит только одна дата - сегодняшняя*/

                int count_num = Convert.ToInt32(input_countDay.Text);
                temp.record_DataTime(DateTime.Now, DateTime.Now.AddDays(count_num));

                campers.list_campers.Add(temp);
                label_info.Content = campers.find_nuber_room_STR(campers.current_room.Value);
                campers.save();
            }
            else
            {
                MessageBox.Show(info_message);
                info_message = "";
            }
        }
        private void messege(string mes)
        {
            info_message += mes;
        }

        private bool if_input_full()
        {
            List<bool> false_if = new List<bool>();
            /*Проверка что все записи присутствуют перед началом записи*/
            if (input_name.Text == "") { info_deleg?.Invoke("Не заполнено поле - Имя\n"); input_name.Background = Brushes.Yellow; false_if.Add(false); }
            if (input_famile.Text == "") { info_deleg?.Invoke("Не заполнено поле - Фамилия\n"); input_famile.Background = Brushes.Yellow; false_if.Add(false); }
            if (input_father.Text == "") { info_deleg?.Invoke("Не заполнено поле - Отчество\n"); input_father.Background = Brushes.Yellow; false_if.Add(false); }
            if (input_tel.Text == "") { info_deleg?.Invoke("Не заполнено поле - Телефон\n"); input_tel.Background = Brushes.Yellow; false_if.Add(false); }
            if (input_countDay.Text == "") { info_deleg?.Invoke("Не введено количество дней проживания\n"); input_countDay.Background = Brushes.Yellow; false_if.Add(false); }
            /*Короче для проверки на число нашел вот такую замудренную конструкцию*/
            int num = 0;
            if (!int.TryParse(input_countDay.Text, out num))
            {
                info_deleg?.Invoke("Количество дней проживания должно быть числом!\n");
                input_countDay.Background = Brushes.Yellow; false_if.Add(false);
            }

            /*Проверка занятости комнаты*/
            if (campers.current_room == null) { info_deleg?.Invoke("Не выбрана комната для заселения\n"); false_if.Add(false); }
            if (campers.current_room != null && campers.find_nuber_room(campers.current_room.Value)) { info_deleg?.Invoke("В выбранной комнате уже кто-то живет\n"); false_if.Add(false); }

            foreach (bool if_it in false_if)
                if (if_it == false) return false;
            return true;
        }


        private void B_101_Click(object sender, RoutedEventArgs e)
        { /*Это для каждой кнопки получается придется обработчик делать... */
          /*Что я хочу: если никто там не живет, то при нажатии меняется на желтый цвет,
           * и выводит информацию в лейб, если живет красный цвет и информацию о жильце*/

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
        {/*Повторяющаяся часть для всех комнат*/
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
        { /*Этот метод должен восстанавливать цвет всем комнатам-кнопкам*/
          /*А какой цвет был изначально на кнопке.. ЛОЛ??*/
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
            for (int i = 0; i < 7; i++)
            {
                /*Не знаю, как еще по-иному можно записать сегодняшнюю дату в дату*/
                DateTime temp = new DateTime(DateTime.Now.Day, DateTime.Now.Month, DateTime.Now.Year);
                temp.AddDays(i);
                DT.Add(temp);
            }
        }
    }
}



