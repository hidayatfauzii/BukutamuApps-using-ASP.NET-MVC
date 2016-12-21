using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TAS_SIUKDWStore.ViewModels
{
    public class MessageViewModel

    {
        public int MessageId { get; set; }
        public int UserId { get; set; }
        public string ContentMessage { get; set; }
        public DateTime TimeMessage { get; set; }

        public string UserName { get; set; }
    }
}