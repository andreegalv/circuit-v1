using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WEBComputadora.DAL.Interfaces;
using WEBComputadora.Model.ComputadorasMemorias;

namespace WEBComputadora.DAL.Repositories
{
    public class ComputadoraMemoriaRepository : BaseRepository<ComputadoraMemoria>
    {
        public ComputadoraMemoriaRepository(IDbContext context)
            : base(context) { }
        public override IList<ComputadoraMemoria> GetAll()
        {
            return Context.ComputadorasMemorias;
        }   
        public ComputadoraMemoria GetById(int computadoraId, int computadoraMemoriaId)
        {
            return Context.ComputadorasMemorias
                .Find(cm => cm.ComputadoraId == computadoraId && cm.ComputadoraMemoriaId == computadoraMemoriaId);
        }
        public IList<ComputadoraMemoria> GetAllTakeAndSkip(int take, int skip)
        {
            return Context.ComputadorasMemorias.Take(take).Skip(skip).ToList();
        }
        public IList<ComputadoraMemoria> GetAllAndTake(int take)
        {
            return Context.ComputadorasMemorias.Take(take).ToList();
        }
        public IList<ComputadoraMemoria> Where(Func<ComputadoraMemoria, bool> predicate)
        {
            return Context.ComputadorasMemorias.Where(predicate).ToList();
        }
    }
}