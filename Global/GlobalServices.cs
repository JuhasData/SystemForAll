using System.Collections.Generic;
using AutoMapper;
using System.Linq;
using System.Transactions;
using SystemForAll.Session;
using SystemForAll.Session.Repository;

namespace SystemForAll.Global
{
    public class GlobalServices : IGlobalServices
    {
        private readonly UnitOfWork _unitOfWork;

        public GlobalServices(UnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }


        //GlobalEntity == Session.Repository.Global
        //GlobalEntity == Session.GlobalEntity
        public GlobalEntity GetGlobalById(int globalID)
        {
            var global = _unitOfWork.GlobalRepository.GetByID(globalID);
            if (global != null)
            {
                Mapper.CreateMap<Session.Repository.Global, GlobalEntity>();
                var globalModel = Mapper.Map<Session.Repository.Global, GlobalEntity>(global);
                return globalModel;
            }
            return null;
        }

        public IEnumerable<GlobalEntity> GetAllGlobals()
        {
            var globals = _unitOfWork.GlobalRepository.GetAll().ToList();
            if (globals.Any())
            {
                Mapper.CreateMap<Session.Repository.Global, GlobalEntity>();
                var globalsModel = Mapper.Map<List<Session.Repository.Global>, List<GlobalEntity>>(globals);
                return globalsModel;
            }
            return null;
        }

        public int CreateGlobal(GlobalEntity globalEntity)
        {
            using (var scope = new TransactionScope())
            {
                var global = new Session.Repository.Global
                {
                    Name = globalEntity.Name
                };

                _unitOfWork.GlobalRepository.Insert(global);
                _unitOfWork.Save();
                scope.Complete();
                return global.Id;
            }
        }

        public bool UpdateGlobal(int globalId, GlobalEntity globalEntity)
        {
            var success = false;
            if (globalEntity != null)
            {
                using (var scope = new TransactionScope())
                {
                    var global = _unitOfWork.GlobalRepository.GetByID(globalId);
                    if (global != null)
                    {
                        global.Name = globalEntity.Name;
                        _unitOfWork.GlobalRepository.Update(global);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success;
        }

        public bool DeleteGlobal(int globalId)
        {
            var success = false;
            if (globalId > 0)
            {
                using (var scope = new TransactionScope())
                {
                    var global = _unitOfWork.GlobalRepository.GetByID(globalId);
                    if (global != null)
                    {

                        _unitOfWork.GlobalRepository.Delete(global);
                        _unitOfWork.Save();
                        scope.Complete();
                        success = true;
                    }
                }
            }
            return success; ;
        }
    }
}
