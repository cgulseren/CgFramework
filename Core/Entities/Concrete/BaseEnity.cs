using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Core.Entities.Concrete
{
    public abstract partial class BaseEntity<T>
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Key]
        public T Id { get; set; }
    }
}
