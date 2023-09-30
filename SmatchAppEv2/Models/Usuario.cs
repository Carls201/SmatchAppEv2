using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class Usuario
{
    public int IdUsuario { get; set; }

    public string Nombre { get; set; } = null!;

    public DateTime FechaNac { get; set; }

    public int Altura { get; set; }

    public int Peso { get; set; }

    public string Sexo { get; set; } = null!;

    public string Correo { get; set; } = null!;

    public string Pass { get; set; } = null!;

    public virtual ICollection<ConfirmarUsuario> ConfirmarUsuarios { get; set; } = new List<ConfirmarUsuario>();

    public virtual ICollection<CrearSesion> CrearSesions { get; set; } = new List<CrearSesion>();

    public virtual ICollection<Notificacion> NotificacionIdUsuarioEmisorNavigations { get; set; } = new List<Notificacion>();

    public virtual ICollection<Notificacion> NotificacionIdUsuarioReceptorNavigations { get; set; } = new List<Notificacion>();

    public virtual ICollection<Sala> Salas { get; set; } = new List<Sala>();
}
