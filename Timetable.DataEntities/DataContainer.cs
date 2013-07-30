using Ninject.Modules;
using Timetable.Data.Context;
using Timetable.Base.Interfaces.DataSources;

namespace Timetable.Data
{
    public class DataContainer : NinjectModule  
    {
        #region Overrides of NinjectModule

        public override void Load()
        {
            Kernel.Bind<ISchedulerDatabase>().To<SchedulerContext>();
            Kernel.Bind<IUserDatabase>().To<UserContext>();
        }

        #endregion
    }
}
