using MakerBook.Helper.Interface;
using MakerBook.Models;
using MakerBook.Repository.Interface;
using MakerBook.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace MakerBook.Controllers
{
    public class ServiceFeedbackController : Controller
    {

        private readonly IProfessionalRepository _professionalRepository;
        private readonly IProfessionalProfileRepository _professionalProfileRepository;
        private readonly IProfessionalSocialMediaRepository _professionalSocialMediaRepository;
        private readonly IServiceRepository _serviceRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly ICustomerFavoriteServiceRepository _customerFavoriteServiceRepository;
        private readonly ICustomerRepository _customerRepository;
        private readonly IServiceImageRepository _serviceImageRepository;
        private readonly ISessionHelper _session;


        public ServiceFeedbackController(IProfessionalRepository professionalRepository, IProfessionalProfileRepository professionalProfileRepository, IProfessionalSocialMediaRepository professionalSocialMediaRepository, IServiceRepository serviceRepository,
       IServiceImageRepository serviceImageRepository, ICategoryRepository categoryRepository, ICustomerFavoriteServiceRepository customerFavoriteServiceRepository, ICustomerRepository customerRepository, ISessionHelper session)
        {
            _professionalRepository = professionalRepository;
            _professionalProfileRepository = professionalProfileRepository;
            _professionalSocialMediaRepository = professionalSocialMediaRepository;
            _serviceRepository = serviceRepository;
            _serviceImageRepository = serviceImageRepository;
            _categoryRepository = categoryRepository;
            _customerRepository = customerRepository;
            _customerFavoriteServiceRepository = customerFavoriteServiceRepository;
            _session = session;

        }
        public IActionResult ServiceFeedback(int Id)
        {

            var model = MapRegisterServiceFeedbackView(Id);


            return View(model);
        }

        private ServiceFeedbackViewModel MapRegisterServiceFeedbackView(int serviceId)
        {

            var serviceModel = _serviceRepository.Get(serviceId);
            var professional = _professionalRepository.Get(serviceModel.ProfessionalId);


            ServiceFeedbackViewModel targetModel = new ServiceFeedbackViewModel
            {
                ServiceTitle = serviceModel.Title
            ,
                ProfessionalName = professional.Name

,
                CustomerFavoriteServiceViewList = MapRegisterCustomerFavoriteServiceModelList(serviceId)

            };


            return targetModel;
        }

        private CustomerFavoriteServiceViewModel MapRegisterCustomerFavoriteServiceModel(CustomerFavoriteServiceModel sourceModel)
        {
            CustomerFavoriteServiceViewModel targetModel = new CustomerFavoriteServiceViewModel
            {
                CustomerFavoriteServiceId = sourceModel.CustomerFavoriteServiceId
            ,
                ServiceId = sourceModel.ServiceId
            ,
                CustomerId = sourceModel.CustomerId
                ,
                Feedback = sourceModel.Feedback
                ,
                Rate = sourceModel.Rate
                ,
                CustomerName = _customerRepository.Get(sourceModel.CustomerId).Name
                ,
                CreatedAt = sourceModel.CreatedAt

            };

            return targetModel;
        }

        private List<CustomerFavoriteServiceViewModel> MapRegisterCustomerFavoriteServiceModelList(int serviceId)
        {
            List<CustomerFavoriteServiceViewModel> customerFavoriteServiceViewList = new List<CustomerFavoriteServiceViewModel>();

            var customerFavoriteServiceModelList = _customerFavoriteServiceRepository.GetByService(serviceId);

            foreach (var item in customerFavoriteServiceModelList)
            {
                customerFavoriteServiceViewList.Add(MapRegisterCustomerFavoriteServiceModel(item));
            }

            return customerFavoriteServiceViewList;
        }
    }
}
