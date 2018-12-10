using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using maxcar_goldtax.entity;
using Newtonsoft.Json.Linq;

namespace maxcar_goldtax.utils
{
    class JsonConvert
    {
        static LogTool log = new LogTool();
        
        public static String getMethod(String jsonData)
        {
            try
            {
                JObject obj = JObject.Parse(jsonData);
                return obj["serviceMethod"].ToString();
            }
            catch (Exception e)
            {
                log.WriteLine("JsonConvert:" + e.Message);
                return null;
            }

        }


        public static InvoiceUsedCar getInvoiceData(String jsonData)
        {
            try
            {
                JObject parmar = JObject.Parse(jsonData);
                JObject obj = JObject.Parse(parmar["serviceParams"].ToString());
                InvoiceUsedCar usedCar = new InvoiceUsedCar();
               
                usedCar.GFDZ = obj["gfdz"].ToString();
                usedCar.GFMC = obj["gfmc"].ToString();
                usedCar.CGSMC = obj["cgsmc"].ToString();
                usedCar.XFDH = obj["xfdh"].ToString();
                usedCar.HJJE = Double.Parse(obj["hjje"].ToString());
                usedCar.XFDM = obj["xfdm"].ToString();

                usedCar.SCSH = obj["scsh"].ToString();
                usedCar.GFDH = obj["gfdh"].ToString();
                usedCar.SCDZ = obj["scdz"].ToString();
                usedCar.SCMC = obj["scmc"].ToString();
                usedCar.BZ = obj["bz"].ToString();
                usedCar.GFDM = obj["gfdm"].ToString();
               

                usedCar.CLLX = obj["cllx"].ToString();
                usedCar.DJZH = obj["djzh"].ToString();
                usedCar.CJH = obj["cjh"].ToString();
                usedCar.SCDH = obj["scdh"].ToString();
                usedCar.JYPMDZ = obj["jypmdz"].ToString();
                usedCar.JYPMMC = obj["jypmmc"].ToString();
                usedCar.JYPMSH = obj["jypmsh"].ToString();
                usedCar.SCDH = obj["scdh"].ToString();


                usedCar.SCYHZH = obj["scyhzh"].ToString();
                usedCar.JYPMYHZH = obj["jypmyhzh"].ToString();
                usedCar.JYPMDH = obj["jypmdh"].ToString();
                usedCar.KPR = obj["kpr"].ToString();
                usedCar.CPXH = obj["cpxh"].ToString();
                usedCar.CPZH = obj["cpzh"].ToString();

                usedCar.XFDZ = obj["xfdz"].ToString();
                usedCar.XFMC = obj["xfmc"].ToString();
                return usedCar;
            }
            catch (Exception e)
            {
                log.WriteLine("JsonConvert:" + e.Message);
                return null;
            }
            
        
        }

        //{"serviceParams":{"number":"00290497","code":"045001800217"},"serviceMethod":"printInvoice"} 
        public static string[] getNumberAndCode(String jsonData)
        {
            try
            {
                JObject obj = JObject.Parse(jsonData);
                JObject parmar = JObject.Parse(obj["serviceParams"].ToString());
                string[] data = new string[2];
                data[0] = parmar["number"].ToString();
                data[1] = parmar["code"].ToString();
                return data;
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }
    }
}
