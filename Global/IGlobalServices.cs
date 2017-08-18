using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SystemForAll.Session;
using SystemForAll.Session.Repository;

namespace SystemForAll.Global
{
    //GlobalEntity == Session.Repository.GlobalEntity
    //GlobalEntity == Session.GlobalEntity
    public interface IGlobalServices
    {
        GlobalEntity GetGlobalById(int globalID);
        IEnumerable<GlobalEntity> GetAllGlobals();
        int CreateGlobal(GlobalEntity globalEntity);
        bool UpdateGlobal(int globalId, GlobalEntity globalEntity);
        bool DeleteGlobal(int globalId);
    }
}
