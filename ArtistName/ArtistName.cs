using System;

namespace ArtistName
{
    public class ArtistName
    {
        public int Id { get; set; }
        public Guid Gid { get; set; }
        public string Name { get; set; }
        public string Sort_name { get; set; }
        public int? Type { get; set; }

       
        public int? Gender { get; set; }
        public string Comment { get; set; }
        

        public DateTime? Last_updated { get; set; }
       

    }
}
