using System.Collections.Generic;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public interface IOhMyPopsRepo
    {
        bool SaveChanges();

        IEnumerable<Pop> GetAllPops();
        IEnumerable<Pop> GetPopsByCollection(string clc);
        Pop GetPopById(int id);
        void CreatePop(Pop pop);
        void UpdatePop(Pop pop);
        void DeletePop(Pop pop);
    }
}