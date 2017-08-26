using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippieTamTam.Models
{
    public class LaysCatsPosts
    {
        public List<Category> Categories { get; set; }
        public List<Layout> Layouts { get; set; }
        public List<Post> Posts { get; set; }
        public int CategoryID { get; set; }
        public int LayoutID { get; set; }
    }
}