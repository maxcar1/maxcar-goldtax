using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text;

namespace maxcar_goldtax.utils
{
    public class Utility
    {
        [DllImport("ReadAreaCode.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetRealTaxCode(byte[] taxcode, byte[] path);

        [DllImport("ReadAreaCode.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetKpNo(byte[] machineno, byte[] path);

        [DllImport("ReadAreaCode.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetAreaCode(byte[] machineno, byte[] path);

        [DllImport("ReadAreaCode.dll", CallingConvention = CallingConvention.Cdecl)]
        private static extern int GetVerNo(byte[] machineno, byte[] path);

        /// <summary>
        /// 通过Dll获取金税盘税号
        /// </summary>
        /// <returns></returns>
        public static string GetTaxCode()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSDiskDLL.dll");
            byte[] array = new byte[25];
            int num = GetRealTaxCode(array, Encoding.GetEncoding("GBK").GetBytes(path));
            string taxCode = Encoding.GetEncoding("GBK").GetString(array);
            taxCode = taxCode.Trim(new char[1]);
            return taxCode;
        }

        /// <summary>
        /// 通过Dll获取金税盘开票机号
        /// </summary>
        /// <returns></returns>
        public static string GetMachineNum()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSDiskDLL.dll");
            byte[] array = new byte[25];
            int num = GetKpNo(array, Encoding.GetEncoding("GBK").GetBytes(path));
            string machineNum = Encoding.GetEncoding("GBK").GetString(array);
            machineNum = machineNum.Trim(new char[1]);
            return machineNum;
        }

        public static string GetTaxAreaCode()
        {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSDiskDLL.dll");
            byte[] array = new byte[25];
            int num = GetAreaCode(array, Encoding.GetEncoding("GBK").GetBytes(path));
            string areaCode = Encoding.GetEncoding("GBK").GetString(array);
            areaCode = areaCode.Trim(new char[1]);
            return areaCode;
        }

        public static string GetTaxVerNo() {
            string path = Path.Combine(Path.GetDirectoryName(Assembly.GetExecutingAssembly().Location), "JSDiskDLL.dll");
            byte[] array = new byte[25];
            int num = GetVerNo(array, Encoding.GetEncoding("GBK").GetBytes(path));
            string areaCode = Encoding.GetEncoding("GBK").GetString(array);
            areaCode = areaCode.Trim(new char[1]);
            return areaCode;
        }
    }
}
