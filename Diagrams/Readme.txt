Visit https://yuml.me/diagram/scruffy/class/draw to render the diagrams

// Use Case Diagram
[Customer]-(Sign In)
[Customer]-(Add Products)
[Customer]-(Check Out)
(Check Out)>(Add New Credit Card)
(Check Out)>(Reuse saved Credit Card)
[Customer]-(Sales Tax)
(Sales Tax)>(Get tax rates for a location)
[Customer]-(Sales Tax)
[Customer]-(Places Order)
(Places Order) > (Calculate taxes for an order)
[Office Staff]-(Processs Order)


// Class Diagram
[Address|Country; Zip; State; City; Street;]
[Customer|Id; Addresses; Payments; Orders; Type;]
[Order|Id; Custormer;Products; Address; Status; Amount; SalesTax]
[SalesTaxOrder|from_country;from_zip;from_state;from_city;from_street;to_country;to_zip;to_state;to_city;to_street;amount;shipping;customer_id;exemption_type;nexus_addresses;line_items]

[Address]->[Order]
[Customer]<>->[Order]   
[Customer]<>->[SalesTaxOrder]

[TaxCalculatorService|CalcualteSaleTaxForOrder(SalesTaxOrder);
GetTaxRateForLocation(Address);]
