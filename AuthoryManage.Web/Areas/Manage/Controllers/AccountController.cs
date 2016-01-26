using AuthoryManage.InterfaceService;
using AuthoryManage.Models;
using AuthoryManage.Tools;
using AuthoryManage.Web.Areas.Manage.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AuthoryManage.Web.Areas.Manage.Controllers {
    public class AccountController : Controller {
        //
        // GET: /Manage/Account/
        private readonly IEmpService _empService;
        public AccountController(IEmpService empService) {
            this._empService = empService;
        }
        public ActionResult Login() {
            LoginModel model = new LoginModel();
            return View(model);
        }
        [HttpPost]
        public JsonResult Login(Models.LoginModel model) {
            if (ModelState.IsValid) {
                //首先判断下验证码是否正确
                if (Session["ValidateImgCode"] != null && string.Equals(Session["ValidateImgCode"].ToString(),
                    model.ValidateCode, StringComparison.OrdinalIgnoreCase)) {
                    OperateResult operateResult = _empService.Login(model.UserName, model.Password, (byte)LoginSource.后台);
                    if (operateResult.OperateState == OperateStateType.Success) {
                        SessionHelper.SetSession("EmpInfo", operateResult.OData);
                        return Json(new { state = "success", message = operateResult.Message });
                    }
                    else {
                        return Json(new { state = "error", message = operateResult.Message });
                    }
                }
                else {
                    return Json(new {
                        state = "error",
                        message = "验证码错误"
                    });
                }
            }
            else {
                return Json(new {
                    state = "error",
                    message = "输入信息不完整"
                });
            }
        }
        #region 验证码
        /// <summary>
        /// 功能：返回验证码图片
        /// </summary>
        /// <returns></returns>
        public ActionResult ValidateImg() {
            Color color1 = new Color();
            //---------产生随机6位字符串
            Random ran = new Random();
            char[] c = new char[62];
            char[] ou = new char[6];
            int n = 0;
            for (int i = 65; i < 91; i++) {
                c[n] = (char)i;
                n++;
            }
            for (int j = 97; j < 123; j++) {
                c[n] = (char)j;
                n++;
            }
            for (int k = 48; k < 58; k++) {
                c[n] = (char)k;
                n++;
            }
            foreach (char ch in c) {
                Console.WriteLine(ch);
            }
            string outcode = "";
            for (int h = 0; h < 6; h++) {
                ou[h] = c[ran.Next(62)];
                outcode += ou[h].ToString();
            }
            //
            Session["ValidateImgCode"] = outcode;

            //1.创建一个新的图片，大小为(输入的字符串的长度*12),22
            System.Drawing.Bitmap bmap = new System.Drawing.Bitmap(outcode.Length * 18, 25);

            //2.定义画图面板，基于创建的新图片来创建
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bmap);

            //3.由于默认的画图面板背景是黑色，所有使用clear方法把背景清除，同时把背景颜色设置为白色
            g.Clear(System.Drawing.Color.White);

            // 画图片的背景噪音线
            for (int i = 0; i < 25; i++) {
                int x1 = ran.Next(bmap.Width);
                int x2 = ran.Next(bmap.Width);
                int y1 = ran.Next(bmap.Height);
                int y2 = ran.Next(bmap.Height);
                g.DrawLine(new Pen(color1), x1, y1, x2, y2);
            }

            // 画图片的前景噪音线
            for (int i = 0; i < 100; i++) {
                int x = ran.Next(bmap.Width);
                int y = ran.Next(bmap.Height);
                bmap.SetPixel(x, y, Color.FromArgb(ran.Next()));
            }

            //4.使用DrawString 方法把要输出的字符串输出到画板上。输出的字符从参数(outcode)内获得。
            Font font = new Font("Arial", 14, FontStyle.Bold | FontStyle.Italic);
            LinearGradientBrush brush = new LinearGradientBrush(new Rectangle(0, 0, bmap.Width, bmap.Height), Color.Blue, Color.DarkRed, 1.2f, true);
            g.DrawString(outcode, font, brush, 0, 0);

            //5.定义一个内存流，把新创建的图片保存到内存流内，这样就不用保存到磁盘上，提高了速度。
            System.IO.MemoryStream ms = new System.IO.MemoryStream();

            //6.把新创建的图片保存到内存流中，格式为jpeg的类型
            bmap.Save(ms, System.Drawing.Imaging.ImageFormat.Jpeg);

            //7.输出这张图片，由于此页面的 ContentType="image/jpeg" 所以会输出图片到客户端。同时输出是以字节输出，所以要把内存流转换为字节序列，使用ToArray()方法。
            Response.BinaryWrite(ms.ToArray());
            return PartialView();
        }
        #endregion
    }
}
