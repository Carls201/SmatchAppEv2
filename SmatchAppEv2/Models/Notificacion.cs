using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class Notificacion
{
    public int IdNotificacion { get; set; }

    public int IdUsuarioEmisor { get; set; }

    public int IdUsuarioReceptor { get; set; }

    public string Mensaje { get; set; } = null!;

    public bool Confirmacion { get; set; }

    public virtual Usuario IdUsuarioEmisorNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioReceptorNavigation { get; set; } = null!;
}
