using Drone.DTO;
using Drone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.BLL.Servicios.Contrato
{
    public interface IDronService
    {
        Task<DronDTO> RegistrarDron(DronDTO dron);
        Task<bool> CargarDron(int idMedicamento, int idDron);
        Task<List<DronDTO>> ObtenerDronesDisponibles();
        Task<int> BateriaDeUnDron(int idDron );
        Task<int> PesoMedicamentoDron(int idDron);


    }
}
