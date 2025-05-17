using Shared.Result;

namespace Shared.Errors;
public static class DomainErrors
{
    public static class Customer
    {
        public static readonly Error InvalidDni = new("Customer.InvalidDni", "El dni no es valido");
        public static readonly Error InvalidPhoneNumber = new("Customer.InvalidPhoneNumber", "El numero de telefono no es valido");
        public static readonly Error InvalidCountryCode = new("Customer.InvalidCountryCode", "El codigo de pais no es valido");
        public static readonly Error PhoneAlreadyExists = new("Customer.PhoneAlreadyExist", "Este celular ya ha sido registrado");
        public static readonly Error PhoneNotFound = new("Customer.PhoneNotFound", "El celular no ha sido encontrado");
        public static readonly Error NoPhonesRegistered = new("Customer.NoPhonesRegistered", "No hay celulares registrados");
        public static readonly Error InvalidName = new("Customer.InvalidName", "El nombre no es valido");
        public static readonly Error InvalidLatitud = new("Customer.InvalidLatitud", "La latitud debe estar entre -90 y 90");
        public static readonly Error InvalidLongitud = new("Customer.InvalidLongitud", "La longitud debe estar entre -180 y 180");
        public static readonly Error SectorNotNotFoundInAllowedSectors = new("Customer.SectorNotNotFoundInAllowedSectors", "El sector no ha sido encontrado en la lista de sectores validos");
        public static readonly Error InvalidSector = new("Customer.InvalidSector", "El sector no es valido");
        public static readonly Error InvalidLocation = new("Customer.InvalidLocation", "La ubicacion no es valida");
        public static readonly Error InvalidHomeAddress = new("Customer.InvalidHomeAddress", "La direccion no es valida");
        public static readonly Error InvalidComment = new("Customer.InvalidComment", "El comentario no es valido");
        public static readonly Error InvalidIp = new("Customer.InvalidIp", "La ip no es valida");
        public static readonly Error InvalidDayOfCut = new("Customer.InvalidDayOfCut", "El dia de corte no es valido, seleccionar una fecha dentro del rango");
    }
}
