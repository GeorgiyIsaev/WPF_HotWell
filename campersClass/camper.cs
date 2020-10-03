﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace campersClass
{
    public static class campers
    {
        static public int? current_room; /*Сюда буду записывать тикущую выбранную комнату*/
        /*int?  что бы инту можно было присвоит null*/

        //? вынести колекция в стаитчный класс и сделать глобальной переменной
        static public List<camper> list_campers = new List<camper>();
        static public bool find_nuber_room(int num)
        { /*Поиск по комнте*/
            foreach (camper tmp in campers.list_campers)
                if (tmp.if_nuber_it(num)) return true; /*Здесь кто-то живет*/
            return false;
        }
        static public string find_nuber_room_STR(int num)
        { /*Поиск по комнте - все также только возвращаем строку*/
            foreach (camper tmp in campers.list_campers)
                if (tmp.if_nuber_it(num)) return tmp.ToString(); /*Здесь кто-то живет*/
            return "Ни чего не найдено";
        }
        static public void save()
        {
            using (var file = new StreamWriter("info.log"))
            {
                foreach (camper tmp in campers.list_campers)
                    file.WriteLine(tmp.file_save());
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
                if (if_futon) temp += " Допольнительный футон;";
                if (if_food) temp += " Еду в номер;";
                temp += "\n";
            }
            temp += $"Дата засиления: {data_input}, выселения {data_output}\n";
            temp += $"Номер будит занят еще {(data_output - data_input).Days} дней.";
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
            /*Проверка живет ли кто то в этой комнате, 
             потом можно улчшить живет ли кто в комнате на эту дату*/

            return number_room == num;
        }
        public string file_save()
        {
            string temp = $"{name}: { famile}: {name_father}\n";
            temp += $"{number_room}: {telefon}\n";
            temp += $"{if_futon}: {if_food}\n";
            temp += $"{data_input}\n";
            temp += $"{data_output}\n";
            return temp;  
              
        }       
    }
}