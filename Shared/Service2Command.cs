using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public interface Service2Command
    {
        public int Id { get; }

        public string Name { get; set; }
    }
}
