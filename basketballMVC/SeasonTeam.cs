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
    
    public partial class SeasonTeam
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SeasonTeam()
        {
            this.Games = new HashSet<Game>();
            this.Games1 = new HashSet<Game>();
            this.Rosters = new HashSet<Roster>();
        }
    
        public int SeasonTeamID { get; set; }
        public int SeasonID { get; set; }
        public int TeamID { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Game> Games1 { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Roster> Rosters { get; set; }
        public virtual Season Season { get; set; }
        public virtual Team Team { get; set; }
    }
}
