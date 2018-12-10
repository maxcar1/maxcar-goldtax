#region << 版 本 注 释 >>
/**
 * 文件名： XmlUtils
 *【功 能】
 *  Xml序列化与反序列化工具
 *  
 *   版本       变更时间         部门      作者             变更内容
 * ───────────────────────────────────
 *   V1.0.0.1   2017-05-16            	   陈嘉俊           初版
 *   
 *
 * Copyright(c)2017 Zhejiang Aisino Co.,Ltd. All Rights Reserved.
 * LICENSE INFORMATION
 */
#endregion

using System;
using System.IO;
using System.Text;
using System.Xml.Serialization;

namespace maxcar_goldtax.utils
{
    public class XmlUtils {
        /// <summary>
        /// 将对象obj序列化为xml
        /// </summary>
        /// <typeparam name="T">对象类型</typeparam>
        /// <param name="obj">对象</param>
        /// <returns></returns>
        public static string Serializer<T>(T obj) {
            using (MemoryStream stream = new MemoryStream()) {
                XmlSerializerNamespaces namespaces = new XmlSerializerNamespaces();
                namespaces.Add(string.Empty, string.Empty);

                XmlSerializer xml = new XmlSerializer(typeof(T));
                using (StreamWriter writer = new StreamWriter(stream, Encoding.GetEncoding("GBK"))) {
                    xml.Serialize(writer, obj, namespaces);
                    stream.Position = 0;
                    using (StreamReader sr = new StreamReader(stream, Encoding.GetEncoding("GBK"))) {
                        string xmlStr = sr.ReadLine();
                        string xmlDeclaration = "<?xml version=\"1.0\" encoding=\"GBK\"?>" + Environment.NewLine;
                        return xmlDeclaration + sr.ReadToEnd();
                    }
                }
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="xml">xml描述</param>
        /// <returns></returns>
        public static T Deserialize<T>(string xml)
            where T : class {
            using (StringReader sr = new StringReader(xml)) {
                XmlSerializer xmlS = new XmlSerializer(typeof(T));
                return xmlS.Deserialize(sr) as T;
            }
        }

        /// <summary>
        /// 反序列化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="stream"></param>
        /// <returns></returns>
        public static T Deserialize<T>(Stream stream)
            where T : class {
            XmlSerializer xmlS = new XmlSerializer(typeof(T));
            return xmlS.Deserialize(stream) as T;
        }
    }
}
