using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Identity;

namespace Ttlock.Api.Models
{
    public class ApplicationUser : IdentityUser
    {
        // Extend with additional profile fields later
    }

    public class SmartLock
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MaxLength(200)]
        public string TtlockId { get; set; } = string.Empty; // TTLock lockId

        public DateTime CreatedAtUtc { get; set; } = DateTime.UtcNow;

        public List<AccessGrant> AccessGrants { get; set; } = new();
    }

    public class AccessGrant
    {
        public Guid Id { get; set; } = Guid.NewGuid();

        [Required]
        public string UserId { get; set; } = string.Empty;
        public ApplicationUser? User { get; set; }

        [Required]
        public Guid SmartLockId { get; set; }
        public SmartLock? SmartLock { get; set; }

        public DateTime? StartsAtUtc { get; set; }
        public DateTime? EndsAtUtc { get; set; }
        public bool IsPermanent { get; set; }
    }

    public class AccessLog
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public Guid SmartLockId { get; set; }
        public SmartLock? SmartLock { get; set; }
        public string? UserId { get; set; }
        public ApplicationUser? User { get; set; }
        public DateTime TimestampUtc { get; set; } = DateTime.UtcNow;
        [MaxLength(50)]
        public string Action { get; set; } = "unlock"; // unlock/lock
        [MaxLength(200)]
        public string? Detail { get; set; }
    }
}