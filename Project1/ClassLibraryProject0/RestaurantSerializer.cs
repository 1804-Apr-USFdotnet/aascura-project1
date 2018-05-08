using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ClassLibraryProject0
{
    static class RestaurantSerializer
    {
        public static Restaurant DeserializeRestaurant(string jsonString)
        {
            MemoryStream ms = new MemoryStream();
            Restaurant toDeserialize;

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restaurant));
                byte[] bytes = Encoding.ASCII.GetBytes(jsonString);
                ms.Write(bytes, 0, Encoding.ASCII.GetByteCount(jsonString));
                ms.Position = 0;
                toDeserialize = (Restaurant)ser.ReadObject(ms);
             }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
            return toDeserialize;
        }

        public static string SerializeRestaurant(string targetFile, Restaurant toWrite)
        {
            string jsonString;

            MemoryStream ms = new MemoryStream();

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restaurant));
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                ser.WriteObject(ms, toWrite);
                ms.Position = 0;
                jsonString = sr.ReadToEnd();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }

            return jsonString;
        }
    }
}
