using LubriSoft.Entities;

namespace LubriSoft.Services
{
    public interface ILubriSoftServices
    {
        //Create
        public Task<int> CreateAceite(Aceite newAceite);
        public Task<int> CreateCliente(Cliente newCliente);
        public Task<int> CreateFabricante(Fabricante newFabricante);
        public Task<int> CreateMarca(Marca newMarca);
        public Task<int> CreateMecanica(Mecanica newMecanica);
        public Task<int> CreateModelo(Modelo newModelo);
        public Task<int> CreateService(Service newService);
        public Task<int> CreateVehiculo(Vehiculo newVehiculo);

        //Read
        public Task<List<Aceite>> ReadAllAceites();
        public Task<List<Cliente>> ReadAllClientes();
        public Task<List<Fabricante>> ReadAllFabricantes();
        public Task<List<Marca>> ReadAllMarcas();
        public Task<List<Mecanica>> ReadMecanicaByDate(DateTime fecha);
        public Task<List<Modelo>> ReadAllModelos();
        public Task<List<Service>> ReadServiceByDate(DateTime fecha);
        public Task<Vehiculo> ReadVehiculoByPatente(string patente);
        
        //Update
        public Task<bool> UpdateCliente(Cliente existingCliente);
        public Task<bool> UpdateMecanica(Mecanica existingMecanica);
        public Task<bool> UpdateService(Service existingService);
        public Task<bool> UpdateVehiculo(Vehiculo existingVehiculo);

        //Delete
        public Task<bool> DeleteAceite(string aceiteId);
        public Task<bool> DeleteCliente(string clienteId);
        public Task<bool> DeleteFabricante(string fabricanteId);
        public Task<bool> DeleteMarca(string marcaId);
        public Task<bool>DeleteMecanica(int mecanicaId);
        public Task<bool> DeleteModelo(string modeloId);
        public Task<bool> DeleteService(int serviceId);
        public Task<bool> DeleteVehiculo(string vehiculoId);

        //Search
        public Task<List<Mecanica>> SearchMecanica(int type, string field);
        public Task<List<Service>> SearchService(int type, string field);
        public Task<List<Vehiculo>> SearchVehiculos(int type, string field);
        public Task<List<Vehiculo>> SearchVehiculosConClientes();
    }
}