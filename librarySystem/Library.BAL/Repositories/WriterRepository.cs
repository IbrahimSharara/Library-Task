using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Repositories
{
    public class WriterRepository : GeneralRepository<TblWriter>, IWriterRepository
    {
        public WriterRepository(librarySystemContext dB) : base(dB)
        {
        }

        public List<TblWriter> GetWriterByName(string name)
        {
            return DB.TblWriter.Where(x => x.WriterName == name).ToList();
        }
    }
}
