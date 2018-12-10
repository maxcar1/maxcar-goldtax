using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maxcar_goldtax.entity;

namespace maxcar_goldtax.utils
{
    class XmlCreater
    {

        public static string CreateBussinessXml(string bId, string data)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.AppendLine("<FPXT_COM_INPUT>");
            sb.AppendLine("<ID>" + bId + "</ID>");
            sb.AppendLine("<DATA>");
            sb.AppendLine(data);
            sb.AppendLine("</DATA>");
            sb.AppendLine("</FPXT_COM_INPUT>");

            return sb.ToString();
        }

        /// <summary>
        /// 解析BatchUpload返回结果
        /// </summary>
        /// <param name="strInfo">返回结果</param>
        /// <param name="bId"></param>
        public static ResponseInfo ParseBatchUploadResult(string strInfo, string bId)
        {
            ResponseInfo res = XmlUtils.Deserialize<ResponseInfo>(strInfo);
            if (res.Id != bId)
                throw new Exception("BatchUpload接口业务标准异常:ID=" + res.Id);

            if (res.Code != "0000")
                throw new Exception("BatchUpload异常:[" + res.Code + "]" + res.Message);

            return res;
        }
    }
}
