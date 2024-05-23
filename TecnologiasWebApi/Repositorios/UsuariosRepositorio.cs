using TecnologiasWebApi.Models.Entities;

namespace TecnologiasWebApi.Repositorios
{
    public class UsuariosRepositorio
    {
        private readonly ChismografoContext _context;
        public UsuariosRepositorio(ChismografoContext context)
        {
            _context = context;
        }
        public bool LoginUsuario(Usuarios Usuario)
        {
            try
            {
                Usuarios? User = _context.Usuarios.FirstOrDefault(x => x.Password == Usuario.Password && x.Correo == Usuario.Correo);
                if(User != null)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
        public bool RegistrarUsuario(Usuarios Usuario)
        {
            try
            {
                if(Usuario.Correo != null && Usuario.Password != null)
                {
                    Usuario.Id = 0;
                    _context.Usuarios.Add(Usuario);
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }
    }
}
