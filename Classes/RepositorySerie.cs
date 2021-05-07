using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;

namespace DIO.Series
{
    public class RepositorySerie : IRepository<Serie>
    {
        private List<Serie> listSerie = new List<Serie>();
        public void Exclude(int id)
        {
            throw new NotImplementedException();
        }

        public void Insert(Serie entity)
        {
            throw new NotImplementedException();
        }

        public List<Serie> List()
        {
            throw new NotImplementedException();
        }

        public int NextId()
        {
            throw new NotImplementedException();
        }

        public Serie ReturnById(int id)
        {
            throw new NotImplementedException();
        }

        public void Update(int id, Serie entity)
        {
            listSerie[id] = entity;
        }
    }
}