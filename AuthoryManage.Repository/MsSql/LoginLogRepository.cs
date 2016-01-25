using AuthoryManage.InterfaceRepository;
using AuthoryManage.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AuthoryManage.Repository.MsSql {
    public class LoginLogRepository : BaseRepository<LoginLog>, ILoginLogRepository {
        public LoginLogRepository(IDbFactory dbFactory) : base(dbFactory) { }
    }
}
