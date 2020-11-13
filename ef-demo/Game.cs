using System;
using System.Collections.Generic;

namespace ef_demo
{
    public class Game
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public List<Review> Reviews { get; set; }
        public string Name { get; set; }

        public Guid Etag { get; set; }
    }
}