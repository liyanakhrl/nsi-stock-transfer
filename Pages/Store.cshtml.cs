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
    public class StoreModel : PageModel
    {
        public List<InventorySummary> InventorySummary { get; set; }
        public List<Store> Store { get; set; }
        public Pagination Pagination { get; set; }

        private readonly IConfiguration _configuration;
        private readonly EPO_DBContext _dbContext;

        public StoreModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = new EPO_DBContext(_configuration);
        }
        public void OnGet()
        {
            var query = "SELECT * FROM [dbo].[MF_Store]";
            query = query.Replace(Environment.NewLine, "").Replace("\r", "").Replace("\n", ""); // Remove line breaks

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
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
