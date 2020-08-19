using System;
using System.Collections.Generic;
using System.Text;

namespace ArtistData.Models
{
   public class Release
    {
       public int  Id { get; set; }
       public Guid Gid { get; set; }
       public string Name { get; set; }
       public int Artist_credit { get; set; }

       public int  Release_group { get; set; }
       public int? Status { get; set; }
       public int? Packaging { get; set; }
       public int ? Language { get; set; }
       public int ? Script { get; set; }
       public string  Barcode { get; set; }
       public string  Comment { get; set; }
       public int? Edits_pending { get; set; }
       public int? Quality { get; set; }
       public DateTime? Last_updated { get; set; }
}
}
