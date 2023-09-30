using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class Deporte
{
    public int IdDeporte { get; set; }

    public string NombreDeporte { get; set; } = null!;

    public virtual ICollection<CrearSesion> CrearSesions { get; set; } = new List<CrearSesion>();
}
