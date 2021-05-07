using System;

namespace DIO.Series
{
    public class Serie : EntityBase
    {
        //Attributes
        public Serie(Gender gender, string title, string description, int year) 
        {
            this.Gender = gender;
                this.Title = title;
                this.Description = description;
                this.Year = year;
               
        }
                private Gender Gender {get; set;}
        private string Title {get; set;}
        private string Description {get; set;}
        private int Year {get; set;}

        //Constructor
        public Serie(int id, Gender gender, string title, string description, int year )
        {
            this.Id = id;
            this.Gender = gender;
            this.Title = title;
            this.Description = description;
            this.Year = year;
        }

        public override string ToString()
        {
            string retorno = "";
            retorno += "Gender: " + this.Gender + Environment.NewLine;
            retorno += "Title: " + this.Title + Environment.NewLine;
            retorno += "Description: " + this.Description + Environment.NewLine;
            retorno += "Start Year: " + this.Year;
            return retorno;
        }

        public string returnTitle()
        {
            return this.Title;
        }

        public int returnId()
        {
            return this.Id;
        }
    }
}