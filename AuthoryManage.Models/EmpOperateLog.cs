using System;
using System.Collections.Generic;
using System.Text;

namespace AuthoryManage.Models {
    /// <summary>
    /// 员工操作日志
    /// </summary>
    public class EmpOperateLog {
        /// <summary>
        /// 主键、自增
        /// </summary>
        public long FId { get; set; }
        /// <summary>
        /// 操作对象主键ID
        /// </summary>
        public long FKeyId { get; set; }
        /// <summary>
        /// 动作类型
        /// </summary>
        public byte FActionType { get; set; }
        /// <summary>
        /// 操作对应所属菜单ID
        /// </summary>
        public int FMenuId { get; set; }
        /// <summary>
        /// 操作标题
        /// </summary>
        public string FTitle { get; set; }
        /// <summary>
        /// 操作详情
        /// </summary>
        public string FDesc { get; set; }
        /// <summary>
        /// 操作IP
        /// </summary>
        public string FOperateIp { get; set; }
        /// <summary>
        /// 操作地址
        /// </summary>
        public string FOperateAddress { get; set; }
        /// <summary>
        /// 操作端口
        /// </summary>
        public byte FOperateSource { get; set; }
        /// <summary>
        /// 浏览器信息或者APP信息
        /// </summary>
        public string FSourceInfo { get; set; }
        /// <summary>
        /// 操作状态（1：成功，0：失败）
        /// </summary>
        public bool FState { get; set; }
        /// <summary>
        /// 操作人ID
        /// </summary>
        public long FOperateUserId { get; set; }
        /// <summary>
        /// 操作时间
        /// </summary>
        public DateTime FOperateTime { get; set; }
    }
}
