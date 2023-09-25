using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stock_transfer.Model
{

    public class InventorySummary
    {
        public Int64 ID { get; set; }
        public string PLU_Code { get; set; }
        public string Barcode { get; set; }
        public string Linkcode { get; set; }
        public string Type { get; set; }
        public decimal Packsize { get; set; }
        public string Description { get; set; }
        public string ShortDescription { get; set; }
        public string Department_Code { get; set; }
        public DateTime OpeningDate { get; set; }
        public decimal OpeningQty { get; set; }
        public decimal OpeningAmt { get; set; }
        public decimal ReceiveQty { get; set; }
        public decimal ReceiveAmt { get; set; }
        public decimal ReturnQty { get; set; }
        public decimal ReturnAmt { get; set; }
        public decimal Transfer_InQty { get; set; }
        public decimal Transfer_InAmt { get; set; }
        public decimal Transfer_OutQty { get; set; }
        public decimal Transfer_OutAmt { get; set; }
        public decimal SalesQty { get; set; }
        public decimal SalesCost { get; set; }
        public int CustomerReturnQty { get; set; }
        public decimal CustomerReturnAmt { get; set; }
        public decimal AdjustmentQty { get; set; }
        public decimal AdjustmentAmt { get; set; }
        public decimal DisposalQty { get; set; }
        public decimal DisposalAmt { get; set; }
        public decimal ClosingQty { get; set; }
        public decimal ClosingAmt { get; set; }
        public decimal SalesQty30 { get; set; }
        public decimal LastCost { get; set; }
        public decimal Sellprice_1 { get; set; }
        public string ShopID { get; set; }
        public DateTime ModifyDate { get; set; }
    }
}
