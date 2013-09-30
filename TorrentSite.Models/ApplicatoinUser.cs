using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TorrentSite.Models
{
    public class ApplicatoinUser : User
    {
        public long Uploaded { get; set; }

        public long Downloaded { get; set; }

        public virtual ICollection<Comment> Comments { get; set; }
    }
}
