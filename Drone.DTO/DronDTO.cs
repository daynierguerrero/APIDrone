using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.DTO
{
    public class DronDTO
    {
        public int IdDrone { get; set; }

        public string? NumerSerie { get; set; }

        public int? IdModelo { get; set; }

        public int PesoLimite { get; set; }

        public int? CapacidadBateria { get; set; }

        public int? IdEstado { get; set; }

    }
}
