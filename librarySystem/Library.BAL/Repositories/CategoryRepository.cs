using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Repositories
{
    public class CategoryRepository : GeneralRepository<TblCategory>, ICategoryRepository
    {
        public CategoryRepository(librarySystemContext dB) : base(dB)
        {
        }
    }
}
