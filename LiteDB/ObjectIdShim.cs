using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using MongoDB.Bson;

namespace LiteDB
{
    public static class ObjectIdShim
    {
        public static ConstructorInfo InternalMongoBsonConstructorInfo = typeof(ObjectId).GetConstructors(BindingFlags.NonPublic | BindingFlags.Instance).FirstOrDefault();

        public static ObjectId GetObjectId(this byte[] array, int offset)
        {
            return (ObjectId) InternalMongoBsonConstructorInfo.Invoke(new object[] {array, offset});
        }
    }
}
