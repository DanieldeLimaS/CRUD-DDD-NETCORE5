using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infra.Data.Mappings
{
    public class CAD_cargoMapping : IEntityTypeConfiguration<CAD_cargo>
    {

        public void Configure(EntityTypeBuilder<CAD_cargo> builder)
        {
            builder.HasKey(x => x.car_id);
            builder.Property(x => x.car_nome).IsRequired();

        }
    }
}
