using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace stock_transfer.Model
{
    public class Store
    {
        [Key] // This annotation specifies Store_ID as the primary key
        public int Store_ID { get; set; } 
        public string Store_Code { get; set; } 
        public string Store_Name { get; set; } 
        public string Tel1 { get; set; } 
        public string Tel2 { get; set; } 
        public string Fax { get; set; }
         
        public string Email { get; set; } 
        public string PIC1 { get; set; } 
        public string Address1 { get; set; } 
        public string Address2 { get; set; } 
        public string Address3 { get; set; } 
        public string Address4 { get; set; } 
        public string GSTNo { get; set; }

        public string AllPrinter { get; set; }

        public string GST_Entitlement { get; set; } 
        public string GST_Type { get; set; }

        public decimal Longitutde { get; set; }

        public decimal Latitude { get; set; }

        public string CostApply { get; set; }

        public DateTime Created_DT { get; set; }

        public DateTime Modified_DT { get; set; }

        public string DeleteInd { get; set; }

        public decimal SalesTarget { get; set; }

        public string OutletRealTimeChecking_Phase2 { get; set; }

        public string Billing_Store_Name { get; set; }
    }

}
