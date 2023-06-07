using System;
using System.Collections.Generic;

namespace Drone.Model;

public partial class Modelo
{
    public int IdModelo { get; set; }

    public string? Descripcion { get; set; }

    public virtual ICollection<Dron> Drones { get; set; } = new List<Dron>();
}
