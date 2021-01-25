using System.Collections.Generic;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public interface IOhMyPopsRepo
    {
        IEnumerable<Pop> GetAllPops();
        Pop GetPopById(int id);
    }
}