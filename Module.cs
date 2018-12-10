using maxcar_goldtax.utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json.Linq;
using maxcar_goldtax.entity;

namespace maxcar_goldtax
{
    class Module : ComHelper
    {
        static LogTool log = new LogTool();

        ///// <summary>
        ///  打开金税盘组件
        /// </summary>
        /// <param name="password">数字证书密码</param>
        /// <param name="taxCode">税号</param>
        /// <param name="machineNo">开票机号</param>
        /// <param name="isRepReached">是否到抄税期</param>
        /// <param name="isLockReached">是否到锁死期</param>
        /// <param name="corpName">企业名称</param>
        /// <param name="checkCode">机器编号</param>
        /// <returns></returns>
        //开启 成功返回 1011  否则返回-1
        public static short InitCard()
        {
            try
            {
                m_GoldTax = Activator.CreateInstance(Type.GetTypeFromProgID("TaxCardX.GoldTax"));
                if (m_GoldTax != null)
                {
                    m_GoldTax.CertPassWord = "12345678";
                    m_GoldTax.openCard();
                }
                else
                {
                    return -1;
                }

                return m_GoldTax.RetCode;

            }
            catch (Exception ex)
            {
                log.WriteLine("Module.InitCard " + ex.Message);
                return -1;
            }
        }

        //查询库存剩余发票
        public static int GetInvoiceCount()
        {
            InitCard();
            m_GoldTax.InfoKind = 42;
            m_GoldTax.GetInfo();

            String number = m_GoldTax.InfoNumber + "";
            number = (Int32.Parse(number) - 1) + "";

            /*if (number.Trim().Length < 8)
            {
                for (int i = 0; i <= 8 - number.Trim().Length; i++)
                {
                    number = "0" + number;
                }
            }*/
 
            return m_GoldTax.InvStock;
        }

        //根据发票号码 和代码查询单张发票
        public static String GetSingleInvoice(string invoiceNum, string invoiceCode)
        {
            InitCard();
            m_GoldTax.InfoTypeCode = invoiceCode;

            m_GoldTax.InfoNumber = invoiceNum;
            m_GoldTax.InfoKind = 42;
            m_GoldTax.QryInv();
          
            return m_GoldTax.info;
        }

        //上传开票数据
        public static int Invoice(InvoiceUsedCar invInfo)
        {
            InitCard();
            // setInvoiceData(invInfo);

            m_GoldTax.InvInfoInit(); //初始化发票整体信息各项属性
            //1 自动上传  0 手动上传
            m_GoldTax.UploadInvoiceAuto = 1;

            string combine = GoldTaxHelper.CombineTaxPacket(invInfo.GFMC, invInfo.GFDM, invInfo.GFDZ,
            invInfo.GFDH, invInfo.XFMC, invInfo.XFDM, invInfo.XFDZ, invInfo.XFDH,
            invInfo.CPZH, invInfo.DJZH, invInfo.CLLX, invInfo.CJH, invInfo.CPXH,
            invInfo.CGSMC, invInfo.HJJE, invInfo.JYPMMC, invInfo.JYPMSH, invInfo.JYPMYHZH,
            invInfo.JYPMDZ, invInfo.JYPMDH, invInfo.SCMC, invInfo.SCSH, invInfo.SCDZ,
            invInfo.SCYHZH, invInfo.SCDH, invInfo.BZ, invInfo.KPR);

            string result = m_GoldTax.BatchUpload(combine);

            setInvoiceDataSM(invInfo);

            string combine2 = GoldTaxHelper.CombineTaxPacket(invInfo.GoodsNoVer, invInfo.GoodsTaxNo,
                         invInfo.TaxPre, invInfo.TaxPreCon, invInfo.ZeroTax, invInfo.CropGoodsNo,
                         invInfo.TaxDeduction);

            string result2 = m_GoldTax.BatchUpload(combine2);

            try
            {
                GoldTaxHelperAssist.ParseBatchUploadResult(result, "1400");
                GoldTaxHelperAssist.ParseBatchUploadResult(result2, "1100");
                return Constant.SUCCESS;
            }
            catch (Exception)
            {
                return Constant.ERROR;
            }

        }

        //校验开票数据和开票
        public static Response checkInvoice()
        {
            m_GoldTax.InfoKind = 42;
            m_GoldTax.CheckEWM = 1;
            m_GoldTax.Invoice();

            short code = m_GoldTax.RetCode;
            if (code == 4016)
            {
                m_GoldTax.CheckEWM = 0;
                m_GoldTax.Invoice();
                if (m_GoldTax.RetCode == 4011)
                {
                    Response response = new Response();
                    JObject data = new JObject();
                    string time = m_GoldTax.InfoDate + "";
                    data["infoDate"] = time.Replace("T", "");
                    data["number"] = m_GoldTax.InfoNumber;
                    data["code"] = m_GoldTax.InfoTypeCode;
                    //Response.setMessage(m_GoldTax.RetMsg);
                    response.Data = data;
                    return response;
                }
                else
                {
                    Response response = new Response
                    {
                        Code = m_GoldTax.RetCode,
                        Message = "开票失败:" + m_GoldTax.RetMsg
                    };
                    return response;
                }

                

            }
            else
            {
                Response response = new Response
                {
                    Code = m_GoldTax.RetCode,
                    Message = "校验失败:" + m_GoldTax.RetMsg
                };
                return response;


            }

        }

        private static void setInvoiceData(InvoiceUsedCar invInfo)
        {

            invInfo.GFMC = "黄旭";
            invInfo.GFDM = "123456667";
            invInfo.GFDZ = "123456667";
            invInfo.GFDH = "123456667";
            invInfo.XFMC = "123456667";
            invInfo.XFDM = "123456667";
            invInfo.XFDZ = "123456667";
            invInfo.XFDH = "123456667";

            invInfo.CPZH = "123456667";
            invInfo.DJZH = "123456667";
            invInfo.CLLX = "小型轿车";
            invInfo.CJH = "123456667";
            invInfo.CPXH = "宝马x5";
            invInfo.CGSMC = "123456667";
            invInfo.HJJE = 2;


            invInfo.JYPMMC = "123456667";
            invInfo.JYPMSH = "123456667";
            invInfo.JYPMYHZH = "123456667";
            invInfo.JYPMDZ = "123456667";
            invInfo.JYPMDH = "123456667";


            invInfo.SCMC = "123456667";
            invInfo.SCSH = "123456667";
            invInfo.SCDZ = "123456667";
            invInfo.SCYHZH = "123456667";
            invInfo.SCDH = "123456667";
            invInfo.BZ = "123456667";
            invInfo.KPR = "123456667";

        }


        public static Response cancleInvoice(string invoiceNum, string invoiceCode)
        {
            InitCard();
            m_GoldTax.InfoKind = 42;
            m_GoldTax.InfoTypeCode = invoiceCode;
            m_GoldTax.InfoNumber = invoiceNum;
            m_GoldTax.CancelInv();

            short resultCode = m_GoldTax.RetCode;
            string msg = m_GoldTax.RetMsg;
           
            if (resultCode == 6011)
            {
                return new Response();
            }
            else
            {
                Response response = new Response
                {
                    Code = Constant.ERROR,
                    Message = msg
                };
                return response;
            }


        }


        private static void closeCard()
        {
            m_GoldTax.CloseCard();
        }


        public static Response printInvoice(string invoiceNum, string invoiceCode)
        {
            InitCard();
            m_GoldTax.InfoKind = 42;
            m_GoldTax.InfoTypeCode = invoiceCode;
            m_GoldTax.InfoNumber = invoiceNum;
            m_GoldTax.GoodsListFlag = 0;
            m_GoldTax.InfoShowPrtDlg = 1;
            m_GoldTax.PrintInv();
            short resultCode = m_GoldTax.RetCode;
            string msg = m_GoldTax.RetMsg;
           
            if (resultCode == 5011)
            {
                return new Response();
            }
            else
            {
                Response response = new Response
                {
                    Code = Constant.ERROR,
                    Message = msg
                };
                return response;
            }


        }

        private static void setInvoiceDataSM(InvoiceUsedCar invInfo)
        {

            invInfo.GoodsNoVer = "1.0";
            invInfo.GoodsTaxNo = "1090305010200000000";
            invInfo.TaxPre = "1";
            invInfo.TaxPreCon = "免税";
            invInfo.CropGoodsNo = "12345321";
            invInfo.TaxDeduction = "";
            invInfo.ZeroTax = "";

        }

    }
}
