
CarRepository cars = new CarRepository();

Car c1 = new Car("AB 12 345", 80000);
Car c2 = new Car("CD 34 456", 65000);
Car c3 = new Car("EF 56 567", 28000);

cars.Insert(c1.LicensePlate, c1);
cars.Insert(c2.LicensePlate, c2);
cars.Insert(c3.LicensePlate, c3);


EmployeeRepository employees = new EmployeeRepository();

Employee e1 = new Employee("Allan", 1962);
Employee e2 = new Employee("Bente", 1975);
Employee e3 = new Employee("Carlo", 1973);

employees.Insert(e1.Name, e1);
employees.Insert(e2.Name, e2);
employees.Insert(e3.Name, e3);
