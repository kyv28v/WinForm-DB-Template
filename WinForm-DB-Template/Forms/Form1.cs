using System.Diagnostics;
using WinForm_DB_Template.DB.Models;

namespace WinForm_DB_Template
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                using (var context = new TestContext())
                {
                    //dataGridView1.DataSource = context.MItems.ToList();
                    dataGridView1.DataSource = context.ISales
                        .Join(context.ISalesDetails, x => x.SalesId, y => y.SalesId, (x, y) => new { sales = x, detail = y })
                        .Join(context.MStores, x => x.sales.StoreId, y => y.StoreId, (x, y) => new { x.sales, x.detail, store = y })
                        .Join(context.MItems, x => x.detail.ItemId, y => y.ItemId, (x, y) => new { x.sales, x.detail, x.store, item = y })
                        .Select(x => new
                        {
                            x.sales.SalesId,
                            x.sales.SalesDateTime,
                            x.sales.StoreId,
                            x.store.StoreName,
                            x.detail.DetailSeqNo,
                            x.detail.ItemId,
                            x.item.ItemName,
                            x.item.ItemPrice,
                            x.detail.PurchaseQuantity,
                            Total = x.item.ItemPrice * x.detail.PurchaseQuantity,
                        })
                        .ToList();
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.ToString());
            }
        }
    }
}
