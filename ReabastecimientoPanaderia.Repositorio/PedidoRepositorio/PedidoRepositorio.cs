using Microsoft.EntityFrameworkCore;
using ReabastecimientoPanaderia.DB.Data;
using ReabastecimientoPanaderia.DB.Data.Entities;
using ReabastecimientoPanaderia.Repositorio.Repositorio;
using ReabastecimientoPanaderia.Shared.GetPedido_DTOs;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReabastecimientoPanaderia.Repositorio.PedidoRepositorio
{
    public class PedidoRepositorio : Repositorio<Pedido>, IPedidoRepositorio
    {
        private readonly Context _context;

        public PedidoRepositorio(Context context) : base(context)
        {
            this._context = context;
        }

        public async Task<List<GetPedidoDTO>> Get()
        {
            var pedidos = await _context.Pedidos
                                .Include(p => p.Renglones)
                                .ThenInclude(r => r.ProductoSolicitado)
                                .ToListAsync();

            return pedidos.Select(p => new GetPedidoDTO
            {
                FechaYHora = p.FechaYHora,
                Renglones = p.Renglones.Select(r => new GetRenglonDTO
                {
                    CantidadSolicitada = r.CantidadSolicitada,
                    NombreProductoSolicitado = r.ProductoSolicitado?.Nombre // Aquí se obtiene el nombre del producto
                }).ToList()
            }).ToList();
        }

        public async Task<GetPedidoDTO> GetById(int id)
        {
            var pedido = await _context.Pedidos
                            .Include(p => p.Renglones)
                            .ThenInclude(r => r.ProductoSolicitado)
                           .FirstOrDefaultAsync(p => p.ID == id);

            if (pedido == null)
            return null;

            return new GetPedidoDTO
            {
                FechaYHora = pedido.FechaYHora,
                Renglones = pedido.Renglones.Select(r => new GetRenglonDTO
                {
                    CantidadSolicitada = r.CantidadSolicitada,
                    NombreProductoSolicitado = r.ProductoSolicitado?.Nombre
                }).ToList()
            };
        }

        public async Task<Pedido> AddPedidoConRenglones(Pedido pedido, List<Renglon> renglones)
        {
            using (var transaction = await _context.Database.BeginTransactionAsync())
            {
                try
                {


                    _context.Pedidos.Add(pedido);
                    await _context.SaveChangesAsync();


                    foreach (var renglon in renglones)
                    {
                        renglon.PedidoID = pedido.ID;
                        _context.Renglones.Add(renglon);
                    }

                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();

                    return pedido;
                }
                catch (Exception)
                {
                    await transaction.RollbackAsync();
                    throw;
                }
            }

        }
    }
}
