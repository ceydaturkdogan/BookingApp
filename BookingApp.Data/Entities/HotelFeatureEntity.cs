using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookingApp.Data.Entities
{
    public class HotelFeatureEntity:BaseEntity
    {

        public int HotelId { get; set; }

        public int FeatureId { get; set; }

        //RelationalProperty

        public HotelEntity Hotel { get; set; }

        public FeatureEntity Feature { get; set; }
    }

    public class HotelFeaturConfiguration : BaseConfiguration<HotelFeatureEntity>
    {

        public override void Configure(EntityTypeBuilder<HotelFeatureEntity> builder)
        {
            builder.Ignore(x=>x.Id);//base'den gelen id prop. görmezden geldik

            builder.HasKey("HotelId", "FeatureId");//Composite key oluşturup bu oluşturduğumuz composite key'i primary key olarak atadık.
            base.Configure(builder);
        }
    }
}
