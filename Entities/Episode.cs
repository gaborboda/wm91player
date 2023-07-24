using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System.ComponentModel.DataAnnotations;

namespace Sm91.Play.Entities
{
    public class Episode
    {
        [BindNever]
        public string Id { get; set; }

        public int EpisodeNumber { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public Category Category { get; set; }
        
        public DateTime? ReleaseDate { get; set; }
        public TimeSpan Length { get; set; }

        [BindNever]
        public DateTime DateAdded { get; set; }

        [BindNever]
        public string? EncryptionKey { get; set; }

        [BindNever]
        public string? EncryptionKeyBase64 { get; set; }

        [BindNever]
        public string? EncryptionKeyId { get; set; }

        [BindNever]
        public string? EncryptionKeyIdBase64 { get; set; }
    }

    public enum Category
    {
        [Display(Name = "Rimming")]
        Rimming,

        [Display(Name = "Feeding")]
        Feeding,

        [Display(Name = "Solo")]
        Solo
    }
}
