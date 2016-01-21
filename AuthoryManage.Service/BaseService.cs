using AuthoryManage.InterfaceRepository;
using AuthoryManage.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Service {
    public class BaseService:IBaseService {
        private readonly IBaseRepository _repository;
        public BaseService(IBaseRepository repository) {
            this._repository = repository;
        }
        public string GetData() {
            return _repository.GetData();
        }
    }
}
