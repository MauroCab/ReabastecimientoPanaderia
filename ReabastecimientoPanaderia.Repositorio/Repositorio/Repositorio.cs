using ReabastecimientoPanaderia.DB.Data;
using System;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace ReabastecimientoPanaderia.Repositorio.Repositorio
{
    public class Repositorio<Entidad> : IRepositorio<Entidad> where Entidad : class, IEntityBase
    {
        private readonly Context _context;

        public Repositorio(Context context)
        {
            this._context = context;
        }
        public async Task<List<Entidad>> Select()
        {
            return await _context.Set<Entidad>().ToListAsync();
        }

        public async Task<Entidad> SelectById(int id)
        {
            Entidad? entidadSeleccionada = await _context.Set<Entidad>()
                .AsNoTracking()
                .FirstOrDefaultAsync(
                e => e.ID == id);
            return entidadSeleccionada;
        }

        /// <summary>
        /// Verifica si en la base de datos existe una entidad con ID proporcionado
        /// </summary>
        /// <param name="id"> ID con el que se busca un ID coincidente en la base de datos</param>
        /// <returns>True si existe una entidad con el ID proporcionado, de lo contrario False</returns>
        public async Task<bool> Existe(int id)
        {
            bool entidadExiste = await _context.Set<Entidad>().AnyAsync(e => e.ID == id);
            return entidadExiste;
        }

        public async Task<int> Insert(Entidad entidad)
        {
            try
            {
                await _context.Set<Entidad>().AddAsync(entidad);
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
            var entidadSeleccionada = await SelectById(id);

            if (entidadSeleccionada == null)
            {
                return false;
            }

            _context.Set<Entidad>().Remove(entidadSeleccionada);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
