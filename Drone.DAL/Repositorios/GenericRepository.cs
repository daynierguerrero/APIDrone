using Drone.DAL.DbContex;
using Drone.DAL.Repositorios.Contrato;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Drone.DAL.Repositorios
{
    public class GenericRepository<TModelo> : IGenericRepository<TModelo> where TModelo : class
    {
        private readonly DbDroneContext _dbContext;

        public GenericRepository(DbDroneContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IQueryable<TModelo>> Consultar(Expression<Func<TModelo, bool>> predicate = null)
        {
            try
            {
                IQueryable<TModelo> query = predicate == null ? _dbContext.Set<TModelo>() : _dbContext.Set<TModelo>().Where(predicate);
                return query;

            }
            catch
            {

                throw;
            }
        }

        public async Task<TModelo> Crear(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Add(modelo);
                await _dbContext.SaveChangesAsync();
                return modelo;
            }
            catch
            {

                throw;
            }
        }

        public async Task<bool> Editar(TModelo modelo)
        {
            try
            {
                _dbContext.Set<TModelo>().Update(modelo);
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {

                throw;
            }
        }

        public async Task<TModelo> Obtener(Expression<Func<TModelo, bool>> predicate)
        {
            try
            {
                TModelo modelo = await _dbContext.Set<TModelo>().FirstOrDefaultAsync(predicate);
                return modelo;
            }
            catch
            {

                throw;
            }
        }
    }
}
