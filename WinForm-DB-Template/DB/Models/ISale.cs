using System;
using System.Collections.Generic;

namespace WinForm_DB_Template.DB.Models;

public partial class ISale
{
    public int SalesId { get; set; }

    public DateTime? SalesDateTime { get; set; }

    public int? StoreId { get; set; }
}
