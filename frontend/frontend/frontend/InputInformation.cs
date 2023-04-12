using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace frontend
{
    internal class InputInformation
    {
        public string config;
        public int[] info;
        public InputInformation() { }
        public InputInformation(string config)
        {
            this.config = config;
            this.info = new int[] { };
        }
        public InputInformation(string config, int[] info)
        {
            this.config = config;
            this.info = info;
        }
        public override string ToString()
        {
            return $"Config:{config}, Info:{info.ToString()}";
        }
    }
}
