using System.Collections.Generic;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public class MockOhMyPopsRepo : IOhMyPopsRepo
    {
        public Pop CreatePop(Pop pop)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePop(int id)
        {
            throw new System.NotImplementedException();
        }

        public void DeletePop(Pop pop)
        {
            throw new System.NotImplementedException();
        }

        public IEnumerable<Pop> GetAllPops()
        {
            var pops = new List<Pop>
            {
                new Pop {
                    Id = 0,
                    FigurineNumber = 1,
                    Collection = "The Lord of the Rings",
                    Label = "Legolas"
                },
                new Pop {
                    Id = 1,
                    FigurineNumber = 2,
                    Collection = "The Lord of the Rings",
                    Label = "Gandalf"
                },
                new Pop {
                    Id = 2,
                    FigurineNumber = 3,
                    Collection = "The Lord of the Rings",
                    Label = "Aragorn"
                }
            };

            return pops;
        }

        public Pop GetPopById(int id)
        {
            return new Pop {
                Id = 0,
                FigurineNumber = 1,
                Collection = "The Lord of the Rings",
                Label = "Legolas"
            };
        }

        public bool SaveChanges()
        {
            throw new System.NotImplementedException();
        }

        public void UpdatePop(Pop pop)
        {
            throw new System.NotImplementedException();
        }

        void IOhMyPopsRepo.CreatePop(Pop pop)
        {
            throw new System.NotImplementedException();
        }
    }
}