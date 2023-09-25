using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stock_transfer.Model
{
    public class Item
    {
        [Key] // This annotation specifies Store_ID as the primary key
        public int Item_ID { get; set; }
        public string? Item_Code { get; set; }
        public string? Barcode { get; set; }
        public string? LinkCode { get; set; }
        public int Type { get; set; }
        public string? LongDesc { get; set; }
        public string? ShortDesc { get; set; }
        public string? OtherDesc { get; set; }
        public string? Category_Code { get; set; }
        public decimal? PackSize { get; set; }
        public string? UOM { get; set; }
        public string? IsSerialize { get; set; }
        public string? PurchaseTax { get; set; }
        public string? SalesTax { get; set; }
        public string? IsRedemption { get; set; }
        public decimal? RedemptionPoint { get; set; }
        public byte[]? Image { get; set; }
        public string? Modifier_Group { get; set; }
        public string? Re_RefNo { get; set; }
        public DateTime? Created_DT { get; set; }
        public DateTime? Modified_DT { get; set; }
        public string? DeleteInd { get; set; }
        public string? views { get; set; }
        public string? merchant_id { get; set; }
        public string? Temp_ID { get; set; }
        public string? FilePath { get; set; }
        public decimal? future_price { get; set; }
    }

}
