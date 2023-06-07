using System;
using System.Collections.Generic;

namespace Drone.Model;

public partial class Dron
{
    public int IdDrone { get; set; }

    public string? NumerSerie { get; set; }

    public int? IdModelo { get; set; }

    public int PesoLimite { get; set; }

    public int CapacidadBateria { get; set; }

    public int? IdEstado { get; set; }

    public virtual Estado? IdEstadoNavigation { get; set; }

    public virtual Modelo? IdModeloNavigation { get; set; }
}
