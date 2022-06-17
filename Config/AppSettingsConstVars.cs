using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SqlSugar.Extensions;

namespace WebApplication1.Config
{
    /// <summary>
    /// 配置文件格式化
    /// </summary>
    public class AppSettingsConstVars
    {

        #region 全局地址================================================================================
        /// <summary>
        /// 系统后端地址
        /// </summary>
        public static readonly string AppConfigAppUrl = AppSettingsHelper.GetContent("AppConfig", "AppUrl");
        /// <summary>
        /// 系统接口地址
        /// </summary>
        public static readonly string AppConfigAppInterFaceUrl = AppSettingsHelper.GetContent("AppConfig", "AppInterFaceUrl");
        #endregion

        #region Jwt授权配置================================================================================

        public static readonly string JwtConfigSecretKey = AppSettingsHelper.GetContent("JwtConfig", "SecretKey");
        public static readonly string JwtConfigIssuer = AppSettingsHelper.GetContent("JwtConfig", "Issuer");
        public static readonly string JwtConfigAudience = AppSettingsHelper.GetContent("JwtConfig", "Audience");
        #endregion

        #region Cors跨域设置================================================================================
        public static readonly string CorsPolicyName = AppSettingsHelper.GetContent("Cors", "PolicyName");
        public static readonly bool CorsEnableAllIPs = AppSettingsHelper.GetContent("Cors", "EnableAllIPs").ObjToBool();
        public static readonly string CorsIPs = AppSettingsHelper.GetContent("Cors", "IPs");

        public static readonly string ddd = AppSettingsHelper.GetContent();
        #endregion
    }
}
