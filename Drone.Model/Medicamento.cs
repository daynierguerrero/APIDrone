using System;
using System.Collections.Generic;

namespace Drone.Model;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    public string? Nombre { get; set; }

    public int Peso { get; set; }

    public string? Codigo { get; set; }

    public byte[]? Imagen { get; set; }

    public int? IdDrone { get; set; }

    public virtual Dron? IdDroneNavigation { get; set; }
}
