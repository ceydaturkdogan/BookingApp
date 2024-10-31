﻿using BookingApp.Data.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Context
{
    public class BookingAppDbContext : DbContext
    {

        public BookingAppDbContext(DbContextOptions<BookingAppDbContext> options):base(options) { }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //Fluent api burada conf işlemleri yapılacak entityden gelen özellikler tabloya dönüşürken burada yapacağız.


            modelBuilder.ApplyConfiguration(new FeatureConfiguration());//oluşturduğumuzconf. classları dbde çalışması için dbde newlememiz lazım.
            modelBuilder.ApplyConfiguration(new HotelConfiguration());
            modelBuilder.ApplyConfiguration(new HotelFeaturConfiguration());
            modelBuilder.ApplyConfiguration(new ReservationConfiguration());
            modelBuilder.ApplyConfiguration(new RoomConfiguration());
            modelBuilder.ApplyConfiguration(new UserConfiguration());




            base.OnModelCreating(modelBuilder);
        }
        public DbSet<UserEntity> Users => Set<UserEntity>();
        public DbSet<FeatureEntity> Features => Set<FeatureEntity>();
        public DbSet<HotelEntity> Hotels => Set<HotelEntity>();
        public DbSet<HotelFeatureEntity> HotelFeatures => Set<HotelFeatureEntity>();
        public DbSet<ReservationEntity> Reservations => Set<ReservationEntity>();
        public DbSet<RoomEntity> Rooms => Set<RoomEntity>();
    }
}
