//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace FoodAPI.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Food
    {
        public int FoodID { get; set; }
        public string FoodDescription { get; set; }
        public int FoodTypeID { get; set; }
        public int FoodColourID { get; set; }
    
        public virtual FoodColour FoodColour { get; set; }
        public virtual FoodType FoodType { get; set; }
    }
}
