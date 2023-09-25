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
    public class StockTransferModel : PageModel
    {
        public List<Masterfile_Items> Masterfile_Items { get; set; } 
        public Pagination Pagination { get; set; }

        private readonly IConfiguration _configuration;
        private readonly Masterfile_DBContext _dbContext;

        public StockTransferModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = new Masterfile_DBContext(_configuration);
        }

        public void OnGet(int pageNumber = 1, string searchInput = null)
        {
            int itemsPerPage = 10;
            int skip = (pageNumber - 1) * itemsPerPage;

            // Build the SQL query with a WHERE clause to filter by searchInput
            var query = $"SELECT * FROM [masterfile_dev].[dbo].[item] WHERE (ShortDesc LIKE '%{searchInput}%' OR LongDesc LIKE '%{searchInput}%') ORDER BY ShortDesc OFFSET {skip} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                _dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    Masterfile_Items = new List<Masterfile_Items>();

                    while (reader.Read())
                    {
                        var item = new Masterfile_Items();
                        item.Item_Code = reader.GetString(reader.GetOrdinal("Item_Code"));
                        item.LongDesc = reader.GetString(reader.GetOrdinal("LongDesc"));
                        item.Type = reader.GetString(reader.GetOrdinal("Type"));
                        item.Department_Code = reader.GetString(reader.GetOrdinal("Department_Code"));

                        Masterfile_Items.Add(item);
                    }
                }
            }

        }
    }

}
