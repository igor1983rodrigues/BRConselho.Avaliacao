using BRConselho.Avaliacao.Model.DAO.BaseRepository;
using BRConselho.Avaliacao.Model.DAO.Entity;
using BRConselho.Avaliacao.Model.Repository.Properties;

namespace BRConselho.Avaliacao.Model.Repository.BaseDao
{
    public class BaseAvaliacaoDaoRepository<T> : BaseDaoRepository<T> where T: BaseEntity
    {
        public BaseAvaliacaoDaoRepository() : base(Resources.StrConnection)
        {
        }
    }
}
