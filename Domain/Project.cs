using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Project
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Description { get; set; } = string.Empty;

        public string Status { get; set; } = string.Empty;
    }
}