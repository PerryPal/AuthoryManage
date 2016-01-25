using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Models {
    #region 返回结果状态枚举 OperateStateType
    /// <summary>
    /// 返回结果状态枚举
    /// </summary>
    public enum OperateStateType {
        /// <summary>
        ///     操作成功
        /// </summary>
        [Description("操作成功。")]
        Success,
        /// <summary>
        ///     参数错误
        /// </summary>
        [Description("参数错误。")]
        ParamError,
        /// <summary>
        ///     指定参数的数据不存在
        /// </summary>
        [Description("指定参数的数据不存在。")]
        QueryNull,
        /// <summary>
        ///     操作引发异常错误
        /// </summary>
        [Description("操作引发异常错误。")]
        Error,
        /// <summary>
        /// 失败
        /// </summary>
        [Description("失败")]
        Fail
    }
    #endregion
    #region 用户类型枚举类 UserType
    /// <summary>
    /// 用户类型枚举类
    /// </summary>
    public enum UserType {
        员工 = 1,
        其他 = 2
    }
    #endregion
    #region 用户登陆来源 LoginSource
    /// <summary>
    /// 用户登陆来源
    /// </summary>
    public enum LoginSource {
        后台=1,
        APP=2,
        其他=3
    }
    #endregion
}
