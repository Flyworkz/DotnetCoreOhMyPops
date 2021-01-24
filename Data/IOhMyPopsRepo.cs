using System.Collections.Generic;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public interface IOhMyPopsRepo
    {
        IEnumerable<Pop> GetAppPops();
        Pop GetPopById(int id);
    }
}