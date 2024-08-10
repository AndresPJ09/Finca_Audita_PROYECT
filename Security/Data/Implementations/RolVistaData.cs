using Data.Interfaces;
using Entity.Dto;
using Entity.Model.Contexts;
using Entity.Model.Security;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data.Implementations
{
    public class RolVistaData : IRolVistaData
    {
        private readonly ApplicationDbContexts context;
        protected readonly IConfiguration configuration;

        public RolVistaData(ApplicationDbContexts context, IConfiguration configuration)
        {
            this.context = context;
            this.configuration = configuration;
        }

        public async Task Delete(int id)
        {
            var entity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Registro no encontrado");
            }
            entity.Deleted_at = DateTime.Parse(DateTime.Today.ToString());
            context.rol_vista.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<DataSelectDto>> GetAllSelect()
        {
            var sql = @"SELECT 
                        Id,
                        CONCAT(Rol_id, ' - ', Vista_id) AS TextoMostrar 
                    FROM 
                        dbo.Rol_Vista
                    WHERE deleted_at IS NULL AND State = 1
                    ORDER BY Id ASC";
            return await context.QueryAsync<DataSelectDto>(sql);
        }

        public async Task<IEnumerable<RolVistaDto>> GetAll()
        {
            var sql = @"SELECT
                Id,
                Rol_id,
                Vista_id,
                State
            FROM dbo.Rol_Vista
            WHERE deleted_at IS NULL
            ORDER BY Id ASC";

            return await context.QueryAsync<RolVistaDto>(sql);
        }

        public async Task<RolVista> GetById(int id)
        {
            var sql = @"SELECT * FROM dbo.Rol_Vista WHERE Id = @Id ORDER BY Id ASC";
            return await this.context.QueryFirstOrDefaultAsync<RolVista>(sql, new { Id = id });
        }


        public async Task<RolVista> Save(RolVista entity)
        {
            context.rol_vista.Add(entity);
            await context.SaveChangesAsync();
            return entity;
        }

        public async Task Update(RolVista entity)
        {
            context.rol_vista.Update(entity);
            await context.SaveChangesAsync();
        }

        public async Task<IEnumerable<ModuloDto>> GetVistasByRolId(int rolId)
        {
            var sql = @"
        SELECT 
            m.Id, 
            m.Nombre, 
            m.Descripcion, 
            m.Position, 
            m.State,
            v.Id AS VistaId,
            v.Nombre,
            v.Descripcion
        FROM 
            dbo.Modulo m
        INNER JOIN 
            dbo.Vista v ON m.Id = v.ModuloId
        INNER JOIN 
            dbo.Rol_Vista rv ON v.Id = rv.Vista_id
        WHERE 
            rv.Rol_id = @RolId
            AND rv.Deleted_at IS NULL
            AND v.Deleted_at IS NULL
            AND m.Deleted_at IS NULL
        ORDER BY 
            m.Position ASC, v.Nombre ASC"; // Ordena por módulo y luego por vista

            var result = await context.QueryAsync<ModuloDto>(sql, new { RolId = rolId });

            var moduloDict = new Dictionary<int, ModuloDto>();

            foreach (var item in result)
            {
                if (!moduloDict.ContainsKey(item.Id))
                {
                    moduloDict[item.Id] = new ModuloDto
                    {
                        Id = item.Id,
                        Nombre = item.Nombre,
                        Descripcion = item.Descripcion,
                        Position = item.Position,
                        State = item.State,
                        Vistas = new List<VistaDto>()
                    };
                }

                moduloDict[item.Id].Vistas.Add(new VistaDto
                {
                    Id = item.Id,
                    Nombre = item.Nombre,
                    Descripcion = item.Descripcion
                });
            }

            return moduloDict.Values.OrderBy(m => m.Position);
        }

    }
}
    
