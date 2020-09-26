using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaBancario.Domain.Models
{
    public class BaseModel
    {
        [Key]
        [Column("id")]
        public Guid Id { get; set; }

        private DateTime _createdAt;

        [Column("created_at")]
        public DateTime CreatedAt
        {
            get { return _createdAt; }
            set { _createdAt = DateTime.UtcNow; }
        }
        
        [Column("updated_at")]
        public DateTime? UpdatedAt { get; set; }
    }
}
