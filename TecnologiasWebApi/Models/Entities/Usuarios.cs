using System;
using System.Collections.Generic;

namespace TecnologiasWebApi.Models.Entities;

public partial class Usuarios
{
    public int Id { get; set; }

    public string Correo { get; set; } = null!;

    public string Password { get; set; } = null!;
}
