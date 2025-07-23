using System;
using System.Collections.Generic;

namespace WinForm_DB_Template.DB.Models;

public partial class ISalesDetail
{
    public int SalesId { get; set; }

    public int DetailSeqNo { get; set; }

    public int? ItemId { get; set; }

    public int? PurchaseQuantity { get; set; }
}
