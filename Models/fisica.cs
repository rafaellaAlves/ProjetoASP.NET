//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace ProjetoASP.NET.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class fisica
    {
        public string rg { get; set; }
        public string cpf { get; set; }
        public int id_cliente { get; set; }
    
        public virtual cliente cliente { get; set; }
    }
}
