using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class Lugar
{
    public int IdLugar { get; set; }

    public string NombreLugar { get; set; } = null!;

    public string Direccion { get; set; } = null!;

    public string? Descripcion { get; set; }

    public virtual ICollection<CrearSesion> CrearSesions { get; set; } = new List<CrearSesion>();
}
