using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Drone.Model;

public partial class Medicamento
{
    public int IdMedicamento { get; set; }

    [RegularExpression("^[a-zA-Z0-9_.-]*$",
         ErrorMessage = "Nombre incorrecto")]
    public string Nombre { get; set; }

    public int Peso { get; set; }
    [RegularExpression("^[A-Z0-9]{3}(?:List)?$",
         ErrorMessage = "Codigo incorrecto")]
    public string Codigo { get; set; }

    public byte[]? Imagen { get; set; }

    public int? IdDrone { get; set; }

    public virtual Dron? IdDroneNavigation { get; set; }
}
