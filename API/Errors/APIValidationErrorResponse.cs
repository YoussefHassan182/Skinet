using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace API.Errors
{
    public class APIValidationErrorResponse : APIResponse
    {
        public IEnumerable<string> Errors {set;get;}
        public APIValidationErrorResponse() : base(400)
        {
        }
    }
}