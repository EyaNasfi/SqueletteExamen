using AM.ApplicationCore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AM.Infrastructure.Configurations
{
    public class LivreurConfig : IEntityTypeConfiguration<Livreur>
    {
        public void Configure(EntityTypeBuilder<Livreur> builder)
        {
            builder.HasMany(p => p.Vehicules).WithMany(p => p.Livreurs)
                .UsingEntity("Conduite");
        }
    }
}
