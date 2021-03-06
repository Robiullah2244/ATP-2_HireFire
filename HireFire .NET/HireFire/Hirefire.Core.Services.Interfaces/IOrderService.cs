﻿using HireFire.Core.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hirefire.Core.Services.Interfaces
{
    public interface IOrderService
    {
        IEnumerable<Order> GetAll();

        Order GetById(int id);


        Order MostPopularGig();///By counting the max order then we can get the Most popular gig

        bool Insert(DateTime deadline, int gigId, string userName, string accountName,string account,string sellerName);
        bool Update(Order order);
        bool UpdateStatus(Order order);
        bool UpdateRating(Order order);
        bool UpdateFeedback(Order order);
        bool UpdateFileName(Order order);
        bool Delete(int id);
        IEnumerable<Order> GetByGigId(int gigId);
        int GetLatestOrderNumber();
        bool UpdateWorkToActiveByOderId(int orderId);
    }
}
