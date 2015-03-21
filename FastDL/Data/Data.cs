using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace FastDL.Data
{
    public class Data
    {
        public long current;
        public byte[] buffer;
        public int read;
        public bool end = false;
        public Data(long cur, ref byte[] buf, int r)
        {
            current = cur;
            buffer = buf;
            read = r;
            end = false;
        }

        public Data()
        {
            end = true;
        }
    }
}
