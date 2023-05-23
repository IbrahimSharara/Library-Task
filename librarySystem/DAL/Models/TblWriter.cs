﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.EntityFrameworkCore;

namespace Libirary.DAL.Models
{
    [Table("tbl_Writer")]
    public partial class TblWriter
    {
        public TblWriter()
        {
            TblBook = new HashSet<TblBook>();
        }

        [Key]
        [Column("WriteID")]
        public int WriteId { get; set; }
        [StringLength(250)]
        public string WriterName { get; set; }

        [InverseProperty("BookWriterNavigation")]
        public virtual ICollection<TblBook> TblBook { get; set; }
    }
}