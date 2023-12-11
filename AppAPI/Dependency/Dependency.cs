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
            services.AddTransient<IProductBizLogic, ProductBizLogic>();


            //Repository
            services.AddTransient<IProductRepository, ProductRepository>();
        }
    }
}
