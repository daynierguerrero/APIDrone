using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.DTO
{
    public class MedicamentoDTO
    {
        public int IdMedicamento { get; set; }

        public string? Nombre { get; set; }

        public int Peso { get; set; }

        public string? Codigo { get; set; }

        public byte[]? Imagen { get; set; }
    }
}
