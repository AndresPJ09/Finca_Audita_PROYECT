using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity.Model.Security
{
    internal class GenericConfig
    {
        public void ConfigureUsuario(EntityTypeBuilder<Usuario> builder)
        {
            builder.HasIndex(i => i.Nombre).IsUnique();
        }

        public void ConfigurePersona(EntityTypeBuilder<Persona> builder)
        {
            builder.HasIndex(i => i.documento).IsUnique();
            builder.HasIndex(i => i.correo_electronico).IsUnique();

        }
    }
}