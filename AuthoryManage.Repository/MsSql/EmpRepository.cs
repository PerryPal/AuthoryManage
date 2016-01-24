using AuthoryManage.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Repository.MsSql {
    public class EmpRepository : BaseRepository<Models.Emp>, IEmpRepository {
        public EmpRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
