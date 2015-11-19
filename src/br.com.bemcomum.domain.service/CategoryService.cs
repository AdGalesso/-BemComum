using System;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;
using br.com.bemcomum.infra.data.contracts;

namespace br.com.bemcomum.domain.service
{
    public class CategoryService : BaseService<Category>, ICategoryService
    {
        protected ICategoryRepository _repository;

        public CategoryService(ICategoryRepository repository)
            : base(repository)
        {
            _repository = repository;
        }

        public int Count()
        {
            return _repository.Count();
        }
    }
}
