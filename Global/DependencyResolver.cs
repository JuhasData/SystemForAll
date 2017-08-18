using System.ComponentModel.Composition;

namespace SystemForAll.Global
{
    [Export(typeof(Unit.IComponent))]
    public class DependencyResolver : Unit.IComponent
    {
        public void SetUp(Unit.IRegisterComponent registerComponent)
        {
            registerComponent.RegisterType<IGlobalServices, GlobalServices>();
        }
    }
}
