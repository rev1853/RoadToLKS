//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FileManagement
{
    using System;
    using System.Collections.Generic;
    
    public partial class FightHistory
    {
        public int ID { get; set; }
        public int Hero1ID { get; set; }
        public int Hero2ID { get; set; }
        public double Hero1TotalPower { get; set; }
        public double Hero2TotalPower { get; set; }
        public System.DateTime FightDate { get; set; }
    }
}
