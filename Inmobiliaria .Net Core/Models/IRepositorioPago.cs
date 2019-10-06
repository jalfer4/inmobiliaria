using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Inmobiliaria_.Net_Core.Models
{
     
    public interface IRepositorioPago : IRepositorio<Pago>
	{

        IList<Pago> BuscarPorAlquileres(int PagoId);
    }
}
