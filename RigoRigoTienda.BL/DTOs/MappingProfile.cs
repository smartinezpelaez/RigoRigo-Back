using AutoMapper;

namespace RigoRigoTienda.BL.DTOs
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            // Configuración de mapeo entre entidades y DTOs

            // Mapeo de Producto a ProductoDTO
            CreateMap<Productos, ProductoDTO>()
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
                .ForMember(dest => dest.Nombre, opt => opt.MapFrom(src => src.Nombre))
                .ForMember(dest => dest.Precio, opt => opt.MapFrom(src => src.Precio))
                .ForMember(dest => dest.Stock, opt => opt.MapFrom(src => src.Stock));

            // Mapeo de Pedido a PedidoDTO
            CreateMap<Pedidos, PedidoDTO>()
                .ForMember(dest => dest.PedidoId, opt => opt.MapFrom(src => src.PedidoId))
                .ForMember(dest => dest.CedulaCliente, opt => opt.MapFrom(src => src.CedulaCliente))
                .ForMember(dest => dest.DireccionEntrega, opt => opt.MapFrom(src => src.DireccionEntrega))
                .ForMember(dest => dest.Fecha, opt => opt.MapFrom(src => src.Fecha))
                .ForMember(dest => dest.DetallePedido, opt => opt.MapFrom(src => src.DetallePedido));

            // Mapeo de DetallePedido a DetallePedidoDTO
            CreateMap<DetallePedido, DetallePedidoDTO>()
                .ForMember(dest => dest.DetallePedidoId, opt => opt.MapFrom(src => src.DetallePedidoId))
                .ForMember(dest => dest.ProductoId, opt => opt.MapFrom(src => src.ProductoId))
                .ForMember(dest => dest.Cantidad, opt => opt.MapFrom(src => src.Cantidad))
                .ForMember(dest => dest.Subtotal, opt => opt.MapFrom(src => src.Subtotal));
        }
    }
}
