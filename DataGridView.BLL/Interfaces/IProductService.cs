using DataGridView.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataGridView.BLL.Interfaces
{
    public interface IProductService
    {
        void CreateProduct(ProductDTO productDTO);

    }
}
