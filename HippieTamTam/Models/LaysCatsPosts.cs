using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace HippieTamTam.Models
{
    public class LaysCatsPosts
    {
        public List<Category> Categories { get; set; }
        public List<Layout> Layouts { get; set; }
        public List<Post> Posts { get; set; }

        [Required(ErrorMessage ="Moraš izabrati kategoriju")]
        public int SelectedCategory { get; set; }

        [Required(ErrorMessage = "Moraš izabrati layout")]
        public int SelectedLayout { get; set; }

        [Required(ErrorMessage = "Moraš izabrati post")]
        public int SelectedPost { get; set; }

        [Required(ErrorMessage = "Moraš izabrati kategoriju")]
        public int SelectedCatOfPosts { get; set; }
    }
}