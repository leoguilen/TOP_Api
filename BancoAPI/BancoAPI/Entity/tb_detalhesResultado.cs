//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace BancoAPI.Entity
{
    using System;
    using System.Collections.Generic;
    
    public partial class tb_detalhesResultado
    {
        public int userResult_in_id { get; set; }
        public int testResult_in_id { get; set; }
        public int curResult_in_id { get; set; }
        public Nullable<int> result_dt_tempo { get; set; }
        public double result_re_pontosExatas { get; set; }
        public double result_re_pontosHumanas { get; set; }
        public double result_re_pontosBiologicas { get; set; }
    
        public virtual tb_curso tb_curso { get; set; }
        public virtual tb_teste tb_teste { get; set; }
        public virtual tb_usuario tb_usuario { get; set; }
    }
}
