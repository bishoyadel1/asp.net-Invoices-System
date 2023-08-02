using Domin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepository
{
    public interface IServicesProduct<T> where T : class

    {
        T GetProductPrice(string Id);
        List<T> GetProduct(string Id);

    }
}
