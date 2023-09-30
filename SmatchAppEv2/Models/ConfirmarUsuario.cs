using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class ConfirmarUsuario
{
    public int IdConfirmar { get; set; }

    public int IdUsuario { get; set; }

    public int IdSala { get; set; }

    public string Estado { get; set; } = null!;

    public virtual Sala IdSalaNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
