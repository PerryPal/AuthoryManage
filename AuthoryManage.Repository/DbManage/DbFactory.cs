using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Text;

namespace AuthoryManage.Repository.DbManage {
    public class DbFactory : SelfDisposable, InterfaceRepository.IDbFactory {
        private DbContext currentContext;
        public DbContext GetDbContext() {
            return currentContext ?? (currentContext = new AuthoryManageContext());
        }
        protected override void DisposeCore() {
            if (currentContext != null)
                currentContext.Dispose();
        }
    }
}
