using Sm91.Play.Misc;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Runtime.InteropServices;
using System.Text.Json.Serialization;

namespace Sm91.Play.Entities
{
    public readonly struct Money
    {
        [JsonConstructor]
        public Money(decimal amount, Currency currency)
        {
            Amount = amount;
            Currency = currency;
        }

        public override string ToString() 
            => $"{EnumHelper<Currency>.GetDisplayValue(Currency)} {string.Format("{0:.00}", Amount)}";

        public decimal Amount { get; }
        public Currency Currency { get; }
    }

    public enum Currency
    {
        [Display(Name = "USD")]
        USD,

        [Display(Name = "EUR")]
        EUR,

        [Display(Name = "BTC")]
        BTC
    }
}
