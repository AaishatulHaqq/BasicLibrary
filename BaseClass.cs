using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicLibrary
{
    public abstract class BaseClass
    {
        public int Id { get; set; }
        public DateTime AddedOn { get; set; }
        public DateTime BorrowedOn { get; set; }
        public DateTime ReturnedOn { get; set; }

    }
}