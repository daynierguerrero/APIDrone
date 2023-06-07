using AutoMapper;
using Drone.BLL.Servicios.Contrato;
using Drone.DAL.Repositorios.Contrato;
using Drone.DTO;
using Drone.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Drone.BLL.Servicios
{
    public class DronService : IDronService
    {
        private readonly IGenericRepository<Dron> _dronRepository;
        private readonly IGenericRepository<Medicamento> _medicamentoRepository;
        private readonly IMapper _mapper;

        public DronService(IGenericRepository<Dron> dronRepository, IMapper mapper, IGenericRepository<Medicamento> medicamentoRepository)
        {
            _dronRepository = dronRepository;
            _mapper = mapper;
            _medicamentoRepository= medicamentoRepository;
        }

        public async Task<int> BateriaDeUnDron(int idDron)
        {
            try
            {
                var dron= await _dronRepository.Obtener(dron=>dron.IdDrone==idDron);
                return dron.CapacidadBateria;

            }
            catch 
            {

                throw;
            }
        }

        public async Task<bool> CargarDron(int idMedicamento, int idDron)
        {
           
            var dron = await _dronRepository.Obtener(dron => dron.IdDrone == idDron);
            var medicamento= await _medicamentoRepository.Obtener(med=> med.IdMedicamento== idMedicamento);
            if (medicamento.Peso > dron.PesoLimite)
            {
                throw new TaskCanceledException("Demasiado peso");
            }
            dron.PesoLimite= dron.PesoLimite-medicamento.Peso;
            medicamento.IdDrone= idDron;

            bool respuesta = await _dronRepository.Editar(dron);

            if (!respuesta)
            {
                throw new TaskCanceledException("No se pudo editar");
            }

            bool respuesta1 = await _medicamentoRepository.Editar(medicamento);

            if (!respuesta1)
            {
                throw new TaskCanceledException("No se pudo editar");
            }


            return true;

        }

        public async Task<List<DronDTO>> ObtenerDronesDisponibles()
        {
            try
            {
                var drones_disponbles = await _dronRepository.Consultar(dron => dron.IdEstado == 1);
                return _mapper.Map<List<DronDTO>>(drones_disponbles);
            }
            catch 
            {

                throw;
            }
            
        }

        public async Task<int> PesoMedicamentoDron(int idDron)
        {
            try
            {
                var dron = await _dronRepository.Obtener(dron => dron.IdDrone == idDron);
                var medicamentosDelDron = await _medicamentoRepository.Consultar(med => med.IdDrone == idDron);
                int peso = 0;
                foreach (var med in medicamentosDelDron.ToList())
                {
                    peso += med.Peso;
                }
                return peso;
            }
            catch
            {

                throw;
            }
        }

        public async Task<DronDTO> RegistrarDron(DronDTO dron)
        {
            try
            {
                var dron_creado = await _dronRepository.Crear(_mapper.Map<Dron>(dron));
                if (dron_creado.IdDrone == 0)
                {
                    throw new TaskCanceledException("No se pudo crear el dron");
                }

                return _mapper.Map<DronDTO>(dron_creado);
            }
            catch
            {

                throw;
            }
        }

        
    }
}
