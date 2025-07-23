using System;
using System.Collections.Generic;

namespace WinForm_DB_Template.DB.Models;

public partial class MStore
{
    public int StoreId { get; set; }

    public string? StoreName { get; set; }

    public string? Place { get; set; }

    public string? Note { get; set; }
}
