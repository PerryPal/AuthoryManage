using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.InterfaceService {
    public interface IBaseService<T> where T:class,new() {
        /// <summary>
        /// 添加一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        T AddEntity(T entity, bool isSave = false);
        /// <summary>
        /// 修改一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <param name="property">需要修改的字段名称</param>
        /// <returns></returns>
        bool EditEntity(T entity, string[] property, bool isSave = false);
        /// <summary>
        /// 删除一条记录
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        bool DeleteEntity(T entity, bool isSave = false);
        /// <summary>
        /// 查询
        /// </summary>
        IQueryable<T> LoadEntities();
        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="whereLamda">查询条件</param>
        /// <returns></returns>
        IQueryable<T> LoadEntities(Expression<Func<T, bool>> whereLamda);
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
        IQueryable<T> LoadEntities<S>(Expression<Func<T, bool>> whereLamda, Expression<Func<T, S>> orderLamda, bool isDesc, int startNum, int pageSize, out int rowCount);
        /// <summary>
        /// 用于监测Context中的Entity是否存在，如果存在，将其Detach，防止出现问题。
        /// </summary>
        /// <param name="where"></param>
        /// <returns></returns>
        Boolean DetachEntity(Expression<Func<T, bool>> where);
    }
}
