using System;
using System.Collections.Generic;

namespace SolidPrinciple
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public double Salary { get; set; }

        public Employee(int id, string name, double salary)
        {
            Id = id;
            Name = name;
            Salary = salary;
        }
    }


    public interface ISalaryCalculator
    {
        double CalculateSalary(Employee employee);
    }

    public class RegularEmployeeSalary : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee) => employee.Salary * 1.2; 
    }

    public class ContractEmployeeSalary : ISalaryCalculator
    {
        public double CalculateSalary(Employee employee) => employee.Salary * 1.1; 
    }

    public abstract class EmployeeReport
    {
        public abstract void GenerateReport(Employee employee);
    }

    public class PDFReport : EmployeeReport
    {
        public override void GenerateReport(Employee employee)
        {
            Console.WriteLine($"Generating PDF report for {employee.Name}");
        }
    }

    public class ExcelReport : EmployeeReport
    {
        public override void GenerateReport(Employee employee)
        {
            Console.WriteLine($"Generating Excel report for {employee.Name}");
        }
    }

 
    public interface IPrintable
    {
        void Print();
    }

    public interface IExportable
    {
        void Export();
    }

    public class ReportPrinter : IPrintable
    {
        public void Print() => Console.WriteLine("Printing Report...");
    }

    public class ReportExporter : IExportable
    {
        public void Export() => Console.WriteLine("Exporting Report...");
    }

    public class EmployeeManager
    {
        private readonly ISalaryCalculator _salaryCalculator;

        public EmployeeManager(ISalaryCalculator salaryCalculator)
        {
            _salaryCalculator = salaryCalculator;
        }

        public void ShowSalary(Employee employee)
        {
            double salary = _salaryCalculator.CalculateSalary(employee);
            Console.WriteLine($"Employee: {employee.Name}, Salary: {salary}");
        }
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            
          

            Employee emp1 = new Employee(1, "Hello", 5000);
            Employee emp2 = new Employee(2,"asdsad", 2323);

            ISalaryCalculator regularSalaryCalculator = new RegularEmployeeSalary();
            ISalaryCalculator contractSalaryCalculator = new ContractEmployeeSalary();

            EmployeeManager manager1 = new EmployeeManager(regularSalaryCalculator);
            EmployeeManager manager2 = new EmployeeManager(contractSalaryCalculator);

            manager1.ShowSalary(emp1);
            manager2.ShowSalary(emp2);

       
            EmployeeReport pdfReport = new PDFReport();
            pdfReport.GenerateReport(emp1);

            EmployeeReport excelReport = new ExcelReport();
            excelReport.GenerateReport(emp2);

            Console.ReadKey();
        }
    }
}
