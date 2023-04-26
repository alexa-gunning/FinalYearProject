using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using team40_iteration6_user.Team40;

namespace team40_iteration6_user.Models
{
    public class Repository : IRepository
    {
        private readonly CoreDbContext _CoreDbContext;

        public Repository(CoreDbContext CoreDbContext)
        {
            _CoreDbContext = CoreDbContext;
        }

        public void Add<T>(T entity) where T : class
        {
            _CoreDbContext.Add(entity);
        }

        public void Delete<T>(T entity) where T : class
        {
            _CoreDbContext.Remove(entity);
        }
       
        public Task<Address[]> GetAddressAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Address> GetAddressByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<Admin[]> GetAdminsAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Client[]> GetAllClientsAsync()
        {
            /*IQueryable<Client> query = _team40_4Context.Client;
            return await query.ToArrayAsync();*/
            throw new System.NotImplementedException();
        }

        public Task<User[]> GetAllUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<Client> GetClientByID(int ID)
        {
            throw new System.NotImplementedException();
        }

        public Task<DiscountRequest> GetDiscountRequest(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<WorkshopEquipment> IRepository.GetEquipmentByID(int id)
        {
            throw new NotImplementedException();
        }

        public Task<DiscountRequest[]> GetDiscountRequestAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<DiscountStatus[]> GetDiscountStatusAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<DiscountStatus> GetDiscountStatusByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<DiscountType[]> GetDiscountTypeAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<DiscountType> GetDiscountTypeByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<NewsletterSubscriber> GetNewsletterByID(int id)
        {
            throw new System.NotImplementedException();
        }

        public Task<NewsletterSubscriber[]> GetNewsletterSubscriberAsync()
        {
            throw new System.NotImplementedException();
        }

        public Task<User> GetUserbyName(string name)
        {
            throw new System.NotImplementedException();
        }

        public async Task<bool> SaveChangesAsync()
        {
            return await _CoreDbContext.SaveChangesAsync() > 0;
        }
        //public Task<bool> SaveChanges()
        //{
        //    return _CoreDbContext.SaveChanges() > 0;
        //}
        //public void Add<T>(T entity) where T : class
        //{
        //    _CoreDbContext.Add(entity);
        //}

        //public void Delete<T>(T entity) where T : class
        //{
        //    _CoreDbContext.Remove(entity);
        //}

        Task<Admin[]> IRepository.GetAdminsAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<Booking[]> IRepository.GetAllBookingsAsync()
        {
            throw new NotImplementedException();
        }

        Task<Booking> IRepository.GetBookingByID(int id)
        {

            List<Booking> dbBookings = _CoreDbContext.Booking.ToList();
            Booking result = dbBookings.Find(x => x.BookingId == id);

            throw new NotImplementedException();
        }

        Task<Client[]> IRepository.GetAllClientsAsync()
        {
            throw new System.NotImplementedException();
        }


        Task<User[]> IRepository.GetAllUsersAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<Client> IRepository.GetClientByID(int ID)
        {

            List<Client> dbClients = _CoreDbContext.Client.ToList();
            Client result = dbClients.Find(x => x.ClientId == ID);

            throw new System.NotImplementedException();
        }
        Task<Inventory> IRepository.GetInventoryByID(int id)
        {

            List<Inventory> dbClients = _CoreDbContext.Inventory.ToList();
            Inventory result = dbClients.Find(x => x.InventoryId == id);

            throw new System.NotImplementedException();
        }

        Task<DiscountRequest> IRepository.GetDiscountRequest(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<DiscountRequest[]> IRepository.GetDiscountRequestAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<DiscountStatus[]> IRepository.GetDiscountStatusAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<DiscountStatus> IRepository.GetDiscountStatusByID(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<DiscountType[]> IRepository.GetDiscountTypeAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<DiscountType> IRepository.GetDiscountTypeByID(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<NewsletterSubscriber> IRepository.GetNewsletterByID(int id)
        {
            throw new System.NotImplementedException();
        }

        Task<NewsletterSubscriber[]> IRepository.GetNewsletterSubscriberAsync()
        {
            throw new System.NotImplementedException();
        }

        Task<User> IRepository.GetUserbyName(string name)
        {
            throw new System.NotImplementedException();
        }

        Task<bool> IRepository.SaveChangesAsync()
        {
            throw new System.NotImplementedException();
        }

       // async Task<WriteOffInventory[]> IRepository.GetAllWriteOffsAsync()
       // {
           // throw new NotImplementedException();

            //IQueryable<WriteOffInventory> query = _CoreDbContext.WriteOffInventory.Include(p => p.WriteOffReasonDescription).Include(p => p.Write);

            //return await query.ToArrayAsync();
     //   }

        Task<WriteOffInventory> IRepository.GetWriteOffById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<WriteOffInventory[]> GetAllHostAsync()
        {
            throw new NotImplementedException();
        }

        Task<WorkshopHost[]> IRepository.GetAllHostAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WorkshopEquipment[]> GetAllWorkshopEquipmentsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<WriteOffReason[]> GetWriteOffReasonsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product[]> GetAllProductsAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Product> GetProductById(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Policy[]> GetAllPolicyAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<WorkshopHost> GetHostAsync(string HostName)
        {
            IQueryable<WorkshopHost> query = _CoreDbContext.WorkshopHost.Where(c => c.HostName == HostName);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<WorkshopHost> GetHostSurnameAsync(string HostSurname)
        {
            IQueryable<WorkshopHost> query = _CoreDbContext.WorkshopHost.Where(c => c.HostSurname == HostSurname);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<WorkshopHost> GetHostEmailAsync(string HostEmail)
        {
            IQueryable<WorkshopHost> query = _CoreDbContext.WorkshopHost.Where(c => c.HostEmail == HostEmail);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Workshop> GetWorkshopDateByID(int WorkshopId)
        {
            IQueryable<Workshop> query = _CoreDbContext.Workshop.Where(c => c.WorkshopId == WorkshopId);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Inventory> GetInventoryItemAsync(string ItemName)
        {
            IQueryable<Inventory> query = _CoreDbContext.Inventory.Where(c => c.ItemName == ItemName);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<Policy> GetPolicyNameAsync(string PolicyName)
        {
            IQueryable<Policy> query = _CoreDbContext.Policy.Where(c => c.PolicyName == PolicyName);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<WorkshopType> GetTypeAsync(string Description)
        {
            IQueryable<WorkshopType> query = _CoreDbContext.WorkshopType.Where(c => c.Description == Description);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<WorkshopVenue> GetVenueAsync(string VenueName)
        {
            IQueryable<WorkshopVenue> query = _CoreDbContext.WorkshopVenue.Where(c => c.VenueName == VenueName);
            return await query.FirstOrDefaultAsync();
        }
        public Task<WorkshopVenue> GetVenue(string VenueName)
        {
            IQueryable<WorkshopVenue> query = _CoreDbContext.WorkshopVenue.Where(c => c.VenueName == VenueName);
            return query.FirstOrDefaultAsync();
        }
        public async Task<WorkshopVenue> GetVenueAddressAsync(string Address)
        {
            IQueryable<WorkshopVenue> query = _CoreDbContext.WorkshopVenue.Where(c => c.Address == Address);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<WorkshopEquipment> GetWorkshopEquipmentAsync(string Description)
        {
            IQueryable<WorkshopEquipment> query = _CoreDbContext.WorkshopEquipment.Where(c => c.Description == Description);
            return await query.FirstOrDefaultAsync();
        }

        public async Task<DeliveryCompany> GetDeliveryCompanyAsync(string deliveryCompanyName)
        {
            IQueryable<DeliveryCompany> query = _CoreDbContext.DeliveryCompany.Where(c => c.DeliveryCompanyName == deliveryCompanyName);
            return await query.FirstOrDefaultAsync();
        }
        /*public Task<Policy> GetPolicyById(int id)        {
            throw new NotImplementedException();
        }*/
    }

}
