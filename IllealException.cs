using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace HotelProject
{
    public class IllegalException:Exception
    {
        public IllegalException(string message) : base(message)
        {
        }

        public override string Message => base.Message;

        public override IDictionary Data => base.Data;

        public override string StackTrace => base.StackTrace;

        public override string HelpLink { get => base.HelpLink; set => base.HelpLink = value; }
        public override string Source { get => base.Source; set => base.Source = value; }

        public override bool Equals(object obj)
        {
            return obj is StockException exception &&
                   Message == exception.Message &&
                   EqualityComparer<IDictionary>.Default.Equals(Data, exception.Data) &&
                   EqualityComparer<Exception>.Default.Equals(InnerException, exception.InnerException) &&
                   EqualityComparer<MethodBase>.Default.Equals(TargetSite, exception.TargetSite) &&
                   StackTrace == exception.StackTrace &&
                   HelpLink == exception.HelpLink &&
                   Source == exception.Source &&
                   HResult == exception.HResult;
        }

        public override Exception GetBaseException()
        {
            return base.GetBaseException();
        }

        public override int GetHashCode()
        {
            int hashCode = 1144832672;
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Message);
            hashCode = hashCode * -1521134295 + EqualityComparer<IDictionary>.Default.GetHashCode(Data);
            hashCode = hashCode * -1521134295 + EqualityComparer<Exception>.Default.GetHashCode(InnerException);
            hashCode = hashCode * -1521134295 + EqualityComparer<MethodBase>.Default.GetHashCode(TargetSite);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(StackTrace);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(HelpLink);
            hashCode = hashCode * -1521134295 + EqualityComparer<string>.Default.GetHashCode(Source);
            hashCode = hashCode * -1521134295 + HResult.GetHashCode();
            return hashCode;
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
        }

        public override string ToString()
        {
            return base.ToString() + $"message:{Message}";
        }
    }

}

