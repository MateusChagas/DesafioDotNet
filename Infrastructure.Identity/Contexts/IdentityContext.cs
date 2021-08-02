using Infrastructure.Identity.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure.Identity.Contexts
{
    public class IdentityContext : IdentityDbContext<ApplicationUser>
    {
        public IdentityContext(DbContextOptions<IdentityContext> options) : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.HasDefaultSchema("Identity");
            builder.Entity<ApplicationUser>(entity =>
            {
                entity.HasKey(u => u.Id);
                
                entity.ToTable(name: "Usuario");
                //entity.HasIndex(u => u.FirstName).HasName("PrimeroNome");
                entity.Property(u => u.UserName).HasColumnName("NomeUsuario");
                entity.Property(u => u.EmailConfirmed).HasColumnName("EmailConfirmado");
                //entity.Property(u => u.Id).HasColumnType("int");
                entity.Property(u => u.AccessFailedCount).HasColumnName("ContadorFalhasAcesso");
                entity.Property(u => u.ConcurrencyStamp).HasColumnName("Simultaniedade");
                entity.Property(u => u.NormalizedUserName).HasColumnName("NomeUsuarioNormalizado");
                entity.Property(u => u.NormalizedEmail).HasColumnName("EmailNormalizado");
                entity.Property(u => u.PasswordHash).HasColumnName("SenhaSegura");
                entity.Property(u => u.PhoneNumber).HasColumnName("NumTelefone");
                entity.Property(u => u.PhoneNumberConfirmed).HasColumnName("NumTelefoneConfirmado");
                entity.Property(u => u.TwoFactorEnabled).HasColumnName("SegurancaDuasEtapas");
                entity.Property(u => u.LockoutEnd).HasColumnName("FimBloqueio");
                entity.Property(u => u.LockoutEnabled).HasColumnName("BloqueioHabilitado");
                entity.Property(u => u.SecurityStamp).HasColumnName("EtapaSeguranca");

            });

            builder.Entity<IdentityRole>(entity =>
            {
                entity.ToTable(name: "Role");
            });
            builder.Entity<IdentityUserRole<string>>(entity =>
            {
                entity.ToTable("UserRoles");
            });

            builder.Entity<IdentityUserClaim<string>>(entity =>
            {
                entity.ToTable("UserClaims");
            });

            builder.Entity<IdentityUserLogin<string>>(entity =>
            {
                entity.ToTable("UserLogins");
            });

            builder.Entity<IdentityRoleClaim<string>>(entity =>
            {
                entity.ToTable("RoleClaims");

            });

            builder.Entity<IdentityUserToken<string>>(entity =>
            {
                entity.ToTable("UserTokens");
            });
        }
    }
}
