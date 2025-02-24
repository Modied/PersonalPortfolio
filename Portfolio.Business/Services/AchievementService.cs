using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http.HttpResults;
using Portfolio.Business.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Portfolio.Business.Services
{
    public class AchievementService : IAchievement
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IFileManager _fileManager;
        private readonly IWebHostEnvironment _hosting;
        private readonly IMapper _mapper;
        private readonly ICompany _company;
        private readonly ICustomer _customer;
        private readonly IAchievedFor _achievedFor;
        public AchievementService(IUnitOfWork unitOfWork, IFileManager fileManager, IWebHostEnvironment hosting, IMapper mapper, ICompany company, ICustomer customer, IAchievedFor achievedFor)
        {
            _unitOfWork = unitOfWork;
            _fileManager = fileManager;
            _hosting = hosting;
            _mapper = mapper;
            _company = company;
            _customer = customer;
            _achievedFor = achievedFor;
        }
        public async Task<int> AddAchievementAsync(AchievementVModel achievementVModel)
        {
            var achievementData = _mapper.Map<Achievement>(achievementVModel);
            achievementData.CustomerId = achievementData.CustomerId == -1 ? default(int?) : achievementData.CustomerId;
            achievementData.CompanyId = achievementData.CompanyId == -1 ? default(int?) : achievementData.CompanyId;
            await _unitOfWork.AchievementRepository.AddAsync(achievementData);
            //Console.WriteLine($"acivement ID:{achievementData.Id}");
            // await _achievedFor.AddAchievedForAsync(achievementVModel, achievementData.Id);
            return achievementData.Id;
        }
        public async Task<AchievementVModel> InitializeAchievementCreationAsync()
        {
            var customers = (await _customer.GetAllCustomersAsync()).ToList();
            var companies = (await _company.GetAllCompaniesAsync()).ToList();
            customers.Insert(0, new CustomerVModel { Id = -1, Name = "اختيار العميل", Priority = 0 });
            companies.Insert(0, new CompanyVModel { Id = -1, Name = "اختيار الشركة", Position = "Non" });
            var achievement = new AchievementVModel
            {
                Customers = customers,
                Companies = companies,
            };
            return achievement;
        }

        //public async  CompanyVModel FillDrowpDown()
        //{
        //    //var list = _unitOfWork.ClassficationRepository.GetAll().ToList();
        //    var customers = (await _customer.GetAllCustomersAsync()).ToList();

        //    customers.Insert(0, new CustomerVModel{Id = -1, Name = "اختيار التصنيف", Priority =0 });

        //    return customers;
        //}
        public async Task<OprationStatusModel> DeleteAchievementAsync(int id)
        {
            var oprationStatus = new OprationStatusModel();
            var result = await _unitOfWork.AchievementRepository.GetByIDAsync(id);
            if (result != null)
            {
                await _unitOfWork.AchievementRepository.DeleteAsync(result);
                oprationStatus.Status = true;
                return oprationStatus;
            }
            oprationStatus.Message = "Achievement not found";

            return oprationStatus;
        }

        public async Task<AchievementVModel> GetAchievementAsync(int id)
        {
            var requiredData = await InitializeAchievementCreationAsync();
            var data = await _unitOfWork.AchievementRepository.GetByIDAsync(id);
            var result = _mapper.Map<AchievementVModel>(data);
            result.Customers = requiredData.Customers;
            result.Companies = requiredData.Companies;
            return result;
        }

        public async Task<IEnumerable<AchievementVModel>> GetAllAchievementsAsync(string[] includes)
        {
            var data = await _unitOfWork.AchievementRepository.GetAllIncludesAsync(includes);
            //await _unitOfWork.AchievementRepository.GetAllIncludesAsync(includes);
            var result = _mapper.Map<IEnumerable<AchievementVModel>>(data);

            return result;

        }

        public async Task UpdateAchievementAsync(AchievementVModel achievementVModel)
        {
            var data = _mapper.Map<Achievement>(achievementVModel);
            await _unitOfWork.AchievementRepository.UpdateAsync(data, a => a.Id == achievementVModel.Id);


        }
    }
}
