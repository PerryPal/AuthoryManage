using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.InterfaceService {
    public interface IEmpService {
        /// <summary>
        /// 查询
        /// </summary>
        IQueryable<Models.Emp> LoadEntities();
    }
}
