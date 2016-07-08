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
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;
    public partial class Season
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Season()
        {
            this.SeasonTeams = new HashSet<SeasonTeam>();
        }
    
        public int SeasonID { get; set; }
        [DisplayName("Season Start"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public System.DateTime SeasonStart { get; set; }
        [DisplayName("Season End"), DataType(DataType.Date), DisplayFormat(DataFormatString = "{0:dd MMMM yyyy}")]
        public Nullable<System.DateTime> SeasonEnd { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SeasonTeam> SeasonTeams { get; set; }
    }
}
