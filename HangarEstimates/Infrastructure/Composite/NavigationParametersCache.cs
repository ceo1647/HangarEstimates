using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace HangarEstimates.Infrastructure.Composite
{
    public class NavigationParametersCache
    {
        private static readonly Dictionary<Guid, object> ParamList
            = new Dictionary<Guid, object>();

        public static Guid CreateParameter<T>(T value)
            where T : class
        {
            if (ParamList.Values.Any(x => x == value))
            {
                var keyValue = ParamList.FirstOrDefault(x => x.Value == value);
                return keyValue.Key;
            }

            var newKey = Guid.NewGuid();
            ParamList.Add(newKey, value);
            return newKey;
        }

        public static T Request<T>(Guid paramGuid) where T: class
        {
            if (!ParamList.ContainsKey(paramGuid))
                throw new ArgumentException("Переданы неверные параметры при открытии представления");

            var requestedParameter = ParamList[paramGuid];

            if (requestedParameter.GetType() != typeof(T))
                throw new InvalidDataException("Неверный формат передаваемого параметра");

            return (T)requestedParameter;
        }
    }
}
