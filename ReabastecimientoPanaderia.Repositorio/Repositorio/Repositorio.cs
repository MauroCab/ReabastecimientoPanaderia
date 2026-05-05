using ReabastecimientoPanaderia.DB.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReabastecimientoPanaderia.Repositorio.Repositorio
{
    public class Repositorio<E> : IRepositorio<E> where E : class, IEntityBase
    {
        private readonly Context _context;

        public Repositorio(Context context)
        {
            this._context = context;
        }
        public async Task<List<E>> Select()
        {
            return await _context.Set<E>().ToListAsync();
        }

        public async Task<E> SelectById(int id)
        {
            E? sel = await _context.Set<E>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                x => x.ID == id);
            return sel;
        }

        public async Task<bool> Existe(int id)
        {
            bool existe = await _context.Set<E>().AnyAsync(x => x.ID == id);
            return existe;
        }

        public async Task<int> Insert(E entidad)
        {
            try
            {
                await _context.Set<E>().AddAsync(entidad);
                await _context.SaveChangesAsync();
                return entidad.ID;
            }
            catch (Exception err)
            {
                throw err;
            }
        }

        public async Task<bool> Delete(int id)
        {
            var sel = await SelectById(id);

            if (sel == null)
            {
                return false;
            }

            _context.Set<E>().Remove(sel);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
