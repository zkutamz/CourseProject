using AutoMapper;
using LMS.Model.Constant;
using LMS.Model.Exceptions;
using LMS.Model.Request.OrderDetailDTOs;
using LMS.Model.Request.OrderHeaderDTOs;
using LMS.Model.Request.ShoppingCartDTOs;
using LMS.Model.Response.CourseDTOs;
using LMS.Model.Response.ShoppingCartDTOs;
using LMS.Repository.Entities;
using LMS.Repository.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LMS.Service.Services.ShoppingCartServices
{
    public class ShoppingCartService : IShoppingCartService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        public ShoppingCartService(IMapper mapper, IUnitOfWork unitOfWork)
        {
            _mapper = mapper;
            _unitOfWork = unitOfWork;
        }
        public ShoppingCartDto GetShoppingCart(int userId)
        {
            return new ShoppingCartDto()
            {
                courseDTOs = _mapper.Map<List<CourseDTO>>(_unitOfWork.ShoppingCartRepository.GetCourseShoppingCart(userId)),
                OriginalPrice = _unitOfWork.ShoppingCartRepository.GetOriginalPriceShoppingCart(userId),
                DiscountPrice = _unitOfWork.ShoppingCartRepository.GetDiscountPriceShoppingCart(userId)
            };
        }
        public async Task<ShoppingCartDto> AddCourseToCart(int userId, int courseId)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var item = await _unitOfWork.ShoppingCartRepository.ExistsAsync(p => p.UserId == userId && p.CourseId == courseId);
                if (item) throw new ConflictException(ResponseMessage.ExistCartItem);
                AddToCartDTO cartItem = new AddToCartDTO() { CourseId = courseId, UserId = userId };
                await _unitOfWork.ShoppingCartRepository.AddAsync(_mapper.Map<ShoppingCart>(cartItem));
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.AddFailure);
                await transaction.CommitAsync();
                // return user shopping cart after add course to cart

                return new ShoppingCartDto()
                {
                    courseDTOs = _mapper.Map<List<CourseDTO>>(_unitOfWork.ShoppingCartRepository.GetCourseShoppingCart(userId)),
                    OriginalPrice = _unitOfWork.ShoppingCartRepository.GetOriginalPriceShoppingCart(userId),
                    DiscountPrice = _unitOfWork.ShoppingCartRepository.GetDiscountPriceShoppingCart(userId)
                };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
        public async Task<ShoppingCartDto> RemoveCourseToCart(int userId, int courseId)
        {

            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var item = await _unitOfWork.ShoppingCartRepository.ExistsAsync(p => p.UserId == userId && p.CourseId == courseId);
                if (!item) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND("Course is not exist in cart"));
                AddToCartDTO cartItem = new AddToCartDTO() { CourseId = courseId, UserId = userId };
                await _unitOfWork.ShoppingCartRepository.RemoveAsync(_mapper.Map<ShoppingCart>(cartItem));
                var result = await _unitOfWork.SaveAsync() > 0;
                if (!result) throw new BadRequestException(ResponseMessage.DeleteFailure);
                await transaction.CommitAsync();
                // return user shopping cart after add course to cart
                return new ShoppingCartDto()
                {
                    courseDTOs = _mapper.Map<List<CourseDTO>>(_unitOfWork.ShoppingCartRepository.GetCourseShoppingCart(userId)),
                    OriginalPrice = _unitOfWork.ShoppingCartRepository.GetOriginalPriceShoppingCart(userId),
                    DiscountPrice = _unitOfWork.ShoppingCartRepository.GetDiscountPriceShoppingCart(userId)
                };
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }

        public async Task<ShoppingCartDto> ApplyCouponCode(int userId, string couponCode)
        {
            if (couponCode == null) return default;
            var promotion = await _unitOfWork.CoursePromotionRepository.GetAsync(p => p.CouponCode == couponCode);
           
            if (promotion == null) throw new NotFoundException(ResponseMessage.RESOURCE_NOTFOUND(couponCode));
            if (!promotion.IsActive) throw new BadRequestException(ResponseMessage.EndDate);
            var checkCoupon = await _unitOfWork.OrderHeaderRepository.ExistsAsync(o => o.SessionId == userId && o.CouponCode == promotion.Id);
            if(checkCoupon) throw new BadRequestException(ResponseMessage.CouponUse);
            return new ShoppingCartDto()
            {
                courseDTOs = _mapper.Map<List<CourseDTO>>(_unitOfWork.ShoppingCartRepository.GetCourseShoppingCart(userId)),
                OriginalPrice = _unitOfWork.ShoppingCartRepository.GetOriginalPriceShoppingCart(userId),
                DiscountPrice = _unitOfWork.ShoppingCartRepository.GetDiscountPriceShoppingCart(userId) + promotion.Amount,
                CouponCode = couponCode
            };
        }

        public async Task<bool> CheckOutShoppingCart(int userId, ShoppingCartDto shoppingCartDto)
        {
            using var transaction = await _unitOfWork.BeginTransactionAsync();
            try
            {
                var activeItemInCart = _unitOfWork.ShoppingCartRepository.CheckOutUserShoppingCart(userId);
                if(!activeItemInCart) throw new BadRequestException(ResponseMessage.UpdateFailure);
                var orderDetails = shoppingCartDto.courseDTOs.Select(c => new OrderDetailCreateDTO
                {
                    CourseId = c.Id,
                    Price = c.Price
                }).ToList();
                var orderHeader = _mapper.Map<OrderHeader>(
                    new OrderHeaderCreateDTO()
                    {
                        OrderTotal = shoppingCartDto.TotalPrice,
                        PaymentStatus = Repository.Enums.PaymentStatus.Confirmed,
                        SessionId = userId,
                        PaymentMethodId = 1,
                        OrderDetails = orderDetails
                    });
                orderHeader.OrderDetails= _mapper.Map<List<OrderDetail>>(orderDetails);
                await _unitOfWork.OrderHeaderRepository.AddAsync(orderHeader);

                var result = await _unitOfWork.SaveAsync() > 0;
                if(!result) throw new BadRequestException(ResponseMessage.AddFailure);
                await transaction.CommitAsync();
                return true;
            }
            catch (Exception)
            {
                await transaction.RollbackAsync();
                throw;
            }
        }
    }
}
