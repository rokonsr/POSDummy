using System;

namespace POS.Model
{
    public class Sales
    {
        public int SaleId { get; set; }
        public int ProductId { get; set; }
        public float SaleQuantity { get; set; }
        public float SalePrice { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public float Stock { get; set; }
    }
}
