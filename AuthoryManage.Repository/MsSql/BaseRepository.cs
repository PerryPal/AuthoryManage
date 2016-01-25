using AuthoryManage.InterfaceRepository;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Data.Entity.Validation;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Repository.MsSql {
    public class BaseRepository<T> : IBaseRepository<T> where T : class,new() {
        private DbContext _currentontext;
        private readonly IDbSet<T> dbset;
        protected BaseRepository(IDbFactory dbFactory) {
            this.DatabaseFactory = dbFactory;
            dbset = CurrentContext.Set<T>();
        }
        protected IDbFactory DatabaseFactory {
            get;
            private set;
        }
        protected DbContext CurrentContext {
            get { return _currentontext ?? (_currentontext = DatabaseFactory.GetDbContext()); }
        }
        #region 添加一条记录 +T AddEntity(T entity, bool isSave = false)
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave">是否提交保存</param>
        /// <returns></returns>
        public T AddEntity(T entity, bool isSave = false) {
            try {
                _currentontext.Entry<T>(entity).State = EntityState.Added;
                if (isSave) {
                    _currentontext.SaveChanges();
                }
                return entity;
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                var fail = new Exception(msg, dbEx);
                Tools.LogHelper.WriteLogFile(fail);
                return null;
            }
        }
        #endregion
        #region 修改一条记录 +bool EditEntity(T entity, string[] property, bool isSave=false)
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property">需要修改的字段名称</param>
        /// <param name="isSave">是否提交保存</param>
        /// <returns></returns>
        public bool EditEntity(T entity, string[] property, bool isSave = false) {
            try {
                DbEntityEntry<T> entry = _currentontext.Entry<T>(entity);
                entry.State = EntityState.Unchanged;
                //    Context.Configuration.AutoDetectChangesEnabled = false;
                foreach (var item in property) {
                    entry.Property(item).IsModified = true;
                }
                return isSave ? _currentontext.SaveChanges() > 0 : true;
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                var fail = new Exception(msg, dbEx);
                Tools.LogHelper.WriteLogFile(fail);
                return false;
            }
        }
        #endregion
        #region 删除一条记录 +bool DeleteEntity(T entity, bool isSave=false)
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="isSave">是否提交保存</param>
        /// <returns></returns>
        public bool DeleteEntity(T entity, bool isSave = false) {
            try {
                DbEntityEntry<T> entry = _currentontext.Entry<T>(entity);
                entry.State = EntityState.Deleted;
                return isSave ? _currentontext.SaveChanges() > 0 : true;
            }
            catch (DbEntityValidationException dbEx) {
                var msg = string.Empty;
                foreach (var validationErrors in dbEx.EntityValidationErrors)
                    foreach (var validationError in validationErrors.ValidationErrors)
                        msg += Environment.NewLine + string.Format("Property: {0} Error: {1}", validationError.PropertyName, validationError.ErrorMessage);
                var fail = new Exception(msg, dbEx);
                Tools.LogHelper.WriteLogFile(fail);
                return false;
            }
        }
        #endregion
        #region 查询列表 +IQueryable<T> LoadEntities()
        /// <summary>
        /// 查询列表
        /// </summary>
        /// <returns></returns>
        public IQueryable<T> LoadEntities() {
            return _currentontext.Set<T>();
        }
        #endregion
        #region  条件查询 +IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda)
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="whereLamda">查询条件</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda) {
            return _currentontext.Set<T>().Where<T>(whereLamda);
        }
        #endregion
        #region 分页查询 
        /// <summary>
        /// 分页查询
        /// </summary>
        /// <typeparam name="S">排序类型</typeparam>
        /// <param name="whereLamda">查询条件</param>
        /// <param name="orderLamda">排序条件</param>
        /// <param name="isDesc">是否倒序</param>
        /// <param name="pageIndex">起始数字</param>
        /// <param name="pageSize">页长</param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLamda, Expression<Func<T, S>> orderLamda, bool isDesc, int startNum, int pageSize, out int rowCount) {
            var temp = whereLamda == null ? _currentontext.Set<T>() : _currentontext.Set<T>().Where<T>(whereLamda);
            rowCount = temp.Count();
            if (isDesc)
                temp = temp.OrderByDescending<T, S>(orderLamda).Skip<T>(startNum).Take<T>(pageSize);
            else
                temp = temp.OrderBy<T, S>(orderLamda).Skip<T>(startNum).Take<T>(pageSize);
            return temp;
        }
        #endregion
        #region 用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        /// <summary>
        /// 用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Boolean DetachEntity(Expression<Func<T, bool>> where) {
            return RemoveHoldingEntityInContext(_currentontext.Set<T>().Where(where).AsNoTracking().FirstOrDefault<T>());
        }
        //用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        private Boolean RemoveHoldingEntityInContext(T entity) {
            var objContext = ((IObjectContextAdapter)_currentontext).ObjectContext;
            var objSet = objContext.CreateObjectSet<T>();
            var entityKey = objContext.CreateEntityKey(objSet.EntitySet.Name, entity);

            Object foundEntity;
            var exists = objContext.TryGetObjectByKey(entityKey, out foundEntity);
            if (exists) {
                objContext.Detach(foundEntity);
            }
            return (exists);
        }
        #endregion
    }
}
