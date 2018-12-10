#region << 版 本 注 释 >>
/**
 * 文件名： InvoiceUsedCar.cs
 *【功 能】
 *  发票信息
 *  
 *   版本       变更时间     部门    作者             变更内容
 * ──────────────────────────────────
 *   V2.0.0     2018-07-11        刘垂特           初版
 *
 * Copyright(c)2012 ZhejiangAisino All Rights Reserved.
 * LICENSE INFORMATION
 */

#endregion

using System;

namespace maxcar_goldtax.entity
{
    /// <summary>
    /// 二手车发票
    /// </summary>
    public class InvoiceUsedCar {
        /// <summary>
        /// 发票种类（0:增值税专用发票; 1:废旧物资发票; 2:增值税普通发票;11:货物运输业增值税专用发票;12:机动车销售统一发票;41:卷票;42:二手车销售统一发票）
        /// </summary>
        public short FPZL { get; set; }

        /// <summary>
        /// 发票类型："1"-旧版,"2"-新版
        /// </summary>
        public string UsedCarType { get; set; }

        /// <summary>
        /// 开票机号
        /// </summary>
        public short MachineNum { get; set; }

        /// <summary>
        /// 机器编号
        /// </summary>
        public string MachineCode { get; set; }

        /// <summary>
        /// 发票代码（12个字符）
        /// </summary>
        public string FPDM { get; set; }

        /// <summary>
        /// 发票号码
        /// </summary>
        public int FPHM { get; set; }

        /// <summary>
        /// 开票日期
        /// </summary>
        public DateTime KPSJ { get; set; }

        /// <summary>
        /// 打印标志：1 打印，0 未打印
        /// </summary>
        public short DYZT { get; set; }

        /// <summary>
        /// 发票报送状态(0：未报送，1：已报送，2 报送失败，3 报送中，4 验签失败)
        /// </summary>
        public short BSZT { get; set; }

        /// <summary>
        /// 作废标志（0：未作废，1：已作废）
        /// </summary>
        public short ZFZT { get; set; }

        /// <summary>
        /// 销售单据编号(开票软件30字节)
        /// </summary>
        public string XSDJBH { get; set; }

        /// <summary>
        /// 购方名称（72字符）
        /// </summary>
        public string GFMC { get; set; }

        /// <summary>
        /// 身份证号/组织机构代码（22字符）
        /// </summary>
        public string GFDM { get; set; }

        /// <summary>
        /// 买方单位/个人地址（80字符）
        /// </summary>
        public string GFDZ { get; set; }

        /// <summary>
        /// 买方电话(20个字符)
        /// </summary>
        public string GFDH { get; set; }

        /// <summary>
        /// 卖方单位/个人(72个字符)
        /// </summary>
        public string XFMC { get; set; }

        /// <summary>
        /// 卖方单位代码/身份证号码(22个字符)
        /// </summary>
        public string XFDM { get; set; }

        /// <summary>
        /// 卖方单位/个人住址(80个字符)
        /// </summary>
        public string XFDZ { get; set; }

        /// <summary>
        /// 卖方电话(20个字符)
        /// </summary>
        public string XFDH { get; set; }

        /// <summary>
        /// 车牌照号(20个字符)
        /// </summary>
        public string CPZH { get; set; }

        /// <summary>
        /// 登记证号(20个字符)
        /// </summary>
        public string DJZH { get; set; }

        /// <summary>
        /// 车辆类型（40个字符）
        /// </summary>
        public string CLLX { get; set; }

        /// <summary>
        /// 车架号/车辆识别代码（60个字符）
        /// </summary>
        public string CJH { get; set; }

        /// <summary>
        /// 厂牌型号（60个字符）
        /// </summary>
        public string CPXH { get; set; }



        /// <summary>
        /// 转入地车辆管理所名称（80个字符）
        /// </summary>
        public string CGSMC { get; set; }

        /// <summary>
        /// 车价合计小写，最多1000000000
        /// </summary>
        public double HJJE { get; set; }

        /// <summary>
        /// 经营、拍卖单位（80个字符）
        /// </summary>
        public string JYPMMC { get; set; }

        /// <summary>
        /// 经营、拍卖单位 ,纳税人识别号（20个字符）
        /// </summary>
        public string JYPMSH { get; set; }

        /// <summary>
        /// 经营、拍卖单位  开户银行、账号（120个字符）
        /// </summary>
        public string JYPMYHZH { get; set; }

        /// <summary>
        /// 经营、拍卖单位地址（80个字符）
        /// </summary>
        public string JYPMDZ { get; set; }

        /// <summary>
        /// 经营、拍卖单位/电话（20个字符）
        /// </summary>
        public string JYPMDH { get; set; }

        /// <summary>
        /// 二手车市场（80个字符）
        /// </summary>
        public string SCMC { get; set; }

        /// <summary>
        /// 二手车市场  纳税人识别号（20个字符）
        /// </summary>
        public string SCSH { get; set; }

        /// <summary>
        /// 二手车市场  地址（80个字符）
        /// </summary>
        public string SCDZ { get; set; }

        /// <summary>
        /// 二手车市场  开户银行、账号（120个字符）
        /// </summary>
        public string SCYHZH { get; set; }

        /// <summary>
        /// 二手车市场  电话（20个字符）
        /// </summary>
        public string SCDH { get; set; }

        /// <summary>
        /// 备注（230个字符）
        /// </summary>
        public string BZ { get; set; }

        /// <summary>
        /// 开票人（20个字符）
        /// </summary>
        public string KPR { get; set; }

        /// <summary>
        /// 所属年份
        /// </summary>
        public short InvYear { get; set; }

        /// <summary>
        /// 所属月份
        /// </summary>
        public short InvMonth { get; set; }

        /// <summary>
        /// 密文(仅用于Repface)
        /// </summary>
        public string DecryptedString { get; set; }

        /// <summary>
        /// 作废标志
        /// </summary>
        public short Zfbz { get; set; }

        /// <summary>
        /// 报税状态
        /// </summary>
        public short Bszt { get; set; }

        /// <summary>
        /// 打印标志
        /// </summary>
        public short Dybz { get; set; }

        /// <summary>
        /// 修复标志
        /// </summary>
        public short Xfbz { get; set; }

        /// <summary>
        /// 销售单据编号(开票软件30字节)
        /// </summary>
        public string BillNumber { get; set; }

        #region 税收分类编码
        /// <summary>
        /// 编码版本号
        /// </summary>
        public string GoodsNoVer { get; set; }

        /// <summary>
        /// 商品税收分类编码
        /// </summary>
        public string GoodsTaxNo { get; set; }

        /// <summary>
        /// 是否享受税收优惠政策 0:不享受，1:享受
        /// </summary>
        public string TaxPre { get; set; }

        /// <summary>
        /// 享受税收优惠政策内容
        /// </summary>
        public string TaxPreCon { get; set; }

        /// <summary>
        /// 零税率标志空:非零税率，0:出口退税，1:免税，2:不征收，3:普通零税率
        /// </summary>
        public string ZeroTax { get; set; }

        /// <summary>
        /// 企业自编码
        /// </summary>
        public string CropGoodsNo { get; set; }

        /// <summary>
        /// 扣除额，该字段可为空
        /// </summary>
        public string TaxDeduction { get; set; }
        #endregion
        
    }
}