using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace POS.Model
{
    public class Product
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public float Stock { get; set; }
        public int MeasurementId { get; set; }
        public string MeasurementName { get; set; }
        public float PurchasePrice { get; set; }
        public float SalePrice { get; set; }
    }
}
