using AutoMapper;
using Contracts;
using Entities.Models;
using Service.Contract;
using Shared.DataTransferObject_DTO_;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{

    internal sealed class SellerService : ISellerService
    {
        private readonly IRepositoryManager _repositoryManager;
        private readonly ILoggerManager _loggerManager;
        private readonly IMapper _mapper;
        public SellerService(IRepositoryManager repositoryManager, ILoggerManager loggerManager, IMapper mapper)
        {
            _repositoryManager = repositoryManager;
            _loggerManager = loggerManager;
            _mapper = mapper;
            
        }

        
        // Get all seller service   
        public async Task<IEnumerable<SellerDto>> GetAllSellerAsync(bool trackChanges)
        {
            try
            {
                var seller = await _repositoryManager.Seller.GetAllSellerAsync(trackChanges: false);
                
                
                var sellerDto = _mapper.Map<IEnumerable<SellerDto>>(seller);
                return sellerDto;
            }
            catch (Exception ex) 
            {
                _loggerManager.LogError($"Something went wrong in {nameof(GetAllSellerAsync)}service method {ex} ");
                throw;
            }

        }

        //create seller service 
        public async Task<SellerDto> CreateSeller(SellerForCreationDto seller)
        {
            try
            {
                var sellerEntity = _mapper.Map<Seller>(seller);
                await _repositoryManager.Seller.CreateSeller(sellerEntity);
                await _repositoryManager.SaveAsync();
                var sellerToReturn = _mapper.Map<SellerDto>(sellerEntity);
                return sellerToReturn;

            }catch(Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in {nameof(CreateSeller)}service method {ex} ");
                throw;
            }
            
        }

        //Get Seller By Id service

        public async Task<SellerDto> GetSellerAsync(Guid id, bool trackChanges)
        {
            try
            {
                var seller = await _repositoryManager.Seller.GetSellerAsync(id, trackChanges);

                //throw exception seller no found;

                var sellerDto = _mapper.Map<SellerDto>(seller);
                return sellerDto;

            }
            catch (Exception ex)
            {
                _loggerManager.LogError($"Something went wrong in {nameof(CreateSeller)}service method {ex} ");
                throw;
            }


        }


        
        public async Task updateSellerById(Guid id, SellerForUpdateDto sellerForUpdate, bool trackChanges)
        {
            var seller = await _repositoryManager.Seller.GetSellerAsync(id, trackChanges);

            _mapper.Map(sellerForUpdate, seller);
            _repositoryManager.Seller.UpdateSellerById(seller);
            await _repositoryManager.SaveAsync();
            
        }


        public async Task DeleteSellerAsync(Guid sellerId , bool trackChanges)
        {
            var seller = await _repositoryManager.Seller.GetSellerAsync(sellerId, trackChanges);

            //throw error

            _repositoryManager.Seller.DeleteSeller(seller);
            await _repositoryManager.SaveAsync();
        }
    }
}
