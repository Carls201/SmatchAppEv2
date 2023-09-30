using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class CrearSesion
{
    public int IdSesion { get; set; }

    public string NombreSesion { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public DateTime FechaEncuentro { get; set; }

    public int IdUsuario { get; set; }

    public int IdDeporte { get; set; }

    public int IdLugar { get; set; }

    public virtual Deporte IdDeporteNavigation { get; set; } = null!;

    public virtual Lugar IdLugarNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
}
