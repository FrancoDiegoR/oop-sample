using ACME.OOP.Procurement.Domain.Model.Aggregate;
using ACME.OOP.Procurement.Domain.Model.ValueObjects;
using ACME.OOP.SCM.Domain.Model.Aggregate;
using ACME.OOP.SCM.Domain.Model.ValueObjects;
using ACME.OOP.Shared.Domain.Model.ValueObjets;

var supplierAddress = new Address("Supplier Street", "123", "Supplier City", 
    null, "12345", "United States");

var supplier = new Supplier("SUP001", "Microsoft, Inc", supplierAddress);
    
var purcharseOrder = new PurcharseOrder("P0001", new SupplierId(supplier.Identifier), 
    DateTime.Now, "USD");
        
purcharseOrder.AddItem(ProductId.New(), 10, 25.99m)
    .AddItem(ProductId.New(), 10, 25.99m);
            
Console.WriteLine($"Purchase order : {purcharseOrder.OrderNumber} created by {supplier.Identifier}");

foreach (var item in purcharseOrder.Items)
{
    Console.WriteLine($"Order item Total: {item.CalculateItemTotal()}");
}
            
Console.WriteLine($"Total Order Amount: {purcharseOrder.CalculateOrderTotal()}");