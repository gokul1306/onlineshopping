//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Easybuy.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.ComponentModel.DataAnnotations;

    public partial class register
    {
        [Required(ErrorMessage="The field is required.")]
        public string username { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        public string email { get; set; }
        [Required(ErrorMessage = "The field is required.")]
        [DataType(DataType.Password)]
        public string password { get; set; }
        [DataType(DataType.Password)]
        [DisplayName("Confirmpassword")]
        [Compare("password")]
        public string confirmpassword { get; set; }
    }
}