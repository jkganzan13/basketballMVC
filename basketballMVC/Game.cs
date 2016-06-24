//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace basketballMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Game
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Game()
        {
            this.Stats = new HashSet<Stat>();
        }
    
        public int GameID { get; set; }
        public Nullable<System.TimeSpan> GameTime { get; set; }
        public System.DateTime GameDate { get; set; }
        public int Team1_ID { get; set; }
        public int Team2_ID { get; set; }
        public int Team1_score { get; set; }
        public int Team2_score { get; set; }
        public string GameDesc { get; set; }
    
        public virtual SeasonTeam SeasonTeam { get; set; }
        public virtual SeasonTeam SeasonTeam1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Stat> Stats { get; set; }
    }
}