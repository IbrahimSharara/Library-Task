using Libirary.DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.InterFaces
{
    public interface IWriterRepository: IGeneralRepository<TblWriter>
    {
        List<TblWriter> GetWriterByName(string name);
    }
}
