﻿using Libirary.DAL.Models;
using Library.BLL.InterFaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.BLL.Repositories
{
    public class GeneralRepository<T> : IGeneralRepository<T> where T : class
    {
        public librarySystemContext DB { get; set; }
        
        #region Controller
        public GeneralRepository(librarySystemContext dB)
        {
            DB = dB;
        }
        #endregion

        #region Add New Value
        public async Task<int> Add(T entity)
        {
            await DB.Set<T>().AddAsync(entity);
            return DB.SaveChanges();
        }
        #endregion

        #region Delete
        public async Task<int> Delete(int id)
        {
            var entity = await GetByID(id);
            DB.Set<T>().Remove(entity);
            return DB.SaveChanges();
        }

        #endregion

        #region Get All
        public List<T> GetAll()
        {
            return DB.Set<T>().ToList();
        }
        #endregion


        #region Find By ID
        public async Task<T> GetByID(int id)
        {
            var val = await DB.Set<T>().FindAsync(id);
            return val;
        }
        #endregion

        #region Update
        public async Task<int> Update(int id, T entity)
        {
            var old = await GetByID(id);
            DB.Set<T>().Update(old);
            return DB.SaveChanges();
        }
        #endregion


    }
}
