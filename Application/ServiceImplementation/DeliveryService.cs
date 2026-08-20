using Application.Interfaces;
using Application.Interfaces.RepositoryInterfaces;
using Application.Interfaces.ServiceInterfaces;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.ServiceImplementation
{
    public class DeliveryService(IDeliveryRepository deliveryRepository,IDeliveryManRepository deliveryManRepository,IUnitOfWork unitOfWork,INotificationRepository notificationRepository) : IDeliveryService
    {

        public async Task<BaseResponse<List<Delivery>>> GetUndoneDeliveryManWork(Guid deliveryManId)
        {
            var man = await deliveryManRepository.Get(deliveryManId);
            if (man == null)
            {
                return BaseResponse<List<Delivery>>.Fail("DeliverMan not found");
            }
            var deliveries = man.Deliveries.Where(x => !x.HasDelivered).ToList();
            if (deliveries.Count == 0)
            {
                return BaseResponse<List<Delivery>>.Fail("DeliverMan not found");
            }
            if (deliveries.Count > 0)
            {
                return BaseResponse<List<Delivery>>.Sucess(deliveries);
            }
            return BaseResponse<List<Delivery>>.Fail();
        }
        public async Task ProcessPendingDelivery()
        {

            var list = await deliveryRepository.GetAll();
            var pendingDeliveries = list.Where(x => x.IsAvailable).ToList();
            var urgentPendingDeliveries = GetUrgentOne(pendingDeliveries);
            var nonUrgentPendingDeliveries = GetNonUrgentOne(pendingDeliveries);
            foreach (var item in urgentPendingDeliveries)
            {
                var dates = new List<DateTime>();
                foreach (var req in item.Requests)
                {
                    if (req.IsUrgent)
                    {
                        dates.Add(req.CreatedAt);
                    }
                }
                
                if (FindLowest(dates).AddDays(2) <= DateTime.UtcNow)
                {
                    var worker = await GetEarliestWorker();
                    item.Update(item.HasDelivered, item.LgaId, false, worker.Id);
                    await deliveryRepository.Update(item);
                    await Assigned(worker);
                    await notificationRepository.Add(new Notification($"You have assigned to a delivery,Kindly Go and check.", worker.UserId, "System"));
                    foreach (var req in item.Requests)
                    {
                        await notificationRepository.Add(new Notification($"Expect ur delivery anytime,Contact the DeliveryMan with {worker.WorkId}.",req.Customer!.UserId,"System"));
                    }
                }
            }
            foreach (var item in nonUrgentPendingDeliveries)
            {
                if (item.CreatedAt.AddDays(10) <= DateTime.UtcNow)
                {
                    var worker = await GetEarliestWorker();
                    item.Update(item.HasDelivered, item.LgaId, false, worker.Id);
                    await deliveryRepository.Update(item);
                    await Assigned(worker);
                    await notificationRepository.Add(new Notification($"You have assigned to a delivery,Kindly Go and check.", worker.UserId, "System"));
                    foreach (var req in item.Requests)
                    {
                        await notificationRepository.Add(new Notification($"Expect ur delivery anytime,Contact the DeliveryMan with {worker.WorkId}.", req.Customer!.UserId, "System"));
                    }
                }
            }
        }
        public async Task Assigned(DeliveryMan deliveryMan)
        {
            deliveryMan.Update(deliveryMan.FirstName, deliveryMan.LastName,deliveryMan.WorkId, deliveryMan.UserId, "System", false, DateTime.UtcNow);
            await deliveryManRepository.Update(deliveryMan);
            await unitOfWork.SaveChanges();
        }
        public List<Delivery> GetUrgentOne(List<Delivery> deliveries)
        { 
            var newlist = new List<Delivery>(); 
            foreach (var item in deliveries)
            {
                if (item.Requests.Any(x => x.IsUrgent))
                {
                    newlist.Add(item);
                }
            }
            return newlist;
        }
        public List<Delivery> GetNonUrgentOne(List<Delivery> deliveries)
        {
            var newlist = new List<Delivery>();
            foreach (var item in deliveries)
            {
                if (!item.Requests.Any(x => x.IsUrgent))
                {
                    newlist.Add(item);
                }
            }
            return newlist;
        }

        public async Task<DeliveryMan> GetEarliestWorker()
        {
            var men = await deliveryManRepository.GetAll();
            return men.OrderBy(x => x.LastTimeOrdered).ThenBy(x => long.Parse(x.MiniTime)).First();
        }




        public DateTime FindLowest(List<DateTime> dateTimes)
        {
            DateTime b = DateTime.MaxValue;
            for (int i = 0; i < dateTimes.Count(); i++)
            {
                if (dateTimes[i] < b)
                {
                    b = dateTimes[i];
                }
            }
            return b;
        }
        //public long FindLowest(List<long> dateTimes)
        //{
        //    long b = long.MaxValue;
        //    for (int i = 0; i < dateTimes.Count(); i++)
        //    {
        //        if (dateTimes[i] < b)
        //        {
        //            b = dateTimes[i];
        //        }
        //    }
        //    return b;
        //}



        //public async Task<DeliveryMan> GetEarliestWorker()
        //{
        //    var men = await deliveryManRepository.GetAll();
        //    List<DateTime> dateTimes = [];
        //    List<long> longs = [];
        //    var newMen = new List<DeliveryMan>();
        //    foreach (var item in men)
        //    {
        //        dateTimes.Add(item.LastTimeOrdered);
        //    }
        //    foreach (var item in men)
        //    {
        //        if(item.LastTimeOrdered == FindLowest(dateTimes))
        //        {
        //            newMen.Add(item);
        //        }
        //    }
        //    if (newMen.Count == 1)
        //    {
        //        return newMen[0];
        //    }
        //    if(newMen.Count > 1)
        //    {
        //        foreach (var item in newMen)
        //        {
        //            longs.Add(long.Parse(item.MiniTime));
        //        }
        //    }
        //    var latest = new List<DeliveryMan>();
        //    foreach (var item in newMen)
        //    {
        //        if(long.Parse(item.MiniTime) == FindLowest(longs))
        //        {
        //            latest.Add(item);
        //        }
        //    }
        //    return latest[0];
        //}
    }
}
