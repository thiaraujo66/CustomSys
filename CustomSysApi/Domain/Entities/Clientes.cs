﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Domain.Entities;

[Index("Clcgc", Name = "UC_CLCGC", IsUnique = true)]
public partial class Clientes
{
    [Key]
    [Column("CLID")]
    [StringLength(15)]
    [Unicode(false)]
    public string Clid { get; set; }

    [Required]
    [Column("CLNOME")]
    [StringLength(255)]
    [Unicode(false)]
    public string Clnome { get; set; }

    [Required]
    [Column("CLCGC")]
    [StringLength(18)]
    [Unicode(false)]
    public string Clcgc { get; set; }

    [Required]
    [Column("CLSEXO")]
    [StringLength(1)]
    [Unicode(false)]
    public string Clsexo { get; set; }

    [Column("CLCDENDERECO")]
    public int Clcdendereco { get; set; }

    [Column("CLEMAIL")]
    [StringLength(255)]
    [Unicode(false)]
    public string Clemail { get; set; }

    [Column("CLTELEFONE")]
    [StringLength(13)]
    [Unicode(false)]
    public string Cltelefone { get; set; }

    [Column("CLOBS")]
    [StringLength(255)]
    [Unicode(false)]
    public string Clobs { get; set; }

    [Column("CLEXCLUIDO")]
    public bool Clexcluido { get; set; }

    [Column("CLCDTIPOCLIENTE")]
    public int Clcdtipocliente { get; set; }

    [Column("CLCDSITUACAO")]
    public int Clcdsituacao { get; set; }

    [Column("CLNACIONALIDADE")]
    public int Clnacionalidade { get; set; }

    [Column("CLDTNASC", TypeName = "smalldatetime")]
    public DateTime Cldtnasc { get; set; }

    [Column("CLDTCAD", TypeName = "smalldatetime")]
    public DateTime Cldtcad { get; set; }

    [Column("CLCDUSUCAD")]
    public int Clcdusucad { get; set; }

    [Column("CLDTALT", TypeName = "smalldatetime")]
    public DateTime? Cldtalt { get; set; }

    [Column("CLCDUSUALT")]
    public int? Clcdusualt { get; set; }

    [ForeignKey("Clcdendereco")]
    [InverseProperty("Clientes")]
    public virtual Enderecos ClcdenderecoNavigation { get; set; }

    [ForeignKey("Clcdsituacao")]
    [InverseProperty("Clientes")]
    public virtual SituacaoCliente ClcdsituacaoNavigation { get; set; }

    [ForeignKey("Clcdtipocliente")]
    [InverseProperty("Clientes")]
    public virtual TipoCliente ClcdtipoclienteNavigation { get; set; }

    [ForeignKey("Clcdusualt")]
    [InverseProperty("ClientesClcdusualtNavigation")]
    public virtual Usuario ClcdusualtNavigation { get; set; }

    [ForeignKey("Clcdusucad")]
    [InverseProperty("ClientesClcdusucadNavigation")]
    public virtual Usuario ClcdusucadNavigation { get; set; }

    [ForeignKey("Clnacionalidade")]
    [InverseProperty("Clientes")]
    public virtual Nacionalidades ClnacionalidadeNavigation { get; set; }
}