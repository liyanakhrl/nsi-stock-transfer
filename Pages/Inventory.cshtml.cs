using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using stock_transfer.Context;
using stock_transfer.Model;

namespace stock_transfer.Pages
{

    public class InventoryModel : PageModel
    {
        public List<InventorySummary> InventorySummary { get; set; }
        public List<Store> Store { get; set; }
        public Pagination Pagination { get; set; }

        private readonly IConfiguration _configuration;
        private readonly EPO_DBContext _dbContext;

        public InventoryModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = new EPO_DBContext(_configuration);
        }

        public void OnGet(int pageNumber = 1, string searchInput = null)
        {
            int itemsPerPage = 10;
            int skip = (pageNumber - 1) * itemsPerPage;

            string storeID = HttpContext.Request.Query["StoreID"];
            string whereClauseA = storeID != null ? "WHERE a.ShopID = '" + storeID + "' " : "";
            string whereClauseB = storeID != null ? "WHERE b.ShopID = '" + storeID + "' " : "";
            string whereClauseC = storeID != null ? "WHERE c.ShopID = '" + storeID + "' " : "";
            string whereClauseD = storeID != null ? "WHERE d.ShopID = '" + storeID + "' " : "";
            string whereClauseE = storeID != null ? "WHERE e.ShopID = '" + storeID + "' " : "";
            string whereClauseF = storeID != null ? "WHERE f.ShopID = '" + storeID + "' " : "";

            var query = $"SELECT * FROM [epo_dev].[dbo].[GRN_InventorySummary_PLU] as a " + whereClauseA +
                         $" UNION ALL " +
                         $" SELECT * FROM [epo_dev].[dbo].[GRN_InventorySummary_002] as b " + whereClauseB +
                         $" UNION ALL " +
                         $" SELECT * FROM [epo_dev].[dbo].[GRN_InventorySummary_003] as c " + whereClauseC +
                         $" UNION ALL " +
                         $" SELECT * FROM [epo_dev].[dbo].[GRN_InventorySummary_004] as d " + whereClauseD +
                         $" UNION ALL " +
                         $" SELECT * FROM [epo_dev].[dbo].[GRN_InventorySummary_002_1] as e " + whereClauseE +
                         $" UNION ALL " +
                         $" SELECT * FROM [epo_dev].[dbo].[GRN_InventorySummary_003_1] as f " + whereClauseF +
                         $" ORDER BY Description " +
                         $" OFFSET {skip} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";




            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                _dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    InventorySummary = new List<InventorySummary>();

                    while (reader.Read())
                    {
                        var inventorySummary = new InventorySummary();
                        inventorySummary.ID = reader.GetInt64(reader.GetOrdinal("ID"));
                        inventorySummary.Barcode = reader.GetString(reader.GetOrdinal("Barcode"));
                        inventorySummary.Type = reader.GetString(reader.GetOrdinal("Type"));
                        inventorySummary.Description = reader.GetString(reader.GetOrdinal("Description"));
                        inventorySummary.Department_Code = reader.GetString(reader.GetOrdinal("Department_Code"));
                        inventorySummary.OpeningQty = reader.GetDecimal(reader.GetOrdinal("OpeningQty"));
                        inventorySummary.ClosingQty = reader.GetDecimal(reader.GetOrdinal("ClosingQty"));
                        inventorySummary.Transfer_InQty = reader.GetDecimal(reader.GetOrdinal("Transfer_InQty"));
                        inventorySummary.Transfer_OutQty = reader.GetDecimal(reader.GetOrdinal("Transfer_OutQty"));
                        inventorySummary.Sellprice_1 = reader.GetDecimal(reader.GetOrdinal("Sellprice_1"));
                        inventorySummary.ShopID = reader.GetString(reader.GetOrdinal("ShopID"));

                        InventorySummary.Add(inventorySummary);
                    }
                }
            }

            var storeQuery = "SELECT * FROM [dbo].[MF_Store]";
            storeQuery = storeQuery.Replace(Environment.NewLine, "").Replace("\r", "").Replace("\n", ""); // Remove line breaks

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = storeQuery;
                command.CommandType = CommandType.Text;

                _dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    Store = new List<Store>();

                    while (reader.Read())
                    {
                        var store = new Store();

                        store.Store_ID = reader.GetInt32(reader.GetOrdinal("Store_ID"));
                        store.Store_Code = reader.GetString(reader.GetOrdinal("Store_Code"));
                        store.Store_Name = reader.GetString(reader.GetOrdinal("Store_Name"));
                        store.Tel1 = reader.GetString(reader.GetOrdinal("Tel1"));

                        Store.Add(store);
                    }
                }
            }
        }
    }
}
