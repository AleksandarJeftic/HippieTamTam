namespace HippieTamTam.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    

    [Table("Post")]
    public partial class Post
    {
        public int PostID { get; set; }

        [StringLength(200)]
        public string PostTitle { get; set; }

        [StringLength(100)]
        public string PostBackground { get; set; }

        [StringLength(10)]
        public string PostBackgroundColor { get; set; }

        [StringLength(200,ErrorMessage ="must be under 200 letters")]
        public string PostSubhead1 { get; set; }

        [StringLength(200)]
        public string PostSubhead2 { get; set; }

        [StringLength(200)]
        public string PostSubhead3 { get; set; }

        [StringLength(200)]
        public string PostSubhead4 { get; set; }

        [StringLength(200)]
        public string PostSubhead5 { get; set; }
        
        [StringLength(1000)]
        public string PostText1 { get; set; }
        
        [StringLength(1000)]
        public string PostText2 { get; set; }
        
        [StringLength(1000)]
        public string PostText3 { get; set; }
        
        [StringLength(1000)]
        public string PostText4 { get; set; }

        [StringLength(1000)]
        public string PostText5 { get; set; }

        [StringLength(1000)]
        public string PostText6 { get; set; }

        [StringLength(1000)]
        public string PostText7 { get; set; }

        [StringLength(1000)]
        public string PostText8 { get; set; }

        [StringLength(1000)]
        public string PostText9 { get; set; }

        [StringLength(1000)]
        public string PostText10 { get; set; }

        [StringLength(300)]
        public string PostQuote1 { get; set; }

        [StringLength(300)]
        public string PostQuote2 { get; set; }

        [StringLength(300)]
        public string PostQuote3 { get; set; }

        [StringLength(300)]
        public string PostQuote4 { get; set; }

        [StringLength(300)]
        public string PostQuote5 { get; set; }

        [StringLength(20)]
        public string PostVideo1 { get; set; }

        [StringLength(20)]
        public string PostVideo2 { get; set; }

        [StringLength(20)]
        public string PostVideo3 { get; set; }

        [StringLength(20)]
        public string PostVideo4 { get; set; }

        [StringLength(200)]
        public string PostBigImage1 { get; set; }

        [StringLength(200)]
        public string PostBigImage2 { get; set; }

        [StringLength(200)]
        public string PostBigImage3 { get; set; }

        [StringLength(200)]
        public string PostBigImage4 { get; set; }

        [StringLength(200)]
        public string PostBigImage5 { get; set; }

        [StringLength(200)]
        public string PostBigImageText1 { get; set; }

        [StringLength(200)]
        public string PostBigImageText2 { get; set; }

        [StringLength(200)]
        public string PostBigImageText3 { get; set; }

        [StringLength(200)]
        public string PostBigImageText4 { get; set; }

        [StringLength(200)]
        public string PostBigImageText5 { get; set; }

        [StringLength(200)]
        public string PostSmallImage1 { get; set; }

        [StringLength(200)]
        public string PostSmallImage2 { get; set; }

        [StringLength(200)]
        public string PostSmallImage3 { get; set; }

        [StringLength(200)]
        public string PostSmallImage4 { get; set; }

        [StringLength(200)]
        public string PostSmallImage5 { get; set; }

        public int? PostViewCount { get; set; }

        public DateTime PostDateCreated { get; set; }

        public int LayoutID { get; set; }

        public int CategoryID { get; set; }

        [StringLength(50)]
        public string PostAuthor { get; set; }

        public virtual Category Category { get; set; }

        public virtual Layout Layout { get; set; }
    }
}
