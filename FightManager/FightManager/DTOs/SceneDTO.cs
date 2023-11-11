using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Essentials;

namespace FightManager.DTOs
{
    /*
        Класс неполный
     
        > Не хватает конструктора, принимающего класс модели
     */

    public class SceneDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public SettingDTO Setting { get; set; }

        public SceneDTO() { }
        public SceneDTO(int id, string title, SettingDTO setting)
        {
            Id = id;
            Title = title;
            Setting = setting;
        }
    }
}
