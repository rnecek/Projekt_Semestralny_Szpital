//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjektSemestralny
{
    using System;
    using System.Collections.Generic;
    
    public partial class Wizyty
    {
        public int Id { get; set; }
        public Nullable<int> DoktorID { get; set; }
        public Nullable<int> PacjentID { get; set; }
        public Nullable<System.DateTime> DataWizyty { get; set; }
        public Nullable<System.DateTime> GodzinaWizyty { get; set; }
    
        public virtual Doktorzy Doktorzy { get; set; }
        public virtual Pacjenci Pacjenci { get; set; }
    }
}
