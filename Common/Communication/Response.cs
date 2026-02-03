using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common.Communication
{
    [Serializable]
    public class Response
    {
        public object Result { get; set; }
        public string ExceptionMessage { get; set; }
        public string ExceptionType { get; set; }
        public bool IsSuccess => string.IsNullOrEmpty(ExceptionMessage);
    }
}
