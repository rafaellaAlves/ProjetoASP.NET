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
    
    public partial class cliente
    {
        public int id_cliente { get; set; }
        public string nome { get; set; }
        public string email { get; set; }
        public string telefone { get; set; }
        public string endereco { get; set; }
        public string uf { get; set; }
        public string cidade { get; set; }
    
        public virtual fisica fisica { get; set; }
        public virtual juridica juridica { get; set; }
    }
}