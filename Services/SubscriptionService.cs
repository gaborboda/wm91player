using Microsoft.EntityFrameworkCore;
using Sm91.Play.Data;
using Sm91.Play.Domain;
using Sm91.Play.Entities;
using Sm91.Play.Misc;

namespace Sm91.Play.Services
{
    public class SubscriptionService : ISubscriptionService
    {
        private readonly Sm91DbContext _db;

        public SubscriptionService(Sm91DbContext db)
        {
            _db = db;
        }

        public async Task CreateSubscriptionAsync(SubscriptionCreationModel creationModel)
        {
            Subscription subscription = new Subscription()
            {
                AmountPaid = creationModel.AmountPaid,
                IsRecurring = creationModel.IsRecurring,
                TierId= creationModel.Tier,
                PaymentPlatform = creationModel.PaymentPlatform,
                User = creationModel.User,

                DateCreated = DateTime.Now,
                ValidFrom = DateTime.UtcNow.Date,
                ValidUntil = DateTime.UtcNow.Date.AddMonths(1),
                Id = Guid.NewGuid().ToString()
            };

            _db.Add(subscription);
            await _db.SaveChangesAsync();
        }

        public async Task RenewSubscriptionAsync(string userId)
        {
            var expiredSubscription = _db.Subscriptions
                 .Include(s => s.User)
                 .Where(s => s.UserId == userId)
                 .OrderByDescending(s => s.DateCreated)
                 .First();

            DateTime expiredOn = expiredSubscription.ValidUntil;

            DateTime validFrom = expiredOn.AddDays(1);
            DateTime validUntil = expiredOn.AddMonths(1);

            Subscription subscription = new Subscription()
            {
                AmountPaid = expiredSubscription.AmountPaid,
                IsRecurring = expiredSubscription.IsRecurring,
                TierId = expiredSubscription.TierId,
                PaymentPlatform = expiredSubscription.PaymentPlatform,
                UserId = userId,

                DateCreated = DateTime.Now,
                ValidFrom = validFrom,
                ValidUntil = validUntil,
                Id = Guid.NewGuid().ToString()
            };

            _db.Subscriptions.Add(subscription);
            await _db.SaveChangesAsync();
        }
    }
}
