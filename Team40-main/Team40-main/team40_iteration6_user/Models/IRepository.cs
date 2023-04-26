using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace team40_iteration6_user.Models
{
        public interface IRepository
        {
   
        void Add<T>(T entity) where T : class;

            void Delete<T>(T entity) where T : class;

            Task<bool> SaveChangesAsync();
   

        /***************CLIENT**********************/
        Task<Client[]> GetAllClientsAsync();

            Task<Client> GetClientByID(int id);

            /***************PRODUCT**********************/
            Task<Product[]> GetAllProductsAsync();

            Task<Product> GetProductById(int id);

            /***************USER**********************/
            Task<User[]> GetAllUsersAsync();
            Task<User> GetUserbyName(string name);

            /***************PRODUCT**********************/
            Task<Policy[]> GetAllPolicyAsync();

            //Task<Policy> GetPolicyById(int id);

        /***************DISCOUNT REQUEST**********************/
        Task<DiscountRequest[]> GetDiscountRequestAsync();

            Task<DiscountRequest> GetDiscountRequest(int id);

            /***************DISCOUNT STATUS**********************/
            Task<DiscountStatus[]> GetDiscountStatusAsync();

            Task<DiscountStatus> GetDiscountStatusByID(int id);

            /***************DISCOUNT TYPE**********************/
            Task<DiscountType[]> GetDiscountTypeAsync();

            Task<DiscountType> GetDiscountTypeByID(int id);

            /***************NEWSLETTER**********************/
            Task<NewsletterSubscriber[]> GetNewsletterSubscriberAsync();

            Task<NewsletterSubscriber> GetNewsletterByID(int id);

            /***************ADMINISTRATOR**********************/

            Task<Admin[]> GetAdminsAsync();
            //Task GetClientByNameAsync(int ID);

            /***************ADDRESS**********************/
            Task<Address[]> GetAddressAsync();

            Task<Address> GetAddressByID(int id);

        /***************CLIENT**********************/
            Task<Booking[]> GetAllBookingsAsync();

            Task<Booking> GetBookingByID(int id);

        /***************Write Off Inventory**********************/
      //  Task<WriteOffInventory[]> GetAllWriteOffsAsync();

        Task<WriteOffInventory> GetWriteOffById(int id);

        /***************Host**********************/
        Task<WorkshopHost[]> GetAllHostAsync();

        //Task<WriteOffInventory> GetWriteOffById(int id);

        /***************Equipment**********************/
        Task<WorkshopEquipment[]> GetAllWorkshopEquipmentsAsync();

        //Task<WriteOffInventory> GetWriteOffById(int id);

        /***************Equipment**********************/
        Task<WriteOffReason[]> GetWriteOffReasonsAsync();


        //Task<WriteOffInventory> GetWriteOffById(int id);
        Task<WorkshopHost> GetHostAsync(string HostName);
        Task<WorkshopHost> GetHostSurnameAsync(string HostSurname);
        Task<WorkshopHost> GetHostEmailAsync(string HostEmail);
        Task<Workshop> GetWorkshopDateByID(int WorkshopId);
        Task<Inventory> GetInventoryItemAsync(string ItemName);
        Task<Inventory> GetInventoryByID(int id);
        Task<WorkshopVenue> GetVenueAsync(string VenueName);
        Task<WorkshopVenue> GetVenue(string VenueName);
        Task<DeliveryCompany> GetDeliveryCompanyAsync(string deliveryCompanyName);
        Task<WorkshopVenue> GetVenueAddressAsync(string Address);
        Task<WorkshopEquipment> GetWorkshopEquipmentAsync(string Description);
        Task<WorkshopEquipment> GetEquipmentByID(int id);
           Task<WorkshopType> GetTypeAsync(string Description);
        Task<Policy> GetPolicyNameAsync(string PolicyName);
    }
}

