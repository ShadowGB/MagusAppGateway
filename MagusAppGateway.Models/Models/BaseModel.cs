using System;
using System.ComponentModel.DataAnnotations;

namespace MagusAppGateway.Models
{
    public class BaseModel
    {
        [Key]
        public Guid Id { get; set; }
    }
}
