using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace TorrentSite.Models
{
    public class Category
    {
        public Category()
        {
            this.Torrent = new HashSet<Torrent>();
        }

        public int Id { get; set; }

        public string Name { get; set; }

        public int CatalogueId { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual IEnumerable<Torrent> Torrent { get; set; }

        //Movie_Action,
        //Movie_Animation,
        //Movie_Anime,
        //Movie_Asian,
        //Movie_Biographic,
        //Movie_Bulgarian,
        //Movie_War,
        //Movie_Documentary,
        //Movie_Drama,
        //Movie_European,
        //Movie_Erotic,
        //Movie_Hindi,
        //Movie_History,
        //Movie_Comedy,
        //Movie_Concert,
        //Movie_Crime,
        //Movie_Mystery,
        //Movie_Musical,
        //Movie_Parody,
        //Movie_Adventure,
        //Movie_Psycho,
        //Movie_Romance,
        //Movie_Family,
        //Movie_Sport,
        //Movie_Thriller,
        //Movie_Western,
        //Movie_Horror,
        //Movie_Sci_Fi,
        //Movie_Fantasy,
        //Game_3D_Action,
        //Game_FPS,
        //Game_MMORPG,
        //Game_RPG,
        //Game_Fighting,
        //Game_Action,
        //Game_Fun,
        //Game_Quest,
        //Game_Logical,
        //Game_Manager,
        //Game_Adventure,
        //Game_Simulatior,
        //Game_Sport,
        //Game_Strategy,
        //Game_Racing,
        //Game_Tactical,
        //Game_Psycho,
        //Game_Hentai,
    }
}
