using MvvmCross.IoC;
using MvvmCross.ViewModels;
using MyXamarinFormsApp.Core.ViewModels.Main;

namespace MyXamarinFormsApp.Core
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            RegisterAppStart<MainViewModel>();
        }
    }
}
