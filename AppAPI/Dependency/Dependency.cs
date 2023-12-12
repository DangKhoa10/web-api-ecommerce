using AppAuth.BLL.Implements;
using AppAuth.BLL.Interfaces;
using AppAuth.DAL.Implements;
using AppAuth.DAL.Interfaces;
using AppBLL.Implements;
using AppBLL.Interfaces;
using AppDAL.Implements;
using AppDAL.Interfaces;

namespace AppAPI.Dependency
{
    public class Dependency
    {
        public static void DependencyConfig(IServiceCollection services)
        {
            //Biz Logic
            services.AddTransient<IIdentityBizLogic, IdentityBizLogic>();
            services.AddTransient<IProductBizLogic, ProductBizLogic>();


            //Repository
            services.AddTransient<IIdentityRepository, IdentityRepository>();
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
