using System.Collections.Generic;
using OhMyPops.Models;

namespace OhMyPops.Data
{
    public class MockOhMyPopsRepo : IOhMyPopsRepo
    {
        public IEnumerable<Pop> GetAppPops()
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
    }
}