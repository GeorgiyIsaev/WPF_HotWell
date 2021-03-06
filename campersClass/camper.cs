﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace campersClass
{
    public delegate void record_info(string str);
    public delegate void delegat_na_odin_raz();
    public static class campers
    {
        public static record_info log_info;
        public static delegat_na_odin_raz one_read_delegat = read;
        static public int? current_room; /*Сюда буду записывать текущую выбранную комнату*/
        /*int?  что бы инту можно было присвоит null*/

        static public List<camper> list_campers = new List<camper>();
        static public bool find_nuber_room(int num)
        { /*Поиск по комнате*/
            foreach (camper tmp in campers.list_campers)
                if (tmp.if_nuber_it(num)) return true; /*Здесь кто-то живет*/
            return false;
        }
        static public string find_nuber_room_STR(int num)
        { /*Поиск по комнате - все также только возвращаем строку*/
            foreach (camper tmp in campers.list_campers)
                if (tmp.if_nuber_it(num)) return tmp.ToString(); /*Здесь кто-то живет*/
            return "Ничего не найдено";
        }
        static public void save()
        {
            using (var file = new StreamWriter("info.txt"))
            {
                foreach (camper tmp in campers.list_campers)
                    file.WriteLine(tmp.file_save());
                log_info?.Invoke($"Временый файл temp.txt перезаписан, заселено {list_campers.Count} жильцов");
            }
        }
        static public void read()
        {
            string temp_str;
            //camper temp = new camper();
            using (StreamReader sr = new StreamReader("info.txt"))
            {
                while (true)
                {
                    camper temp = new camper();
                    temp_str = sr.ReadLine();
                    /*Парсим ФИО*/
                    if (temp_str == null) break;
                    string[] stroka = temp_str.Split(":".ToCharArray());
                    /*Не знаю, как сделать проверку в C# на конец файла, в интернете не нашел, сделал так*/
                    if (stroka.Length < 2) break;

                    temp.record_FIO_T(stroka[0], stroka[1], stroka[2], stroka[3]);

                    temp_str = sr.ReadLine();
                    stroka = temp_str.Split(":".ToCharArray());
                    temp.record_room(Convert.ToInt32(stroka[0]), stroka[1] == "True", stroka[2] == "True");
                    /*Проверка что, такой постоялец уже есть*/
                    if (!find_nuber_room(Convert.ToInt32(stroka[0]))) {
                        temp_str = sr.ReadLine();
                        DateTime d1 = DateTime.Parse(temp_str);
                        temp_str = sr.ReadLine();
                        DateTime d2 = DateTime.Parse(temp_str);
                        temp.record_DataTime(d1, d2);


                        list_campers.Add(temp);
                        log_info?.Invoke($"Данные постоялца перенесены из файла в приложеие, добавлен\n : {temp}");
                    }
                    else
                    {
                        log_info?.Invoke($"Попытка пердать в прогрмму клона постоялца из файла");
                        /*Кастыль, так как не могу прикратить лишнее чтение.. или могу с помощью делегата*/
                        temp_str = sr.ReadLine();                       
                        temp_str = sr.ReadLine();
                    }
                }
            }
        }
    }
    
    public class camper
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
                temp += "Заказал:";
                if (if_futon) temp += " Дополнительный футон;";
                if (if_food) temp += " Еду в номер;";
                temp += "\n";
            }
            temp += $"Дата заселения: {data_input.ToShortDateString()} - Дата выселения {data_output.ToShortDateString()}\n";
            temp += $"Номер будит занят еще {(data_output - DateTime.Now).Days} дней.";
            return temp;
        }
        /*Запись данных в структуру*/
        public void record_FIO_T(string n, string f, string nfather, string tel)
        {
            name = n; famile = f; name_father = nfather; telefon = tel;
        }
        public void record_room(int n, bool futon, bool food)
        {
            number_room = n; if_futon = futon; if_food = food;
        }
        public void record_DataTime(DateTime begin, DateTime end)
        {
            data_input = begin; data_output = end;
        }
        public bool if_nuber_it(int num)
        {
            /*Проверка живет ли кто-то в этой комнате, 
             потом можно улучшить живет ли кто в комнате на эту дату*/

            return number_room == num;
        }
        public string file_save()
        {
            string temp = $"{name}:{famile}:{name_father}:{telefon}\n";
            temp += $"{number_room}:{if_futon}:{if_food}\n";
            temp += $"{data_input}\n";
            temp += $"{data_output}";
            return temp;

        }
    }
}

