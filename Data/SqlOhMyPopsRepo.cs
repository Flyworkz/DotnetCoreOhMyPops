using System;
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

        public void CreatePop(Pop pop)
        {
            if (pop == null)
            {   
                throw new ArgumentNullException(nameof(pop));
            }

            _context.Pops.Add(pop);
        }

        public IEnumerable<Pop> GetAllPops()
        {
            return _context.Pops.ToList();
        }

        public Pop GetPopById(int id)
        {
            return _context.Pops.FirstOrDefault(pop => pop.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdatePop(Pop pop)
        {
            // Do nothing
        }
    }
}