using MakerBook.Enum;
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

        // GET: CustomerFavoriteServiceViewModel/Create
        public IActionResult Create(int Id)
        {
            var userSession = _session.GetUserSession();

            var customerFavoriteServiceViewModel = new CustomerFavoriteServiceViewModel { ServiceId = Id };

            if (userSession.Profile == ProfileEnum.Customer)
            {
                var customer = _customerRepository.GetByEmail(userSession.Email);
                customerFavoriteServiceViewModel.CustomerId = customer.CustomerId;
            }

            return View(customerFavoriteServiceViewModel);
        }

        // POST: CustomerFavoriteServiceViewModel/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(CustomerFavoriteServiceViewModel customerFavoriteServiceViewModel)
        {
            try
            {
                var userSession = _session.GetUserSession();

                var customerFavoriteServiceModel = MapRegisterCustomerFavoriteService(customerFavoriteServiceViewModel, userSession.Login);

                _customerFavoriteServiceRepository.Create(customerFavoriteServiceModel);

                TempData["SuccessMessage"] = "Success!!!";
                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        private ServiceFeedbackViewModel MapRegisterServiceFeedbackView(int serviceId)
        {

            var serviceModel = _serviceRepository.Get(serviceId);
            var professional = _professionalRepository.Get(serviceModel.ProfessionalId);


            ServiceFeedbackViewModel targetModel = new ServiceFeedbackViewModel
            {
                ServiceId = serviceId
              ,
                ServiceTitle = serviceModel.Title
            ,
                ProfessionalName = professional.Name
                ,
                ProfessionalId = professional.ProfessionalId

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

        private CustomerFavoriteServiceModel MapRegisterCustomerFavoriteService(CustomerFavoriteServiceViewModel sourceModel, string login)
        {
            CustomerFavoriteServiceModel targetModel = new CustomerFavoriteServiceModel
            {
                CustomerFavoriteServiceId = 0
              ,
                CustomerId = sourceModel.CustomerId
              ,
                ServiceId = sourceModel.ServiceId
              ,
                Feedback = sourceModel.Feedback
              ,
                Rate = sourceModel.Rate
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };

            return targetModel;
        }
    }
}
