using System;
using System.Collections.Generic;

namespace TecnologiasWebApi.Models.Entities;

public partial class Chisme
{
    public int Id { get; set; }

    public string Titulo { get; set; } = null!;

    public string Descripcion { get; set; } = null!;

    public int IdUsuario { get; set; }

    public virtual Chisme IdUsuarioNavigation { get; set; } = null!;

    public virtual ICollection<Chisme> InverseIdUsuarioNavigation { get; set; } = new List<Chisme>();
}
