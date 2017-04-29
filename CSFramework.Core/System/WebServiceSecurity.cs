using System;
using System.Collections.Generic;
using System.Text;
using CSFramework.Common;

namespace CSFramework.Core
{
    /// <summary>
    /// WebService接口安全管理核心类
    /// </summary>
    public class WebServiceSecurity
    {
        private const int PREFIX_LEN = 16;/*预设伪造16位的数据(校验码)*/
        private const int SUFFIX_LEN = 8;/*预设伪造8位的数据(校验码)*/
        private const string LOGIN_TICKET = "0X1D30A4B5C0A06S3L7X0G7H3D72C8E9"; //32位密码,可以改为更长

        /// <summary>
        /// 用户登录的验证码,防止用户恶意攻击Login接口.
        /// </summary>
        /// <param name="ticket">验证码</param>
        /// <returns></returns>
        public static bool ValidateLoginIdentity(byte[] ticket)
        {
            if ((ticket == null) || (ticket.Length < LOGIN_TICKET.Length)) return false; //位数不够,验证失败

            //取系统定义的验证码,你可以定义为128位.
            string TicketString = Encoding.ASCII.GetString(GetLoginTicket()).ToUpper();

            //客户端传来的验证码与系统定义的相比较
            bool success = Encoding.ASCII.GetString(ticket).ToUpper() == TicketString;

            if (success == false)
                throw new Exception("无效的验证码! 你还可以尝试X次,否则查你户口,封你IP!");

            return success;

            //
            //设计一个防止用户恶意攻击的管理器,记录每次调用的方法名及调用时间,
            //如果在指定的时间内调用超过最大限制数则视为恶意攻击,你可以暂时封杀
            //用户的IP.
            //
        }

        /// <summary>
        /// 检查用户登录凭证，验证通过才允许访问后台数据.
        /// </summary>
        /// <param name="loginer">用户登录凭证</param>
        /// <returns></returns>
        public static Loginer ValidateLoginer(byte[] loginer)
        {
            //用户登录信息的长度小于伪码长度,数据包无效!
            if (loginer.Length < PREFIX_LEN + SUFFIX_LEN) return null;

            try
            {
                //用户登录信息的长度
                byte[] objectArrar = new byte[loginer.Length - (PREFIX_LEN + SUFFIX_LEN)];

                //复制用户登录信息的数据包(去掉前后伪码)
                Array.Copy(loginer, PREFIX_LEN, objectArrar, 0, objectArrar.Length);

                //转换为用户对象
                Loginer user = (Loginer)ZipTools.DecompressionObject(objectArrar);
                if (user.Account.Length >= 1) //系统限制用户帐号的长度必须大于或等于1位
                    return user; //转换成功,返回用户对象.                
                else
                    throw new Exception("用户帐号不正确!");
            }
            catch
            {
                throw new Exception("验证用户资料失败!");
            }
        }

        /// <summary>
        /// 加密用户登录凭证
        /// </summary>
        /// <param name="user">当前用户登录信息</param>
        /// <returns></returns>
        public static byte[] EncryptLoginer(Loginer user)
        {
            byte[] user_byte = ZipTools.CompressionObject(user);
            byte[] result = new byte[user_byte.Length + PREFIX_LEN + SUFFIX_LEN];

            byte[] prefix = GetByteData(PREFIX_LEN);
            byte[] suffix = GetByteData(SUFFIX_LEN);

            Array.Copy(user_byte, 0, result, PREFIX_LEN, user_byte.Length); //复制用户数据
            Array.Copy(prefix, 0, result, 0, prefix.Length); //复制头部伪码
            Array.Copy(suffix, 0, result, result.Length - SUFFIX_LEN, suffix.Length); //复制尾部伪码

            return result;
        }

        /// <summary>
        /// 用户登录的验证码
        /// </summary>
        /// <returns></returns>
        public static byte[] GetLoginTicket()
        {
            byte[] result = Encoding.ASCII.GetBytes(LOGIN_TICKET);
            return result;
        }

        /// <summary>
        /// 用户登录信息加密后伪造指定位数的数据.
        /// </summary>
        private static byte[] GetByteData(int bit)
        {
            //128位伪造数据
            string chars = "ZA1D30A4B5C006S3LDFGHKD72C8E920D" +
                           "FJKQ30F506E7EQWERUIYUI02F1A0D0IO" +
                           "WEURTK236890L23B3B40C5E180D6F4D5" +
                           "EOPFDGHKW3IT6F4X90238503AS1094A2";

            if (bit < 2) bit = 2;//最少两位

            int n = GetRandomNum(chars.Length - bit - 2);//获取随机数
            string s = chars.Substring(n - 1, bit);
            byte[] result = Encoding.ASCII.GetBytes(s);
            return result;
        }

        //获取随机数
        private static int GetRandomNum(int maxValue)
        {
            Random seed = new Random();
            Random randomNum = new Random();
            return randomNum.Next(1, maxValue);
        }
    }
}
