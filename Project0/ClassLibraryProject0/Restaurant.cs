using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;
using System.IO;

namespace ClassLibraryProject0
{
    //[Serializable()]
    [DataContract]
    public class Restaurant //: ISerializable
    {
        [DataMember]
        string name;
        [DataMember]
        string address;
        [DataMember]
        string phoneNum;

        [DataMember]
        List<Review> reviews;

        public Restaurant(string name, string address, string phoneNum, List<Review> reviews)
        {
            this.name = (string)name.Clone();
            this.address = (string)address.Clone();
            this.phoneNum = (string)phoneNum.Clone();
            this.reviews = new List<Review>();

            foreach (Review current in reviews)
            {
                this.reviews.Add(new Review(current));
            }
        }

        public Restaurant(Restaurant toCopy)
        {
            name = (string)toCopy.name.Clone();
            address = (string)toCopy.address.Clone();
            phoneNum = (string)toCopy.phoneNum.Clone();
            reviews = new List<Review>();

            foreach (Review current in toCopy.reviews)
            {
                reviews.Add(new Review(current));
            }
        }

        public Restaurant(string jsonString)
        {
            MemoryStream ms = new MemoryStream();
            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restaurant));
                byte[] bytes = Encoding.ASCII.GetBytes(jsonString);
                ms.Write(bytes, 0,Encoding.ASCII.GetByteCount(jsonString));
                ms.Position = 0;
                Restaurant toCopy = (Restaurant)ser.ReadObject(ms);
                name = (string)toCopy.name.Clone();
                address = (string)toCopy.address.Clone();
                phoneNum = (string)toCopy.phoneNum.Clone();
                reviews = new List<Review>();
                foreach (Review current in toCopy.reviews)
                {
                    reviews.Add(new Review(current));
                }
            }
            catch (ArgumentNullException)
            {
                throw;
            }
            catch (EncoderFallbackException)
            {
                throw;
            }
            catch (ArgumentOutOfRangeException)
            {
                throw;
            }
            catch (IOException)
            {
                throw;
            }
            catch (ObjectDisposedException)
            {
                throw;
            }
            catch (ArgumentException)
            {
                throw;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                ms.Close();
            }
        }

       /* public Restaurant(SerializationInfo info, StreamingContext context)
        {
            name = (string)info.GetValue("RestaurantName", typeof(string));
            address = (string)info.GetValue("RestaurantAddress", typeof(string));
            phoneNum = (string)info.GetValue("RestaurantPhoneNum", typeof(string));

        }*/

        public decimal GetAverage()
        {
            decimal ratingSum = 0;
            foreach (Review current in reviews)
            {
                ratingSum += current.rating;
            }
            return (ratingSum / reviews.Count);
        }

        public string toJsonString()
        {
            string jsonString;

            MemoryStream ms = new MemoryStream();

            try
            {
                DataContractJsonSerializer ser = new DataContractJsonSerializer(typeof(Restaurant));
                ms.Position = 0;
                StreamReader sr = new StreamReader(ms);
                ser.WriteObject(ms, this);
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

        /*public void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            info.AddValue("RestaurantName", name);
            info.AddValue("RestaurantAddress", address);
            info.AddValue("RestaurantPhoneNum", phoneNum);
            foreach (Review item in reviews)
            {
                info.AddValue("RestaurantReview", item);
            }       
        }*/
    }
}
