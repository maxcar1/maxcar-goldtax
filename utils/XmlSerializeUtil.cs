#region << 版 本 注 释 >>
/**
 * 文件名： XmlSerializeUtil
 *【功 能】
 *  xml序列化工具
 *  
 *   版本       变更时间                 部门      作者             变更内容
 * ───────────────────────────────────────────────────────────────────────────────────
 *   V1.0.0.0   2017-05-11 20:09:15           	   陈嘉俊           初版
 *   
 *
 * Copyright(c)2017 Zhejiang Aisino Co.,Ltd. All Rights Reserved.
 * LICENSE INFORMATION
 */
#endregion

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace maxcar_goldtax.utils
{
    public class XmlSerializeUtil {
        public static void Deserialize<T>(string xml) {
            using (StringReader sr = new StringReader(xml)) {
                XmlSerializer xmldes = new XmlSerializer(typeof(T));
                
            }
        }
    }
}
