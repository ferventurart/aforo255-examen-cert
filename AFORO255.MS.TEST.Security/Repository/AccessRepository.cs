using AFORO255.MS.TEST.Security.Model;
using AFORO255.MS.TEST.Security.Repository.Data;
using System.Collections.Generic;
using System.Linq;

namespace AFORO255.MS.TEST.Security.Repository
{
    public class AccessRepository : IAccessRepository
    {
        private readonly IContextDatabase _contextDatabase;

        public AccessRepository(IContextDatabase contextDatabase)
        {
            _contextDatabase = contextDatabase;
        }

        public IEnumerable<Access> GetAll()
        {
            return _contextDatabase.Access.ToList();
        }
    }
}
