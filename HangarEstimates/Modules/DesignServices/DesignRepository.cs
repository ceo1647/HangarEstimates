using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HangarEstimates.Bll;

namespace HangarEstimates.Modules.DesignServices
{
    public class DesignRepository<T> : DictionaryRepositoryBase<T>
        where T : BaseObject
    {
    }
}
