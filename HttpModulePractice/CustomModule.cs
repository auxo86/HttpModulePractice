using System;
using System.Web;

namespace HttpModulePractice
{
    public class CustomModule : IHttpModule
    {
        /// <summary>
        /// 您將需要在您 Web 的 Web.config 檔中設定此模組，
        /// 並且向 IIS 註冊該處理程式，才能使用它。如需詳細資訊，
        /// 參閱下列連結: https://go.microsoft.com/?linkid=8101007
        /// </summary>
        #region IHttpModule Members

        public void Dispose()
        {
            //清理程式碼在這裡。
        }

        public void Init(HttpApplication app)
        {
            app.BeginRequest += (s, e) => {
                string url =
                app.Context.Request.QueryString["url"];
                if (url != null)
                {
                    app.Context.Response.Redirect(url);
                }
            };

        }

        #endregion

        public void OnLogRequest(Object source, EventArgs e)
        {
            //自動記錄邏輯在這裡
        }
    }
}
