using cadastro_fornecedores.Models;

namespace cadastro_fornecedores.Data
{
    public class AppDbInitializer
    {
        public static void Seed(IApplicationBuilder applicationBuilder)
        {
            using (var servicesScopes = applicationBuilder.ApplicationServices.CreateScope())
            {
                var context = servicesScopes.ServiceProvider.GetService<Context>();
                context.Database.EnsureCreated();

                if (!context.Suppliers.Any())
                {
                    context.Suppliers.AddRange(new List<Supplier>()
                    {
                        new Supplier()
                        {
                            supplierFantasyName = "ABC Suppliers",
                            supplierEmail = "abc@example.com",
                            cnpj = 12345678901234,
                            supplierPhone = 1234567890,
                            supplierStreet = "Main Street",
                            supplierCity = "Ribeirão Preto",
                            supplierHouseNumber = "123",
                            supplierAddressComplement = "b1 ap01",
                            supplierNeighborhood = "Bairro 1",
                            personToContact = "John Doe",
                            phoneNumberPersonToContact = 987654321
                        },

                        new Supplier()
                        {
                            supplierFantasyName = "XYZ Suppliers",
                            supplierEmail = "xyz@example.com",
                            cnpj = 98765432109876,
                            supplierPhone = 9876543210,
                            supplierStreet = "Main Street",
                            supplierCity = "Ribeirão Preto",
                            supplierHouseNumber = "123",
                            supplierAddressComplement = "b1 ap01",
                            supplierNeighborhood = "Bairro 1",
                            personToContact = "Jane Smith",
                            phoneNumberPersonToContact = 123456789
                        },

                        new Supplier()
                        {
                            supplierFantasyName = "LMN Suppliers",
                            supplierEmail = "lmn@example.com",
                            cnpj = 55555555555555,
                            supplierPhone = 5555555555,
                            supplierStreet = "Main Street",
                            supplierCity = "Ribeirão Preto",
                            supplierHouseNumber = "123",
                            supplierAddressComplement = "b1 ap01",
                            supplierNeighborhood = "Bairro 1",
                            personToContact = "Alice Johnson",
                            phoneNumberPersonToContact = 987654321
                        },

                        new Supplier()
                        {
                            supplierFantasyName = "PQR Suppliers",
                            supplierEmail = "pqr@example.com",
                            cnpj = 11112222333344,
                            supplierPhone = 1111222233,
                            supplierStreet = "Main Street",
                            supplierCity = "Ribeirão Preto",
                            supplierHouseNumber = "123",
                            supplierAddressComplement = "b1 ap01",
                            supplierNeighborhood = "Bairro 1",
                            personToContact = "Bob Brown",
                            phoneNumberPersonToContact = 5555555555
                        },

                        new Supplier()
                        {
                            supplierFantasyName = "EFG Suppliers",
                            supplierEmail = "efg@example.com",
                            cnpj = 99998888777766,
                            supplierPhone = 9999888877,
                            supplierStreet = "Main Street",
                            supplierCity = "Ribeirão Preto",
                            supplierHouseNumber = "123",
                            supplierAddressComplement = "b1 ap01",
                            supplierNeighborhood = "Bairro 1",
                            personToContact = "Sarah White",
                            phoneNumberPersonToContact = 2222222222
                        },
                     });
                    context.SaveChanges();
                }
            }
        }
    }
}
