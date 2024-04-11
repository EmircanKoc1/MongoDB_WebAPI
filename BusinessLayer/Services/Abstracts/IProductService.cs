using Core.Dtos.Product;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Services.Abstracts
{
    public interface IProductService 
    {
        Task AddAsync(ProductCreateDto dto);
        Task<ProductReadDto> DeleteOneByIdAsync(string id);
        Task<ProductReadDto> DeleteOneByIdAsync(ProductDeleteDto dto);
        Task<IEnumerable<ProductReadDto>> GetAllAsync();
        Task<ProductReadDto> GetByIdAsync(string id);
        Task<ProductReadDto> UpdateOneByIdAsync(string id , ProductUpdateDto dto);
        IEnumerable<ProductReadDto> GetAll();
    }
}
