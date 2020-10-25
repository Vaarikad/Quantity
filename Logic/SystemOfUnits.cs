using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class SystemOfUnits
    {
        private string name;

        public SystemOfUnits(string name = "") {
            this.name = name;
        }

        public string Name
        {
            get { return name ?? string.Empty; }
            set { name = value; }
        }
    }
}
