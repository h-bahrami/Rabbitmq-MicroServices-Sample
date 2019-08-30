using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface IService2Request
    {
        public int Id { get; }

        public string Name { get; set; }
    }
}
