using System;
using System.Collections.Generic;

namespace appSatTech.Models;

public partial class Chamado
{
    public int Codigo { get; set; }

    public DateTime DataHora { get; set; }

    public string StatusAtendimento { get; set; } = null!;

    public int ClienteId { get; set; }

    public int TecnicoId { get; set; }

    public virtual Cliente? Cliente { get; set; } = null!;

    public virtual Tecnico? Tecnico { get; set; } = null!;
}
