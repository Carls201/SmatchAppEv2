using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class Sala
{
    public int IdSala { get; set; }

    public int CantidadUsuarios { get; set; }

    public bool Estado { get; set; }

    public int IdSesion { get; set; }

    public int IdUsuario { get; set; }

    public virtual ICollection<Chat> Chats { get; set; } = new List<Chat>();

    public virtual ICollection<ConfirmarUsuario> ConfirmarUsuarios { get; set; } = new List<ConfirmarUsuario>();

    public virtual CrearSesion IdSesionNavigation { get; set; } = null!;

    public virtual Usuario IdUsuarioNavigation { get; set; } = null!;
}
