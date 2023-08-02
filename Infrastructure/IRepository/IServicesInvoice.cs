﻿using Domin.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.IRepository
{
    public interface IServicesInvoice<T> where T : class

    {
        T index();
        bool Invoices(T model);



    }
}
