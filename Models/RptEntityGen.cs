using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class RptEntityGen
    {
        public class RptResourceInfo
        {
            public int Slnum { get; set; }

            public int InvoiceNumber { get; set; }

            public DateTime SaleDate { get; set; }
            public string CustomerName { get; set; }
            public string Product { get; set; }
            public int Quantity { get; set; }
            public decimal UnitPrice { get; set; }
            public decimal Discount { get; set; }

            public RptResourceInfo(int _slnum, int invoiceNumber,string customerName, string product, DateTime saleDate, int quantity, decimal unitPrice, decimal discount)
            {
                Slnum = _slnum;
                InvoiceNumber = invoiceNumber;
                CustomerName = customerName;
                Product = product;
                SaleDate = saleDate;
                Quantity = quantity;
                UnitPrice = unitPrice;
                Discount = discount;
            }

        }
    }
}
