using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Domain
{
    public class Tasks
    {
        public Tasks()
        {
            Name = string.Empty;
            Status = string.Empty;
        }


        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Name { get; set; }

        [ForeignKey("Project")]
        public int ProjectId { get; set; }

        public string Status { get; set; }
    }
}