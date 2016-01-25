using AuthoryManage.InterfaceRepository;
using AuthoryManage.InterfaceService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Service {
    public class BaseService<T> : IBaseService<T> where T : class,new() {
        private readonly IBaseRepository<T> _baseReposiotry;
        protected BaseService(IBaseRepository<T> baseReposiotry) {
            this._baseReposiotry = baseReposiotry;
        }
        #region 添加一条记录
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public T AddEntity(T entity, bool isSave = false) {
            return _baseReposiotry.AddEntity(entity, isSave: isSave);
        }
        #endregion
        #region 修改一条记录
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property">需要修改的字段名称</param>
        /// <returns></returns>
        public bool EditEntity(T entity, string[] property, bool isSave = false) {
            return _baseReposiotry.EditEntity(entity, property, isSave: isSave);
        }
        #endregion
        #region 删除一条记录
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        public bool DeleteEntity(T entity, bool isSave = false) {
            return _baseReposiotry.DeleteEntity(entity, isSave: isSave);
        }
        #endregion
        #region 查询
        /// <summary>
        /// 查询
        /// </summary>
        public IQueryable<T> LoadEntities() {
            return _baseReposiotry.LoadEntities();
        }
        #endregion
        #region 条件查询
        /// <summary>
        /// 条件查询
        /// </summary>
        /// <param name="whereLamda">查询条件</param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda) {
            return _baseReposiotry.LoadEntities(whereLamda);
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
        /// <param name="startNum">起始位置</param>
        /// <param name="pageSize">页长</param>
        /// <param name="rowCount"></param>
        /// <returns></returns>
        public IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLamda, Expression<Func<T, S>> orderLamda, bool isDesc, int startNum, int pageSize, out int rowCount) {
            return _baseReposiotry.LoadEntities(whereLamda, orderLamda, isDesc, startNum, pageSize, out rowCount);
        }
        #endregion
        #region 用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        /// <summary>
        /// 用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        public Boolean DetachEntity(Expression<Func<T, bool>> where) {
            return _baseReposiotry.DetachEntity(where);
        }
        #endregion
    }
}
