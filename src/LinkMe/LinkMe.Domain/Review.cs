using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkMe.Domain
{
    public class Review : DomainEntity
    {
        public Member Reviewer { get; set; }
        public byte Rating { get; set; }
        public string Comment { get; set; }
    }
}
