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
    public class ItemsModel : PageModel
    {
        public List<Item> Item { get; set; }
        public Pagination Pagination { get; set; }

        private readonly IConfiguration _configuration;
        private readonly EPO_DBContext _dbContext;

        public ItemsModel(IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = new EPO_DBContext(_configuration);
        }

        public void OnGet(int pageNumber = 1, string searchInput = null)
        {
            int itemsPerPage = 10;
            int skip = (pageNumber - 1) * itemsPerPage;

            // Build the SQL query with a WHERE clause to filter by searchInput
            var query = $"SELECT * FROM [epo_dev].[dbo].[MF_Item] WHERE (Item_Code LIKE '%{searchInput}%' OR LongDesc LIKE '%{searchInput}%') ORDER BY Item_Code OFFSET {skip} ROWS FETCH NEXT {itemsPerPage} ROWS ONLY";

            using (var command = _dbContext.Database.GetDbConnection().CreateCommand())
            {
                command.CommandText = query;
                command.CommandType = CommandType.Text;

                _dbContext.Database.OpenConnection();

                using (var reader = command.ExecuteReader())
                {
                    Item = new List<Item>();

                    while (reader.Read())
                    {
                        var item = new Item();
                        item.Item_Code = reader.GetString(reader.GetOrdinal("Item_Code"));
                        item.LongDesc = reader.GetString(reader.GetOrdinal("LongDesc"));
                        item.LinkCode = reader.GetString(reader.GetOrdinal("LinkCode"));
                        item.Category_Code = reader.GetString(reader.GetOrdinal("Category_Code"));
                        item.UOM = reader.GetString(reader.GetOrdinal("UOM"));
                        item.Type = reader.GetInt32(reader.GetOrdinal("Type"));

                        Item.Add(item);
                    }
                }
            }

        }


    }

}
