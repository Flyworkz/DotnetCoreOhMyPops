using System.Collections.Generic;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public interface IOhMyPopsRepo
    {
        bool SaveChanges();

        IEnumerable<Pop> GetAllPops();
        Pop GetPopById(int id);
        void CreatePop(Pop pop);
    }
}