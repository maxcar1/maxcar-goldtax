#region << 版 本 注 释 >>
/**
 *【功 能】
 *  工具类
 *  
 *   版本       变更时间     部门    作者             变更内容
 * ──────────────────────────────────
 *   V1.0.0     2012-10-19           陈嘉俊           初版
 *   V2.0.0     2015-03-30           陈嘉俊           初版，对应新版2.0防伪开票接口
 *   V2.0.1     2018-03-15           陈嘉俊           舍弃文本方式解析xml的方法，系统采用xml反序列化来处理
 *   
 * Copyright (c) 2012 ZhejiangAision All Rights Reserved.
 * LICENSE INFORMATION
 */

#endregion

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace maxcar_goldtax.utils
{
    public static class GoldTaxUtility {
        #region 采用xml反序列化来解析，该方法舍弃
        ///// <summary>
        ///// 解析BatchUpload返回结果
        ///// </summary>
        ///// <param name="xml">待解析xml描述</param>
        ///// <param name="bid">业务id</param>
        ///// <param name="code">返回编码</param>
        ///// <param name="msg">返回信息描述</param>
        ///// <returns></returns>
        //public static bool ParseXmlResult(string xml, string bid, out string code, out string msg) {
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    XmlNode infoNode = doc.SelectSingleNode("FPXT_COM_OUTPUT");
        //    if (infoNode == null)
        //        throw new TaxCardException("BatchUpload结果解析异常:没有找到FPXT_COM_OUTPUT节");

        //    XmlNode idNode = infoNode.SelectSingleNode("ID");
        //    string id = idNode.InnerText;
        //    if (id != bid && id != "unknown")
        //        throw new TaxCardException("BatchUpload接口业务标准异常:ID=" + id);

        //    code = infoNode.SelectSingleNode("CODE").InnerText;
        //    msg = infoNode.SelectSingleNode("MESS").InnerText;

        //    if (code.Trim() != "0000")
        //        return false;

        //    return true;
        //}

        ///// <summary>
        ///// 解析BatchUpload返回结果
        ///// </summary>
        ///// <param name="xml">待解析xml描述</param>
        ///// <param name="bid">业务id</param>
        ///// <param name="code">返回编码</param>
        ///// <param name="msg">返回信息描述</param>
        ///// <param name="data">返回数据</param>
        ///// <returns></returns>
        //public static bool ParseXmlResult(string xml, string bid, out string code, out string msg, out string data) {
        //    XmlDocument doc = new XmlDocument();
        //    doc.LoadXml(xml);
        //    XmlNode infoNode = doc.SelectSingleNode("FPXT_COM_OUTPUT");
        //    if (infoNode == null)
        //        throw new TaxCardException("BatchUpload结果解析异常:没有找到FPXT_COM_OUTPUT节");

        //    XmlNode idNode = infoNode.SelectSingleNode("ID");
        //    string id = idNode.InnerText;
        //    if (id != bid && id != "unknown")
        //        throw new TaxCardException("BatchUpload接口业务标准异常:ID=" + id);

        //    code = infoNode.SelectSingleNode("CODE").InnerText;
        //    msg = infoNode.SelectSingleNode("MESS").InnerText;
        //    data = infoNode.SelectSingleNode("DATA").InnerText;
        //    if (code.Trim() != "0000")
        //        return false;

        //    return true;
        //}
        #endregion
            
        /// <summary>
        /// 解密密文内容
        /// </summary>
        /// <param name="encryptMW"></param>
        /// <returns></returns>
        public static string DecryptMW(string encryptMW) {
            byte[] bytesDecrypt;
            byte[] mwBase64 = Convert.FromBase64String(encryptMW);
            byte[] byte1 =
            {
                175,
                82,
                222,
                69,
                15,
                88,
                205,
                16,
                35,
                139,
                69,
                106,
                16,
                144,
                175,
                189,
                173,
                219,
                174,
                141,
                172,
                128,
                82,
                255,
                69,
                144,
                133,
                202,
                203,
                159,
                175,
                189
            };

            byte[] byte2 =
            {
                2,
                175,
                188,
                171,
                204,
                144,
                57,
                144,
                188,
                175,
                134,
                153,
                173,
                170,
                251,
                96
            };

            Rijndael rijndael = Rijndael.Create();
            using (MemoryStream memoryStream = new MemoryStream(mwBase64)) {
                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(byte1, byte2), CryptoStreamMode.Read)) {
                    using (MemoryStream memoryStream2 = new MemoryStream()) {
                        byte[] array = new byte[1024];
                        int count;
                        while ((count = cryptoStream.Read(array, 0, array.Length)) > 0) {
                            memoryStream2.Write(array, 0, count);
                        }
                        bytesDecrypt = memoryStream2.ToArray();
                    }
                }
            }

            return Encoding.GetEncoding("GBK").GetString(bytesDecrypt);
        }
    }
}