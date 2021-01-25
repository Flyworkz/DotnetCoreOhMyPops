using System.Collections.Generic;
using System.Linq;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public class SqlOhMyPopsRepo : IOhMyPopsRepo
    {
        private readonly OhMyPopsContext _context;

        public SqlOhMyPopsRepo(OhMyPopsContext context)
        {
            _context = context;
        }

        public IEnumerable<Pop> GetAllPops()
        {
            return _context.Pops.ToList();
        }

        public Pop GetPopById(int id)
        {
            return _context.Pops.FirstOrDefault(pop => pop.Id == id);
        }

    }
}