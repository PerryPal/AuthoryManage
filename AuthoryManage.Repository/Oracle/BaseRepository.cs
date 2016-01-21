using AuthoryManage.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Repository.Oracle {
    public class BaseRepository : IBaseRepository {
        public string GetData() {
            return "这里是Oracle";
        }
    }
}
