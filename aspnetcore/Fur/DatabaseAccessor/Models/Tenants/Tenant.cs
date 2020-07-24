﻿using Autofac;
using Fur.DatabaseAccessor.Models.Entities;
using Fur.DatabaseAccessor.Models.Seed;
using Fur.DatabaseAccessor.Providers;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fur.DatabaseAccessor.Models.Tenants
{
    /// <summary>
    /// 租户实体
    /// </summary>
    [Table("Tenants")]
    public class Tenant : IDbEntity, IDbDataSeedOfT<Tenant>
    {
        /// <summary>
        /// 主键Id
        /// </summary>
        [Key]
        [ScaffoldColumn(false)]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        /// <summary>
        /// 租户名
        /// </summary>
        [Required]
        public string Name { get; set; }

        /// <summary>
        /// 主机地址
        /// </summary>
        [Required]
        public string Host { get; set; }

        public IEnumerable<Tenant> HasData(DbContext dbContext, ILifetimeScope lifetimeScope)
        {
            if (!lifetimeScope.IsRegistered<ITenantProvider>()) return default;

            return new List<Tenant>()
            {
                new Tenant() { Id = 1, Name = "默认租户", Host = "localhost:44307" },
                new Tenant() { Id = 2, Name = "默认租户", Host = "localhost:41529" },
                new Tenant() { Id = 3, Name = "默认租户", Host = "localhost:41530" }
            };
        }
    }
}