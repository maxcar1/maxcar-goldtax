#region << 版 本 注 释 >>
/**
 * 文件名： ComHelper.cs
 *【功 能】
 *  接口操作
 *  
 *   版本       变更时间     部门    作者             变更内容
 * ──────────────────────────────────
 *   V2.0.0     2015-04-12           陈嘉俊           初版
 *   V2.1.0     2016-05-16           陈嘉俊           更新营改增后内容
 *
 * Copyright(c)2012 ZhejiangAisino All Rights Reserved.
 * LICENSE INFORMATION
 */

#endregion

using System;

namespace maxcar_goldtax.utils {
    public abstract class ComHelper {
        public static dynamic m_GoldTax;    //接口组件
        protected static dynamic m_RepInvoice; //申报组件
        protected static dynamic m_RepSegment; //发票领用存(申报组件)

        /// <summary>
        /// 关闭金税盘
        /// </summary>
        public static void CloseCard() {
            if (m_GoldTax != null) {
                m_GoldTax.CloseCard();

                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(m_GoldTax);
                m_GoldTax = null;
            }

            if (m_RepInvoice != null) {
                m_RepInvoice.DisconnectKP();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(m_RepInvoice);
                m_RepInvoice = null;
            }

            if (m_RepSegment != null) {
                m_RepSegment.DisconnectKP();
                System.Runtime.InteropServices.Marshal.FinalReleaseComObject(m_RepSegment);
                m_RepSegment = null;
            }

            GC.Collect();
        }
    }
}