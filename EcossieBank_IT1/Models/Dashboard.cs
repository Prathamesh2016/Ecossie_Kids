//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace EcossieBank_IT1.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class Dashboard
    {

        public int ID { get; set; }
        
        public string name { get; set; }
        public Nullable<int> total_score { get; set; }
        public Nullable<int> quiz1_score { get; set; }
        public Nullable<int> quiz2_score { get; set; }
        public Nullable<int> quiz3_score { get; set; }
        public string badge { get; set; }
    }
}
