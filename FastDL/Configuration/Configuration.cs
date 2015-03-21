//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Text;
//using System.Collections;
//using System.Runtime.Serialization.Formatters.Binary;
//using System.IO;

//public class Configuration
//{
//    protected static Hashtable _conf = null;

//    private static Hashtable getInstance()
//    {
//        if (_conf == null)
//            _conf = new Hashtable();
//        return _conf;
//    }

//    public static Object get(string key)
//    {
//        return Configuration.getInstance()[key];
//    }

//    public static void set(string key, object data)
//    {
//        if (Configuration.getInstance().ContainsKey(key))
//            Configuration.getInstance()[key] = data;
//        else
//            Configuration.getInstance().Add(key, data);
//    }

//    public static void write()
//    {
//        using (FileStream fs = new FileStream("Configuration.dl", FileMode.Create, FileAccess.Write, FileShare.None))
//            new BinaryFormatter().Serialize(fs, Configuration.getInstance());
//    }

//    public static void read()
//    {
//        using (FileStream fs = new FileStream("Configuration.dl", FileMode.Open, FileAccess.Write, FileShare.None))
//            _conf = (Hashtable)(new BinaryFormatter()).Deserialize(fs);
//    }
//    public static void setDefault()
//    {
//        _conf["block_size"] = 1048576 * 5;
//        _conf["age"]
//    }
//}
