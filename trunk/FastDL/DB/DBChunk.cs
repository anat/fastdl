using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net.NetworkInformation;

namespace FastDL.DB
{
public class DBChunk
{
	public int id;
	public int down_id;
	public Int64 start_byte;
	public Int64 end_byte;
	public int downloading;
	public int owned;
	public Int64 current_byte;
	public NetworkInterface adapter;
	public DBDownload dbd;
}
}


//using Microsoft.VisualBasic;
//using System;
//using System.Collections;
//using System.Collections.Generic;
//using System.Data;
//using System.Diagnostics;




