using Microsoft.Identity.Client;
using Sm91.Play.Domain;
using Sm91.Play.Misc;
using System.ComponentModel.DataAnnotations;

namespace Sm91.Play.Entities
{
    public class Subscription : IHasValidity
    {
        public string Id { get; set; } = Guid.NewGuid().ToString();
        public DateTime ValidFrom { get; set; }
        public DateTime ValidUntil { get; set; }
        public Tier TierId { get; set; }
        public Money AmountPaid { get; set; }
        public PaymentPlatform PaymentPlatform { get; set; } = PaymentPlatform.Patreon;
        public bool IsRecurring { get; set; } = false;
        public DateTime DateCreated { get; set; }
        public string UserId { get; set; }
        public User User { get;set; }
    }

    public enum PaymentPlatform
    {
        [Display(Name = "Patreon")]
        Patreon,

        [Display(Name = "Wishtender")]
        Wishtender,

        [Display(Name = "Bitcoin")]
        Bitcoin,

        [Display(Name = "WireTransfer")]
        WireTransfer
    }
}
