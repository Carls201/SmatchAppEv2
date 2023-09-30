using System;
using System.Collections.Generic;

namespace SmatchAppEv2.Models;

public partial class Chat
{
    public int IdChat { get; set; }

    public string? Mensaje { get; set; }

    public int IdSala { get; set; }

    public virtual Sala IdSalaNavigation { get; set; } = null!;
}
