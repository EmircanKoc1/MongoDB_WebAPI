using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Xsl;

namespace Core.Exceptions
{
    public class EntityNotFoundException  : Exception
    {
        public EntityNotFoundException(string message = "MessageNotAdded") : base(message) 
        {
            
        }
    }
}
