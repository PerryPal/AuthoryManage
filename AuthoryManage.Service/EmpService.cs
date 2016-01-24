using AuthoryManage.InterfaceRepository;
using AuthoryManage.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Service {
    public class EmpService : IEmpService {
        private IEmpRepository _empRepository;
        public EmpService(IEmpRepository empRepository) {
            this._empRepository = empRepository;
        }
        public IQueryable<Models.Emp> LoadEntities() {
            return _empRepository.LoadEntities();
        }
    }
}
