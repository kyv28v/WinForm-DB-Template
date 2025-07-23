using System;
using System.Collections.Generic;

namespace WinForm_DB_Template.DB.Models;

public partial class MItem
{
    public int ItemId { get; set; }

    public string? ItemName { get; set; }

    public int? ItemPrice { get; set; }

    public DateTime? ReleaseDate { get; set; }
}
