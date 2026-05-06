using Microsoft.EntityFrameworkCore;
using ReabastecimientoPanaderia.DB.Data;
using ReabastecimientoPanaderia.DB.Data.Entities;
using ReabastecimientoPanaderia.Repositorio.Repositorio;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Repositorio.ProductoRepositorio
{
    public class ProductoRepositorio : Repositorio<Producto>, IProductoRepositorio
    {
        private readonly Context _context;

        public ProductoRepositorio(Context context) : base(context)
        {
            this._context = context;
        }
        public async Task<List<Producto>> Get()
        {
            return await _context.Productos
                .Include(p => p.TipoProducto)
                .Include(p => p.EsComun)
                .ToListAsync();
        }
        public async Task<Producto?> GetById(int id)
        {
            return await _context.Productos
                .Include(p => p.TipoProducto)
                .Include(p => p.EsComun)
                .FirstOrDefaultAsync(p => p.ID == id);
        }
    }
}
