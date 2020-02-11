using System;
using System.ComponentModel;
using System.Reflection;

namespace MyStatz.Models
{
    public enum ActivityEnum
    {
        [StringValue(" ")]
        NULL = 0,
        [StringValue("Very Low")]
        Very_Low = 1,
        [StringValue("Low")] 
        Low = 2,
        [StringValue("Medium")] 
        Medium  = 3,
        [StringValue("High")] 
        High = 4,
        [StringValue("Very High")] 
        Very_High = 5,
        [StringValue("Intense")] 
        Intense = 6
    }

    
}