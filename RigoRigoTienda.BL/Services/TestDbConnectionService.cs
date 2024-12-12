using RigoRigoTienda.DataAccess.Context;
using System.Threading.Tasks;
using System;
using Microsoft.EntityFrameworkCore;

public class TestDbConnectionService
{
    private readonly RigoRigoTiendaBdContext _context;

    public TestDbConnectionService(RigoRigoTiendaBdContext context)
    {
        _context = context;
    }

    public async Task<string> TestConnectionAsync()
    {
        try
        {
            
            var count = await _context.Pedidos.CountAsync();
            return $"Conexión exitosa. Se encontraron {count} pedidos.";
        }
        catch (Exception ex)
        {
            return $"Error al conectar con la base de datos: {ex.Message}";
        }
    }
}
