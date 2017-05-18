using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MIS442Store.Controllers;
using MIS442Store;
using MIS442Store.DataLayer.DataModels;

namespace MIS442Store.DataLayer.Interfaces
{
    public interface INewsRepository
    {
        List<News> GetList();
    }
}
