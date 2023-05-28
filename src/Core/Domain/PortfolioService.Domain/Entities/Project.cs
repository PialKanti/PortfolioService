using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PortfolioService.Domain.Entities
{
    public class Project
    {
        public string Name { get; set; }
        public string ProjectUrl { get; set; }
        public IEnumerable<string> DescriptionList { get; set; }
        public IEnumerable<string> Skills { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
    }
}
