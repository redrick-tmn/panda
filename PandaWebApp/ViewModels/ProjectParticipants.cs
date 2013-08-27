using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace PandaWebApp.ViewModels
{
    public class ProjectParticipants
    {
        public IEnumerable<string> Photos { get; set; }

        public int Count { get; set; }

        public double AverageRate { get; set; }
    }
}