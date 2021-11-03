using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore.SqlServer;
using WSAuto.Data;
using System.ComponentModel.DataAnnotations.Schema;

namespace WSAuto.Models
{
    [Table("Vehiculo")]
    
    public class Auto
    {
        [Required]
        public int Id { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Marca { get; set; }

        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Modelo { get; set; }
        [Required]
        [Column(TypeName = "varchar")]
        [MaxLength(50)]
        public string Color { get; set; }
        [Column(TypeName = "money")]
        
        public decimal Precio { get; set; }


    }
}
