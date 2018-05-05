using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibraryProject0
{
    public interface IEntity
    {
        int Id { get; set; }
        DateTime Created { get; set; }
        DateTime Modified { get; set; }
        //Usually include fields for a created by and a modified by field
    }
}
