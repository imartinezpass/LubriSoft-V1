using LubriSoft.Data;
using LubriSoft.Entities;
using Microsoft.EntityFrameworkCore;

namespace LubriSoft.Services
{
    public class LubriSoftServices(LubriSoftDataContext context) : ILubriSoftServices
    {
        private readonly LubriSoftDataContext dbContext = context;

        //********** CREATE **********

        public async Task<int> CreateAceite(Aceite newAceite)
        {
            var exists = await dbContext.Aceites.AnyAsync(a => a.NombreCompleto == newAceite.NombreCompleto);

            if (exists)
            {
                return 0;
            }
            else
            {
                dbContext.Aceites.Add(newAceite);
                await dbContext.SaveChangesAsync();
                return 1;
            }
        }

        public async Task<int> CreateCliente(Cliente newCliente)
        {
            var exists = await dbContext.Clientes.AnyAsync(c => c.Telefono == newCliente.Telefono);

            if (exists)
            {
                return 0;
            }
            else
            {
                dbContext.Clientes.Add(newCliente);
                await dbContext.SaveChangesAsync();
                return 1;
            }
        }

        public async Task<int> CreateFabricante(Fabricante newFabricante)
        {
            var exists = await dbContext.Fabricantes.AnyAsync(f => f.Nombre == newFabricante.Nombre);

            if (exists)
            {
                return 0;
            }
            else
            {
                dbContext.Fabricantes.Add(newFabricante);
                await dbContext.SaveChangesAsync();
                return 1;
            }
        }

        public async Task<int> CreateMarca(Marca newMarca)
        {
            var exists = await dbContext.Marcas.AnyAsync(ma => ma.Nombre == newMarca.Nombre);

            if (exists)
            {
                return 0;
            }
            else
            {
                dbContext.Marcas.Add(newMarca);
                await dbContext.SaveChangesAsync();
                return 1;
            }
        }

        public async Task<int> CreateMecanica(Mecanica newMecanica)
        {
            var exists = await dbContext.Vehiculos.AnyAsync(me => me.Patente == newMecanica.Patente);

            if (!exists)
            {
                return 0;
            }
            else
            {
                dbContext.Mecanica.Add(newMecanica);
                await dbContext.SaveChangesAsync();
                return newMecanica.Id;
            }
        }

        public async Task<int> CreateModelo(Modelo newModelo)
        {
            var exists = await dbContext.Modelos.AnyAsync(mo => mo.Nombre == newModelo.Nombre);

            if (exists)
            {
                return 0;
            }
            else
            {
                dbContext.Modelos.Add(newModelo);
                await dbContext.SaveChangesAsync();
                return 1;
            }
        }

        public async Task<int> CreateService(Service newService)
        {
            var exists = await dbContext.Vehiculos.AnyAsync(s => s.Patente == newService.Patente);

            if (!exists)
            {
                return 0;
            }
            else
            {
                dbContext.Service.Add(newService);
                await dbContext.SaveChangesAsync();
                return newService.Id;
            }
        }

        public async Task<int> CreateVehiculo(Vehiculo newVehiculo)
        {
            var exists = await dbContext.Vehiculos.AnyAsync(v => v.Patente == newVehiculo.Patente);

            if (exists)
            {
                return 0;
            }
            else
            {
                dbContext.Vehiculos.Add(newVehiculo);
                await dbContext.SaveChangesAsync();
                return 1;
            }
        }

        //********** READ **********

        public async Task<List<Aceite>> ReadAllAceites()
        {
            return await dbContext.Aceites.OrderBy(x => x.MarcaId).ThenBy(x => x.Nombre).ThenBy(x => x.Norma).ToListAsync();
        }

        public async Task<List<Cliente>> ReadAllClientes()
        {
            return await dbContext.Clientes.OrderBy(x => x.Nombre).ToListAsync();
        }

        public async Task<List<Fabricante>> ReadAllFabricantes()
        {
            return await dbContext.Fabricantes.OrderBy(x => x.Nombre).ToListAsync();
        }

        public async Task<List<Marca>> ReadAllMarcas()
        {
            return await dbContext.Marcas.OrderBy(x => x.Nombre).ToListAsync();
        }

        public async Task<List<Mecanica>> ReadMecanicaByDate(DateTime fecha)
        {
            return await dbContext.Mecanica.Where(x => x.Fecha.Date.Equals(fecha.Date)).OrderByDescending(x => x.Fecha).ToListAsync();
        }

        public async Task<List<Modelo>> ReadAllModelos()
        {
            return await dbContext.Modelos.OrderBy(x => x.Nombre).ToListAsync();
        }

        public async Task<List<Service>> ReadServiceByDate(DateTime fecha)
        {
            return await dbContext.Service.Where(x => x.Fecha.Date.Equals(fecha.Date)).OrderByDescending(x => x.Fecha).ToListAsync();
        }

        public async Task<Vehiculo> ReadVehiculoByPatente(string patente)
        {
            var vehiculo = await dbContext.Vehiculos.Where(v => v.Patente == patente).FirstOrDefaultAsync();

            if (vehiculo != null)
            {
                return vehiculo;
            }
            else
            {
                return null!;
            }
        }

        //********** UPDATE **********

        public async Task<bool> UpdateCliente(Cliente existingCliente)
        {
            var cliente = await dbContext.Clientes.Where(c => c.Telefono == existingCliente.Telefono).FirstOrDefaultAsync();

            if (cliente != null)
            {
                cliente.Telefono = existingCliente.Telefono;
                cliente.Nombre = existingCliente.Nombre;

                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateMecanica(Mecanica existingMecanica)
        {
            var mecanica = await dbContext.Mecanica.Where(m => m.Id == existingMecanica.Id).FirstOrDefaultAsync();

            if (mecanica != null)
            {
                mecanica.Fecha = existingMecanica.Fecha;
                mecanica.KilometrajeActual = existingMecanica.KilometrajeActual;
                mecanica.TipoTrabajo = existingMecanica.TipoTrabajo;
                mecanica.Detalle = existingMecanica.Detalle;

                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateService(Service existingService)
        {
            var service = await dbContext.Service.Where(s => s.Id == existingService.Id).FirstOrDefaultAsync();

            if (service != null)
            {
                service.Fecha = existingService.Fecha;
                service.KilometrajeActual = existingService.KilometrajeActual;
                service.KilometrajeProximo = existingService.KilometrajeProximo;
                service.AceiteId = existingService.AceiteId;
                service.FiltroAire = existingService.FiltroAire;
                service.FiltroAceite = existingService.FiltroAceite;
                service.FiltroCombustible = existingService.FiltroCombustible;
                service.FiltroHabitaculo = existingService.FiltroHabitaculo;
                service.Observaciones = existingService.Observaciones;

                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        public async Task<bool> UpdateVehiculo(Vehiculo existingVehiculo)
        {
            var vehiculo = await dbContext.Vehiculos.Where(v => v.Patente == existingVehiculo.Patente).FirstOrDefaultAsync();

            if (vehiculo != null)
            {
                vehiculo.Patente = existingVehiculo.Patente;
                vehiculo.Version = existingVehiculo.Version;
                vehiculo.CapacidadMotor = existingVehiculo.CapacidadMotor;
                vehiculo.CapacidadCaja = existingVehiculo.CapacidadCaja;
                vehiculo.FabricanteId = existingVehiculo.FabricanteId;
                vehiculo.ModeloId = existingVehiculo.ModeloId;
                vehiculo.ClienteId = existingVehiculo.ClienteId;

                await dbContext.SaveChangesAsync();
                return true;
            }
            else
            {
                return false;
            }
        }

        //********** DELETE **********

        public async Task<bool> DeleteAceite(string aceiteId)
        {
            bool hasReferences = await dbContext.Service.AnyAsync(s => s.AceiteId == aceiteId);
            if (hasReferences)
            {
                return false;
            }

            var aceite = await dbContext.Aceites.Where(v => v.NombreCompleto == aceiteId).FirstOrDefaultAsync();
            if (aceite == null)
            {
                return false;
            }

            dbContext.Aceites.Remove(aceite);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteCliente(string clienteId)
        {
            bool hasReferences = await dbContext.Vehiculos.AnyAsync(v => v.ClienteId == clienteId);
            if (hasReferences)
            {
                return false;
            }

            var cliente = await dbContext.Clientes.Where(c => c.Telefono == clienteId).FirstOrDefaultAsync();
            if (cliente == null)
            {
                return false;
            }

            dbContext.Clientes.Remove(cliente);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteFabricante(string fabricanteId)
        {
            bool hasReferences = await dbContext.Vehiculos.AnyAsync(v => v.FabricanteId == fabricanteId) || await dbContext.Modelos.AnyAsync(m => m.FabricanteId == fabricanteId);
            if (hasReferences)
            {
                return false;
            }

            var fabricante = await dbContext.Fabricantes.Where(v => v.Nombre == fabricanteId).FirstOrDefaultAsync();
            if (fabricante == null)
            {
                return false;
            }

            dbContext.Fabricantes.Remove(fabricante);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMarca(string marcaId)
        {
            bool hasReferences = await dbContext.Aceites.AnyAsync(m => m.MarcaId == marcaId);
            if (hasReferences)
            {
                return false;
            }

            var marca = await dbContext.Marcas.Where(m => m.Nombre == marcaId).FirstOrDefaultAsync();
            if (marca == null)
            {
                return false;
            }

            dbContext.Marcas.Remove(marca);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteMecanica(int mecanicaId)
        {
            var mecanica = await dbContext.Mecanica.Where(m => m.Id == mecanicaId).FirstOrDefaultAsync();
            if(mecanica == null)
            {
                return false;
            }

            dbContext.Remove(mecanica!);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteModelo(string modeloId)
        {
            bool hasReferences = await dbContext.Vehiculos.AnyAsync(v => v.ModeloId == modeloId);
            if (hasReferences)
            {
                return false;
            }

            var modelo = await dbContext.Modelos.Where(v => v.Nombre == modeloId).FirstOrDefaultAsync();
            if (modelo == null)
            {
                return false;
            }

            dbContext.Modelos.Remove(modelo);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteService(int serviceId)
        {
            var service = await dbContext.Service.Where(s => s.Id == serviceId).FirstOrDefaultAsync();
            if (service == null)
            {
                return false;
            }

            dbContext.Remove(service!);
            await dbContext.SaveChangesAsync();
            return true;
        }

        public async Task<bool> DeleteVehiculo(string vehiculoId)
        {
            bool hasReferences = await dbContext.Service.AnyAsync(s => s.Patente == vehiculoId) || await dbContext.Mecanica.AnyAsync(m => m.Patente == vehiculoId);
            if (hasReferences)
            {
                return false;
            }

            var vehiculo = await dbContext.Vehiculos.Where(v => v.Patente == vehiculoId).FirstOrDefaultAsync();
            if (vehiculo == null)
            {
                return false;
            }

            dbContext.Vehiculos.Remove(vehiculo);
            await dbContext.SaveChangesAsync();
            return true;
        }

        //********** SEARCH **********

        public async Task<List<Mecanica>> SearchMecanica(int campo, string busqueda)
        {
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                return [];
            }
            else
            {
                return campo switch
                {
                    1 => await dbContext.Mecanica.Where(x => x.Vehiculo!.ModeloId!.Contains(busqueda)).OrderByDescending(x => x.Fecha).ToListAsync(),
                    2 => await dbContext.Mecanica.Where(x => x.Patente! == busqueda).OrderByDescending(x => x.Fecha).ToListAsync(),
                    _ => await dbContext.Mecanica.Where(x => x.Patente!.Contains(busqueda)).OrderByDescending(x => x.Fecha).ToListAsync(),
                };
            }
        }

        public async Task<List<Service>> SearchService(int campo, string busqueda)
        {
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                return [];
            }
            else
            {
                return campo switch
                {                    
                    1 => await dbContext.Service.Where(x => x.Vehiculo!.ModeloId!.Contains(busqueda)).OrderByDescending(x => x.Fecha).ToListAsync(),
                    2 => await dbContext.Service.Where(x => x.Patente! == busqueda).OrderByDescending(x => x.Fecha).ToListAsync(),
                    _ => await dbContext.Service.Where(x => x.Patente!.Contains(busqueda)).OrderByDescending(x => x.Fecha).ToListAsync(),
                };
            }
        }

        public async Task<List<Vehiculo>> SearchVehiculos(int campo, string busqueda)
        {
            if (string.IsNullOrWhiteSpace(busqueda))
            {
                return [];
            }
            else
            {
                return campo switch
                {
                    1 => await dbContext.Vehiculos.Where(x => x.ModeloId!.Contains(busqueda)).OrderBy(x => x.Patente).ToListAsync(),
                    2 => await dbContext.Vehiculos.Where(x => x.Patente! == busqueda).OrderBy(x => x.Patente).ToListAsync(),
                    _ => await dbContext.Vehiculos.Where(x => x.Patente!.Contains(busqueda)).OrderBy(x => x.Patente).ToListAsync(),
                };          
            }
        }

        public async Task<List<Vehiculo>> SearchVehiculosConClientes()
        {
            return await dbContext.Vehiculos.Where(v => v.ClienteId != null).ToListAsync();
        }
    }
}