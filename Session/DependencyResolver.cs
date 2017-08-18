using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using System.Web;
using SystemForAll.Session.Repository;
using SystemForAll.Unit;
using System.Data.Entity;

namespace SystemForAll.Session
{
    [Export(typeof(Unit.IComponent))]
    public class DependencyResolver : Unit.IComponent
    {
        public void SetUp(Unit.IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IUnitOfWork, UnitOfWork>();
        }
    }
}