using TecnologiasWebApi.Models.Entities;

namespace TecnologiasWebApi.Repositorios
{
    public class ChismesRepositorio
    {
        private readonly ChismografoContext _context;
        public ChismesRepositorio(ChismografoContext context)
        {
            _context = context;
        }
        public List<Chisme> GetChismes()
        {
            return _context.Chisme.ToList();
        }
        
        public Chisme? GetChismeById(int Id)
        {
            return _context.Chisme.FirstOrDefault(x => x.Id == Id);
        }
        public bool EliminarChismeById(int Id,int IdUsuario)
        {
            try {
                if(Id != 0)
                {
                    Chisme? Chisme = _context.Chisme.FirstOrDefault(x => x.Id == Id && x.IdUsuario == IdUsuario);
                    if(Chisme!= null)
                    {
                        _context.Chisme.Remove(Chisme);
                        _context.SaveChanges();
                        return true;
                    }
                    else
                    {
                        return false;
                    }
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
        public bool GuardarChisme(Chisme Chisme)
        {
            try
            {
                if(Chisme.Titulo != null && Chisme.Descripcion != null)
                {
                    _context.Chisme.Add(Chisme);
                    _context.SaveChanges();
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
        public bool EditarChisme(Chisme ChismeNuevo,int IdUsuario)
        {
            try
            {
                Chisme? ViejoChisme = _context.Chisme.FirstOrDefault(x => x.Id == ChismeNuevo.Id && x.IdUsuario == IdUsuario);
                if(ViejoChisme != null)
                {
                    ViejoChisme.Titulo = ChismeNuevo.Titulo;
                    ViejoChisme.Descripcion = ChismeNuevo.Descripcion;
                    _context.Update(ViejoChisme);
                    _context.SaveChanges();
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
