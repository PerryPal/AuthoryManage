using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AuthoryManage.Models {
    /// <summary>
    /// 操作返回类
    /// </summary>
    [NotMapped]
    public class OperateResult {
        /// <summary>
        /// 操作返回结果状态
        /// </summary>
        public OperateStateType OperateState { get; set; }
        /// <summary>
        /// 返回信息
        /// </summary>
        public string Message { get; set; }
        /// <summary>
        /// 返回数据
        /// </summary>
        public object OData { get; set; }

        /// <summary>
        /// 操作结果状态
        /// </summary>
        /// <param name="state"></param>
        public OperateResult(OperateStateType state) {
           this.OperateState = state;
        }
        /// <summary>
        /// 操作结果状态和一些描述
        /// </summary>
        /// <param name="state">操作状态</param>
        /// <param name="message">描述</param>
        public OperateResult(OperateStateType state, string message)
            : this(state) {
                this.Message = message;
        }
        /// <summary>
        /// 操作结果状态、一些描述、数据
        /// </summary>
        /// <param name="state">操作状态</param>
        /// <param name="message">描述</param>
        /// <param name="oData">数据</param>
        public OperateResult(OperateStateType state, string message, object oData)
            : this(state, message) {
                this.OData = oData;
        }
        /// <summary>
        /// 操作结果状态、数据
        /// </summary>
        /// <param name="state">操作状态</param>
        /// <param name="oData">数据</param>
        public OperateResult(OperateStateType state, object oData)
            : this(state) {
                this.OData = oData;
        }
    }
}
