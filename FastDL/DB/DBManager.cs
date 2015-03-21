using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.SqlServerCe;
using System.Collections;
using System.Data;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;

namespace FastDL.DB
{
    public class DBManager
    {
        private string _connectionString = "Data Source=" + Application.StartupPath + "\\db.sdf; password=";

        static SqlCeConnection _handler = null;

        public DBManager()
        {
            if (File.Exists(Application.StartupPath + "\\db.sdf"))
            {
                if (_handler == null)
                {
                    
                    _handler = new SqlCeConnection(_connectionString);
                    _handler.Open();
                }
            }
            else
            {
                MessageBox.Show("Pas de fichier de db ... t'as fait de la merde");
            }
        }

        public void addDownload(ref DBDownload data)
        {
            using (SqlCeCommand com = new SqlCeCommand("INSERT INTO download(url, name, path, size, header, start_date) VALUES(@url, @name, @path, @size, @header, @start_date)", _handler))
            {
                com.Parameters.AddWithValue("@url", data.url);
                com.Parameters.AddWithValue("@name", data.name);
                com.Parameters.AddWithValue("@path", data.path);
                com.Parameters.AddWithValue("@size", data.size);
                com.Parameters.AddWithValue("@header", data.header);
                com.Parameters.AddWithValue("@start_date", DateTime.Now);
                com.ExecuteNonQuery();
                com.CommandText = "SELECT @@IDENTITY";
                data.id = Convert.ToInt32(com.ExecuteScalar());
            }
        }

        public bool exists(string url)
        {
            int nb = 0;
            using (SqlCeCommand com = new SqlCeCommand("SELECT COUNT(*) FROM download where url=@url", _handler))
            {
                com.Parameters.AddWithValue("@url", url);
                nb = Convert.ToInt32(com.ExecuteScalar());
            }
            if ((nb > 0))
            {
                return true;
            }
            return false;
        }

        public int addChunk(int downloadId, Int64 start_byte, Int64 end_byte)
        {
            int chunk_id = 0;
            using (SqlCeCommand com = new SqlCeCommand("INSERT INTO chunk(down_id, start_byte, end_byte, downloading, owned) VALUES(@down_id, @start_byte, @end_byte, @downloading, @owned)", _handler))
            {
                com.Parameters.AddWithValue("@down_id", downloadId);
                com.Parameters.AddWithValue("@start_byte", start_byte);
                com.Parameters.AddWithValue("@end_byte", end_byte);
                com.Parameters.AddWithValue("@downloading", 0);
                com.Parameters.AddWithValue("@owned", 0);
                chunk_id = Convert.ToInt32(com.ExecuteScalar());
            }
            return chunk_id;
        }

        public DBChunk getNext(DBDownload data)
        {
            DBChunk chunk = default(DBChunk);
            using (SqlCeCommand com = new SqlCeCommand("SELECT * FROM chunk WHERE downloading = 0 AND owned = 0 and down_id = " + data.id + " ORDER BY start_byte", _handler))
            {
                SqlCeDataReader dr = com.ExecuteReader();
                if (dr.Read())
                {
                    using (SqlCeCommand com2 = new SqlCeCommand("UPDATE chunk SET downloading = 1 WHERE id=@id", _handler))
                    {
                        com2.Parameters.AddWithValue("@id", Convert.ToInt32(dr.GetInt32(0)));
                        int result = com2.ExecuteNonQuery();
                        if ((result != 1))
                        {
                            MessageBox.Show("fail");
                        }
                    }
                    chunk = new DBChunk();
                    chunk.id = (int)(dr.GetSqlInt32(0));
                    chunk.down_id = (int)(dr.GetSqlInt32(1));
                    chunk.start_byte = (long)(dr.GetSqlInt64(2));
                    chunk.end_byte = (long)(dr.GetSqlInt64(3));
                    //MessageBox.Show(dr.GetFieldType(4).ToString());
                    /*chunk.downloading = */
                    //if (dr.GetByte(3))
                    //{
                    //    chunk.downloading = 1;
                    //}
                    //else
                    //{
                    //    chunk.downloading = 0;
                    //}
                    
                    //chunk.owned = (int)(dr.GetValue(5));

                }
                else
                {
                    chunk = null;
                }
            }

            return chunk;
        }

        public List<DBDownload> getAllDownloads()
        {
            List<DBDownload> downloads = new List<DBDownload>();
            DBDownload download;
                        DBChunk tmp;
            List<DBChunk> chunks;

            using (SqlCeCommand comdl = new SqlCeCommand("SELECT * FROM download ORDER BY start_date", _handler))
            {
                SqlCeDataReader drd = comdl.ExecuteReader();
                while (drd.Read())
                {
                    download = new DBDownload();
                    download.id = (int)(drd.GetSqlInt32(0));
                    download.url = (string)(drd.GetSqlString(1));
                    download.name = (string)(drd.GetSqlString(2));
                    download.path = (string)(drd.GetSqlString(3));
                    download.size = (long)(drd.GetSqlInt64(4));
                    download.header = (string)(drd.GetSqlString(5));
                    download.startDate = (DateTime)(drd.GetSqlDateTime(6));
                    download.endDate = (DateTime)(drd.GetSqlDateTime(7));

                    chunks = new List<DBChunk>();

                    using (SqlCeCommand comch = new SqlCeCommand("SELECT * FROM chunk WHERE down_id = " + download.id + " ORDER BY start_byte", _handler))
                    {
                        SqlCeDataReader dr = comch.ExecuteReader();
                        while (dr.Read())
                        {
                            tmp = new DBChunk();
                            tmp.id = (int)(dr.GetSqlInt32(0));
                            tmp.down_id = (int)(dr.GetSqlInt32(1));
                            tmp.start_byte = (long)(dr.GetSqlInt64(2));
                            tmp.end_byte = (long)(dr.GetSqlInt64(3));

                  
                            if (dr.IsDBNull(4))
                                tmp.downloading = 0;
                            else
                            tmp.downloading = (int)(dr.GetByte(4));
                            if (dr.IsDBNull(5))
                                tmp.owned = 0;
                            else
                                tmp.owned = (int)(dr.GetByte(5));
                        }
                    }
                    download.chunks = chunks;
                    downloads.Add(download);
                }
            }
            return downloads;
        }


        public void setDownloadingState(int chunk_id, bool state)
        {
            int b = state ? 1 : 0;
            using (SqlCeCommand com = new SqlCeCommand("UPDATE chunk SET downloading = " + b + " WHERE id=@id", _handler))
            {
                com.Parameters.AddWithValue("@id", chunk_id);
                com.ExecuteNonQuery();
            }
        }

        public void setOwnedState(int chunk_id, bool state)
        {
            int b = state ? 1 : 0;
            using (SqlCeCommand com = new SqlCeCommand("UPDATE chunk SET owned = " + b + " WHERE id=@id", _handler))
            {
                com.Parameters.AddWithValue("@id", chunk_id);
                com.ExecuteNonQuery();
            }
        }

        public void endDownload(int down_id)
        {
            using (SqlCeCommand com = new SqlCeCommand("UPDATE download SET end_date=@end_date WHERE id=@id", _handler))
            {
                com.Parameters.AddWithValue("@end_date", DateTime.Now);
                com.Parameters.AddWithValue("@id", down_id);
                com.ExecuteNonQuery();
            }
        }

        public void deleteAllDownloads()
        {
            using (SqlCeCommand com = new SqlCeCommand("DELETE FROM download", _handler))
            {
                com.ExecuteNonQuery();
            }

            using (SqlCeCommand com = new SqlCeCommand("DELETE FROM chunk", _handler))
            {
                com.ExecuteNonQuery();
            }
        }

        //Protected Overrides Sub finalize()
        //    If _handler.State() = ConnectionState.Broken Or _handler.State = ConnectionState.Closed Then
        //        MsgBox("""Connexion à la BDD fermée de facon INNOOPIné"" Gad Elmaleh")
        //    Else
        //        While _handler.State <> ConnectionState.Open
        //            System.Threading.Thread.Sleep(10)
        //        End While
        //        _handler.Close()
        //    End If
        //End Sub

    }

}
