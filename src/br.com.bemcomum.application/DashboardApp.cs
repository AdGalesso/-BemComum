using System;
using br.com.bemcomum.application.contracts;
using br.com.bemcomum.domain.Entities;
using br.com.bemcomum.domain.service.contracts;

namespace br.com.bemcomum.application
{
    public class DashboardApp : IDashboardApp
    {
        private ICategoryService _categoryService;
        private IInstitutionService _institutionService;
        private IDonorService _donorService;

        public DashboardApp(ICategoryService categoryService, IInstitutionService institutionService, IDonorService donorService)
        {
            _categoryService = categoryService;
            _institutionService = institutionService;
            _donorService = donorService;
        }

        public Dashboard GetData()
        {
            return new Dashboard()
            {
                CategoriesCount = _categoryService.Count(),
                Institutions = _institutionService.GetAllWithAddresses(),
                Donors = _donorService.GetAllWithAddress()
            };
        }
    }
}
