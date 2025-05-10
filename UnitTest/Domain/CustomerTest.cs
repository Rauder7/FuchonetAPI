using Domain.Entities;
using Domain.ValueObjects;
using Shared.Errors;

namespace UnitTest.Domain;
public class CustomerTest
{
    [Fact]
    public void ShouldCreatePhone()
    {
        //arranque
        string number = "+51 987 654 321";
        string errorNumber = "9876543210";
        bool status = true;
        string countryCode = "PE";
        //act
        var phoneResult = Phone.Create(number, status, countryCode);
        if (phoneResult.IsFailure)
        {
            throw new Exception(phoneResult.Error.Message);
        }
        var errorPhoneResult = Phone.Create(errorNumber, status, countryCode);
        Console.WriteLine(phoneResult.Value);
        //assert
        Assert.True(phoneResult.IsSuccess);
        Assert.Equal(phoneResult.Value.Number, number);
        Assert.Equal(phoneResult.Value.CountryCode, countryCode);
        Assert.Equal(phoneResult.Value.Status, status);
        Assert.IsType<Phone>(phoneResult.Value);

        Assert.False(errorPhoneResult.IsSuccess);
        Assert.True(errorPhoneResult.IsFailure);
        Assert.Equal(errorPhoneResult.Error, DomainErrors.Customer.InvalidPhoneNumber);


    }
    [Fact]
    public void ShoudCreateCustomer()
    {
        //arranque


        var name = Name.Create("Juan");
        var surName = SurName.Create("Perez");
        var dni = Dni.Create("12345678");
        if (dni.IsFailure)
        {
            throw new Exception(dni.Error.Message);
        }
        if (name.IsFailure)
        {
            throw new Exception(name.Error.Message);
        }
        if (surName.IsFailure)
        {
            throw new Exception(surName.Error.Message);
        }



        //act
        var customerResult = Customer.Create(name.Value, surName.Value, dni.Value);
        if (customerResult.IsFailure)
        {
            throw new Exception(customerResult.Error.Message);
        }
        var customer = customerResult.Value;
        var phoneResult = Phone.Create("+51 987654321", true, "PE");
        if (phoneResult.IsFailure)
        {
            throw new Exception(phoneResult.Error.Message);
        }
        var addPhoneResult = customer.AddPhone(phoneResult.Value);
        if (addPhoneResult.IsFailure)
        {
            throw new Exception(addPhoneResult.Error.Message);
        }
        Console.WriteLine(customer.Phones.First().Number);
        //assert
        Assert.NotNull(customer);
        Assert.NotNull(customer.Id);
        Assert.Equal(name.Value, customer.Name);
        Assert.Equal(surName.Value, customer.SurName);
        Assert.Equal(dni.Value, customer.Dni);
        Assert.IsType<Customer>(customer);
        Assert.IsType<CustomerId>(customer.Id);
        Assert.Single<Phone>(customer.Phones);
        Assert.Equal(customer.Phones.First().Number, "+51987654321");



    }

    public void ShouldThrowErrorsInCreateCustomer()
    {

    }
}
