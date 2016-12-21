using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.ComponentModel.DataAnnotations;
namespace TAS_SIUKDWStore.Models
{
public class Message
{
    public int MessageId { get; set; }
    public int UserId { get; set; }
    [Required]
    [DataType(DataType.MultilineText)]
    public string ContentMessage { get; set; }
    [Required]
    [DataType(DataType.Date)]
    public DateTime TimeMessage { get; set; }
    public string pict { get; set; }

        public virtual UserProfile UserProfiles { get; set; }
}
}