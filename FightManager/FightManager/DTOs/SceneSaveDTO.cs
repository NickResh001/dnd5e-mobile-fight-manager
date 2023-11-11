using System;
using System.Collections.Generic;
using System.Text;

namespace FightManager.DTOs
{
    /*
        Класс неполный
     
        > Не хватает конструктора, принимающего класс модели
        > Заглушка на месте CurrentBeast
     */
    public class SceneSaveDTO
    {
        public int Id { get; set; }
        public DateTime CreationDate { get; set; }
        public string Title { get; set; }
        public SceneDTO Scene { get; set; }
        public int CurrentBeastFK { get; set; }
        
        public SceneSaveDTO() { }
        public SceneSaveDTO(int id, DateTime creationDate, string title, SceneDTO scene, int currentBeastFK)
        {
            Id = id;
            CreationDate = creationDate;
            Title = title;
            Scene = scene;
            CurrentBeastFK = currentBeastFK;
        }
    }
}
