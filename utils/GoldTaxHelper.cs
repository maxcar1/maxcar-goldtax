
using System;
using System.Text;

namespace maxcar_goldtax.utils
{
    public partial class GoldTaxHelper
    {

        
        /// <summary>
        /// 组织税收分类编码的数据报文
        /// </summary>
        /// <param name="gfmc">买方单位/个人(72 字符)</param>
        /// <param name="gfdm">买方单位代码/身份证号码(22 字符)</param>
        /// <param name="gfdz">买方单位/个人地址(80 字符)</param>
        /// <param name="gfdh">买方电话(20 字符)</param>
        /// <param name="xfmc">卖方单位/个人(72 字符)</param>
        /// <param name="xfdm">卖方单位代码/身份证号码(22 字符)</param>
        /// <param name="xfdz">卖方单位/个人住址(80 字符)</param>
        /// <param name="xfdh">卖方电话(20 字符)</param>
        /// <param name="cpzh">车牌照号(20 个字符)</param>
        /// <param name="djzh">登记证号(20 字符)</param>
        /// <param name="cllx">车辆类型(40 字符)</param>
        /// <param name="cjh">车架号/车辆识别代码(23 字符)、英文字母需要大写</param>
        /// <param name="cpxh">厂牌型号(60 字符)</param>
        /// <param name="cgsmc">转入地车辆管理所名称(80 字符)</param>
        /// <param name="hjje">车价合计小写，double 类型，最多  1000000000</param>
        /// <param name="jypmmc">经营、拍卖单位(80 字符)</param>
        /// <param name="jypmsh">经营、拍卖单位纳税人识别号(20 字符)</param>
        /// <param name="jypmyhzh">经营、拍卖单位地址(80 字符)</param>
        /// <param name="jypmdz">经营、拍卖单位开户银行、账号(120 字符)</param>
        /// <param name="jypmdh">经营、拍卖单位/电话(20 字符)</param>
        /// <param name="scmc">二手车市场(80 字符)</param>
        /// <param name="scsh">二手车市场纳税人识别号(20 字符)</param>
        /// <param name="scdz">二手车市场地址(80 字符)</param>
        /// <param name="scyhzh">二手车市场开户银行、账号(120 字符)</param>
        /// <param name="scdh">二手车市场电话(20 字符)</param>
        /// <param name="bz">备注(230 字符)</param>
        /// <param name="kpr">开票人(20 字符)</param>
        /// <returns></returns>
        public static string CombineTaxPacket(string gfmc, string gfdm, string gfdz,
            string gfdh, string xfmc, string xfdm, string xfdz, string xfdh,
            string cpzh, string djzh, string cllx, string cjh, string cpxh,
            string cgsmc, double hjje, string jypmmc, string jypmsh, string jypmyhzh,
            string jypmdz, string jypmdh, string scmc, string scsh, string scdz,
            string scyhzh, string scdh, string bz, string kpr)
        {

            string base64 = CombineTaxData(gfmc, gfdm, gfdz,
             gfdh, xfmc, xfdm, xfdz, xfdh,
             cpzh, djzh, cllx, cjh, cpxh,
             cgsmc, hjje, jypmmc, jypmsh, jypmyhzh,
             jypmdz, jypmdh, scmc, scsh, scdz,
             scyhzh, scdh, bz, kpr);

            return XmlCreater.CreateBussinessXml("1400", base64);
        }

        public static string CombineTaxPacket(string goodsNoVer, string goodsTaxNo, string taxPre, string taxPreCon, string zeroTax, string cropGoodsNo, string taxDeduction)
        {
            if (string.IsNullOrEmpty(goodsTaxNo))
                throw new Exception("税收分类编码为空!");
            string base64 = CombineTaxData(goodsNoVer, goodsTaxNo,
             taxPre, taxPreCon, zeroTax, cropGoodsNo, taxDeduction);

            return XmlCreater.CreateBussinessXml("1100", base64);
        }


        /// <summary>
        /// 组织税收分类编码的数据报文
        /// </summary>
        /// <param name="gfmc">买方单位/个人(72 字符)</param>
        /// <param name="gfdm">买方单位代码/身份证号码(22 字符)</param>
        /// <param name="gfdz">买方单位/个人地址(80 字符)</param>
        /// <param name="gfdh">买方电话(20 字符)</param>
        /// <param name="xfmc">卖方单位/个人(72 字符)</param>
        /// <param name="xfdm">卖方单位代码/身份证号码(22 字符)</param>
        /// <param name="xfdz">卖方单位/个人住址(80 字符)</param>
        /// <param name="xfdh">卖方电话(20 字符)</param>
        /// <param name="cpzh">车牌照号(20 个字符)</param>
        /// <param name="djzh">登记证号(20 字符)</param>
        /// <param name="cllx">车辆类型(40 字符)</param>
        /// <param name="cjh">车架号/车辆识别代码(23 字符)、英文字母需要大写</param>
        /// <param name="cpxh">厂牌型号(60 字符)</param>
        /// <param name="cgsmc">转入地车辆管理所名称(80 字符)</param>
        /// <param name="hjje">车价合计小写，double 类型，最多  1000000000</param>
        /// <param name="jypmmc">经营、拍卖单位(80 字符)</param>
        /// <param name="jypmsh">经营、拍卖单位纳税人识别号(20 字符)</param>
        /// <param name="jypmyhzh">经营、拍卖单位地址(80 字符)</param>
        /// <param name="jypmdz">经营、拍卖单位开户银行、账号(120 字符)</param>
        /// <param name="jypmdh">经营、拍卖单位/电话(20 字符)</param>
        /// <param name="scmc">二手车市场(80 字符)</param>
        /// <param name="scsh">二手车市场纳税人识别号(20 字符)</param>
        /// <param name="scdz">二手车市场地址(80 字符)</param>
        /// <param name="scyhzh">二手车市场开户银行、账号(120 字符)</param>
        /// <param name="scdh">二手车市场电话(20 字符)</param>
        /// <param name="bz">备注(230 字符)</param>
        /// <param name="kpr">开票人(20 字符)</param>
        /// <returns></returns>
        public static string CombineTaxData(string gfmc, string gfdm, string gfdz,
            string gfdh, string xfmc, string xfdm, string xfdz, string xfdh,
            string cpzh, string djzh, string cllx, string cjh, string cpxh,
            string cgsmc, double hjje, string jypmmc, string jypmsh, string jypmyhzh,
            string jypmdz, string jypmdh, string scmc, string scsh, string scdz,
            string scyhzh, string scdh, string bz, string kpr)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.AppendLine("<FPXT>");
            sb.AppendLine("<INPUT>");
            sb.Append("<gfmc>");
            sb.Append(gfmc);
            sb.AppendLine("</gfmc>");
            sb.Append("<gfdm>");
            sb.Append(gfdm);
            sb.AppendLine("</gfdm>");
            sb.Append("<gfdz>");
            sb.Append(gfdz);
            sb.AppendLine("</gfdz>");
            sb.Append("<gfdh>");
            sb.Append(gfdh);
            sb.AppendLine("</gfdh>");
            sb.Append("<xfmc>");
            sb.Append(xfmc);
            sb.AppendLine("</xfmc>");
            sb.Append("<xfdm>");
            sb.Append(xfdm);
            sb.AppendLine("</xfdm>");
            sb.Append("<xfdz>");
            sb.Append(xfdz);
            sb.AppendLine("</xfdz>");
            sb.Append("<xfdh>");
            sb.Append(xfdh);
            sb.AppendLine("</xfdh>");
            sb.Append("<cpzh>");
            sb.Append(cpzh);
            sb.AppendLine("</cpzh>");
            sb.Append("<djzh>");
            sb.Append(djzh);
            sb.AppendLine("</djzh>");
            sb.Append("<cllx>");
            sb.Append(cllx);
            sb.AppendLine("</cllx>");
            sb.Append("<cjh>");
            sb.Append(cjh);
            sb.AppendLine("</cjh>");
            sb.Append("<cpxh>");
            sb.Append(cpxh);
            sb.AppendLine("</cpxh>");
            sb.Append("<cgsmc>");
            sb.Append(cgsmc);
            sb.AppendLine("</cgsmc>");
            sb.Append("<hjje>");
            sb.Append(hjje);
            sb.AppendLine("</hjje>");
            sb.Append("<jypmmc>");
            sb.Append(jypmmc);
            sb.AppendLine("</jypmmc>");
            sb.Append("<jypmsh>");
            sb.Append(jypmsh);
            sb.AppendLine("</jypmsh>");
            sb.Append("<jypmyhzh>");
            sb.Append(jypmyhzh);
            sb.AppendLine("</jypmyhzh>");
            sb.Append("<jypmdz>");
            sb.Append(jypmdz);
            sb.AppendLine("</jypmdz>");
            sb.Append("<jypmdh>");
            sb.Append(jypmdh);
            sb.AppendLine("</jypmdh>");
            sb.Append("<scmc>");
            sb.Append(scmc);
            sb.AppendLine("</scmc>");
            sb.Append("<scsh>");
            sb.Append(scsh);
            sb.AppendLine("</scsh>");
            sb.Append("<scdz>");
            sb.Append(scdz);
            sb.AppendLine("</scdz>");
            sb.Append("<scyhzh>");
            sb.Append(scyhzh);
            sb.AppendLine("</scyhzh>");
            sb.Append("<scdh>");
            sb.Append(scdh);
            sb.AppendLine("</scdh>");
            sb.Append("<bz>");
            sb.Append(bz);
            sb.AppendLine("</bz>");
            sb.Append("<kpr>");
            sb.Append(kpr);
            sb.AppendLine("</kpr>");
            sb.AppendLine("</INPUT>");
            sb.Append("</FPXT>");

            byte[] byteData = Encoding.GetEncoding("GBK").GetBytes(sb.ToString());
            return Convert.ToBase64String(byteData, 0, byteData.Length);
        }

        public static string CombineTaxData(string goodsNoVer,
            string goodsTaxNo, string taxPre, string taxPreCon,
            string zeroTax, string cropGoodsNo, string taxDeduction)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<?xml version=\"1.0\" encoding=\"GBK\"?>");
            sb.AppendLine("<FPXT>");
            sb.AppendLine("<INPUT>");
            sb.AppendLine("<GoodsNo>");

            sb.Append("<GoodsNoVer>");
            sb.Append(goodsNoVer);
            sb.AppendLine("</GoodsNoVer>");
            sb.Append("<GoodsTaxNo>");
            sb.Append(goodsTaxNo);
            sb.AppendLine("</GoodsTaxNo>");
            sb.Append("<TaxPre>");
            sb.Append(taxPre);
            sb.AppendLine("</TaxPre>");
            sb.Append("<TaxPreCon>");
            sb.Append(taxPreCon);
            sb.AppendLine("</TaxPreCon>");
            sb.Append("<ZeroTax>");
            sb.Append(zeroTax);
            sb.AppendLine("</ZeroTax>");
            sb.Append("<CropGoodsNo>");
            sb.Append(cropGoodsNo);
            sb.AppendLine("</CropGoodsNo>");
            sb.Append("<TaxDeduction>");
            sb.Append(taxDeduction);
            sb.AppendLine("</TaxDeduction>");
            sb.AppendLine("</GoodsNo>");
            sb.AppendLine("</INPUT>");
            sb.Append("</FPXT>");

            byte[] byteData = Encoding.GetEncoding("GBK").GetBytes(sb.ToString());
            return Convert.ToBase64String(byteData, 0, byteData.Length);
        }
    }
     
}