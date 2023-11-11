using System;
using System.Collections.Generic;
using System.Text;

namespace FightManager.DTOs
{
    /*
        Класс неполный
     
        > Не хватает конструктора, принимающего класс модели
     */
    public class SettingDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public SettingDTO() { }
        public SettingDTO(int id, string title)
        {
            Id = id;
            Title = title;
        }
    }
}
