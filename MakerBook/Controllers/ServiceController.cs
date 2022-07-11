using Microsoft.AspNetCore.Mvc;
using MakerBook.Models;
using MakerBook.Filters;
using MakerBook.Helper.Interface;
using MakerBook.Repository.Interface;
using MakerBook.ViewModels;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace MakerBook.Controllers
{
    [PageForUserLogged]
    public class ServiceController : Controller
    {
        private readonly IServiceRepository _serviceRepository;
        private readonly IServiceAddressRepository _serviceAddressRepository;
        private readonly IServiceImageRepository _serviceImageRepository;
        private readonly ICategoryRepository _categoryRepository;
        private readonly IProfessionalRepository _professionalRepository;
        private readonly ISessionHelper _session;
        private readonly IWebHostEnvironment _webHostEnvironment;

        public ServiceController(IServiceRepository serviceRepository, IServiceAddressRepository serviceAddressRepository, IServiceImageRepository serviceImageRepository, ICategoryRepository categoryRepository, IProfessionalRepository
            professionalRepository, ISessionHelper session)
        {
            _serviceRepository = serviceRepository;
            _serviceAddressRepository = serviceAddressRepository;
            _serviceImageRepository = serviceImageRepository;
            _categoryRepository = categoryRepository;
            _professionalRepository = professionalRepository;
            _session = session;

        }

        // GET: Service
        public async Task<IActionResult> Index()
        {
            List<ServiceModel> serviceList = new List<ServiceModel>();
            var userSession = _session.GetUserSession();
            if (userSession.Profile == Enum.ProfileEnum.Professional)
            {
                var professional = _professionalRepository.GetByEmail(userSession.Email);
                serviceList = _serviceRepository.GetByProfessional(professional.ProfessionalId);
            }
            else
            {
                serviceList = _serviceRepository.GetAll();
            }

            List<ServiceViewModel> ServiceViewModel = new List<ServiceViewModel>();
            foreach (ServiceModel service in serviceList)
            {
                ServiceViewModel.Add(MapRegisterServiceView(service));
            }


            return View(ServiceViewModel);
        }

        // GET: Service/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            var serviceModel = _serviceRepository.Get(id ?? 0);

            if (serviceModel == null)
            {
                return NotFound();
            }
            var serviceViewModel = MapRegisterServiceView(serviceModel);


            return View(serviceViewModel);
        }

        // GET: Service/Create
        public IActionResult Create()
        {
            var userSession = _session.GetUserSession();

            ServiceViewModel model = new ServiceViewModel();
            if (userSession.Profile == Enum.ProfileEnum.Professional)
            {
                var professional = _professionalRepository.GetByEmail(userSession.Email);

                model.ProfessionalId = professional.ProfessionalId;

            }
            model.ProfessionalList = SelectListProfessional(model.ProfessionalId);
            model.CategoryList = SelectListCategory();
            //ViewData["LocationId"] = new SelectList(_context.Location, "LocationId", "LocationId");
            return View(model);
        }

        // POST: Service/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(ServiceViewModel serviceViewModel)
        {
            serviceViewModel.CategoryList = SelectListCategory();
            serviceViewModel.ProfessionalList = SelectListProfessional(0);
            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();
                    var serviceModel = MapRegisterService(serviceViewModel, userSession.Login);

                    var service = _serviceRepository.Create(serviceModel);


                    foreach (var item in serviceViewModel.ImageServiceList)
                    {
                        MemoryStream ms = new MemoryStream();
                        item.OpenReadStream().CopyTo(ms);

                        ServiceImageModel serviceImageModel = MapRegisterServiceImage(service.ServiceId, item.FileName, ms.ToArray(), userSession.Login);
                        _serviceImageRepository.Create(serviceImageModel);
                    }

                    var serviceAddressModel = MapRegisterServiceAddress(serviceViewModel, service.ServiceId, userSession.Login);

                    _serviceAddressRepository.Create(serviceAddressModel);


                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }
                return View(serviceViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction(nameof(Index));
            }
        }

        // GET: Service/Edit/5
        public IActionResult Edit(int? id)
        {
            var serviceModel = _serviceRepository.Get(id ?? 0);

            if (serviceModel == null)
            {
                return NotFound();
            }
            var serviceViewModel = MapRegisterServiceView(serviceModel);

            return View(serviceViewModel);
        }

        // POST: Service/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, ServiceViewModel serviceViewModel)
        {

            try
            {
                if (ModelState.IsValid)
                {
                    var userSession = _session.GetUserSession();
                    var serviceModel = MapRegisterService(serviceViewModel, userSession.Login);

                    ServiceModel service = _serviceRepository.Update(serviceModel);
                    TempData["SuccessMessage"] = "Success!!!";
                    return RedirectToAction(nameof(Index));
                }

                return View("Editar", serviceViewModel);
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        // GET: Service/Delete/5
        public IActionResult Delete(int? id)
        {
            var serviceModel = _serviceRepository.Get(id ?? 0);
            if (serviceModel == null)
            {
                return NotFound();
            }
            var serviceViewModel = MapRegisterServiceView(serviceModel);
            return View(serviceViewModel);
        }

        // POST: Service/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            try
            {
                var deleteConfirmed = _serviceRepository.Delete(id);
                if (deleteConfirmed)
                    TempData["SuccessMessage"] = "Success!!!";
                else
                    TempData["ErrorMessage"] = $"Fail!!!";

                return RedirectToAction(nameof(Index));

            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = $"Fail {ex.Message}!!!";
                return RedirectToAction("Index");
            }
        }

        private ServiceModel MapRegisterService(ServiceViewModel sourceModel, string login)
        {
            ServiceModel targetModel = new ServiceModel
            {
                ServiceId = sourceModel.ServiceId
                ,
                Title = sourceModel.Title
                ,
                ServiceType = sourceModel.ServiceType
            ,
                Description = sourceModel.Description
            ,
                Price = sourceModel.Price
            ,
                CategoryId = sourceModel.CategoryId
            ,
                ProfessionalId = sourceModel.ProfessionalId
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };


            return targetModel;
        }

        private ServiceViewModel MapRegisterServiceView(ServiceModel sourceModel)
        {
            ServiceViewModel targetModel = new ServiceViewModel
            {
                ServiceId = sourceModel.ServiceId
                ,
                Title = sourceModel.Title
            ,
                Description = sourceModel.Description
                ,
                ServiceType = sourceModel.ServiceType
            ,
                Price = sourceModel.Price
            ,
                CategoryId = sourceModel.CategoryId
            ,
                Category = _categoryRepository.Get(sourceModel.CategoryId)
            ,
                ProfessionalId = sourceModel.ProfessionalId
                ,
                Professional = _professionalRepository.Get(sourceModel.ProfessionalId)
            ,
                CategoryList = SelectListCategory()
                ,
                ProfessionalList = SelectListProfessional(0)
                ,
                ServiceImageList = SelectServiceImageViewModelList(sourceModel.ServiceId)
            };


            return targetModel;
        }

        private List<ServiceImageViewModel> SelectServiceImageViewModelList(int serviceId)
        {
            List<ServiceImageViewModel> serviceImageViewModelList = new List<ServiceImageViewModel>();

            foreach (var item in _serviceImageRepository.GetByService(serviceId))
            {
                serviceImageViewModelList.Add(MapRegisterServiceView(item));
            }

            return serviceImageViewModelList;
        }


        private ServiceImageViewModel MapRegisterServiceView(ServiceImageModel sourceModel)
        {
            ServiceImageViewModel targetModel = new ServiceImageViewModel
            {
                ServiceImageId = sourceModel.ServiceImageId
            ,
                ServiceId = sourceModel.ServiceId
            ,
                Name = sourceModel.Name
            ,
                Image = sourceModel.Image

            };


            return targetModel;
        }



        private List<SelectListItem> SelectListCategory()
        {
            var categories = new List<SelectListItem>();

            foreach (var item in _categoryRepository.GetAll())
            {
                var option = new SelectListItem() { Text = item.Name, Value = item.CategoryId.ToString() };
                categories.Add(option);
            }

            return categories;
        }

        private List<SelectListItem> SelectListProfessional(int professionalId)
        {
            var professionals = new List<SelectListItem>();
            var professionalModel = professionalId == 0 ? _professionalRepository.GetAll() : _professionalRepository.GetAll();


            foreach (var item in _professionalRepository.GetAll())
            {
                var option = new SelectListItem() { Text = item.Name, Value = item.ProfessionalId.ToString() };
                professionals.Add(option);
            }

            return professionals;
        }

        private ServiceImageModel MapRegisterServiceImage(int serviceId, string filename, byte[] image, string login)
        {
            ServiceImageModel targetModel = new ServiceImageModel
            {
                ServiceImageId = 0
            ,
                ServiceId = serviceId
            ,
                Name = filename
            ,
                Image = image
            ,
                CreatedAt = DateTime.Now
            ,
                UpdatedAt = DateTime.Now
            ,
                UserAt = login
            };


            return targetModel;
        }


        /// <summary>
        /// MapRegisterServiceAddress
        /// </summary>
        /// <param name="sourceModel"></param>
        /// <param name="serviceId"></param>
        /// <param name="login"></param>
        /// <returns></returns>
        private ServiceAddressModel MapRegisterServiceAddress(ServiceViewModel sourceModel, int serviceId, string login)
        {
            ServiceAddressModel serviceAddressModel = new ServiceAddressModel
            {
                ServiceAddressId = 0
                ,
                ServiceId = serviceId
                ,
                LineAddress = sourceModel.LineAddress
                ,
                ComplementAddress = sourceModel.ComplementAddress
                ,
                City = sourceModel.City
                ,
                State = sourceModel.State
                ,
                Country = sourceModel.Country
                ,
                ZipCode = sourceModel.ZipCode
                ,
                Latitude = sourceModel.Latitude
                ,
                Longitude = sourceModel.Longitude
                ,
                CreatedAt = DateTime.Now
                ,
                UpdatedAt = DateTime.Now
                ,
                UserAt = login
            };

            return serviceAddressModel;
        }
    }
}
