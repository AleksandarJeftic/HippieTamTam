using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace HippieTamTam.Models
{
    public class LaysCatsPost
    {
        public List<Category> Categories { get; set; }
        public List<Layout> Layouts { get; set; }
        public Post Post { get; set; }
    }
}