using CRUD.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD.Infra.Data.Mappings
{
    public class CAD_contatoMapping : IEntityTypeConfiguration<CAD_contato>
    {

        public void Configure(EntityTypeBuilder<CAD_contato> builder)
        {
            builder.HasKey(x => x.con_id);
            builder.Property(x => x.con_nome).IsRequired();
            builder.Property(x => x.con_telefone).HasColumnType("nvarchar(20)");
            builder.Property(x => x.con_dtNasc).IsRequired();

            builder.HasOne(x => x.cAD_cargo)
                .WithMany(x => x.cAD_contato)
                .HasForeignKey(x => x.car_id)
                .HasConstraintName("FK_CAD_contato_CAD_cargo");

        }
    }
}
