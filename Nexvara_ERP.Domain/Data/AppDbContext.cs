using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Nexvara_ERP.Domain.Entity.Employee;
using Nexvara_ERP.Domain.Entity.Master;
using Nexvara_ERP.Domain.Entity.Sales;
using Nexvara_ERP.Domain.Identiy;

namespace Nexvara_ERP.Domain.Data
{
    public class AppDbContext : IdentityDbContext<ApplicationUser, ApplicationRole, int>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<LeadSources> LeadSources { get; set; }
        public DbSet<DocumentType> DocumentTypes { get; set; }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<EmployeeBankDetails> EmployeeBankDetail { get; set; }
        public DbSet<EmployeeDocument> EmployeeDocuments { get; set; }
        public DbSet<EmployeeEmegencyContact> EmployeeEmegencyContacts { get; set; }
        public DbSet<EmployeeStatus> EmployeeStatuss { get; set; }
        public DbSet<EmployeeType> EmployeeTypes { get; set; }
        public DbSet<Gender> Genders { get; set; }
        public DbSet<Address> Address { get; set; }
        public DbSet<Branch> Branchs { get; set; }
        public DbSet<Citys> Citys { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Designation> Designation { get; set; }
        public DbSet<IndustryType> IndustryType { get; set; }
        public DbSet<LeadStatus> LeadStatus { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<PaymentTerm> PaymentTerm { get; set; }
        public DbSet<Permissions> Permissions { get; set; }
        public DbSet<ProductCategory> ProductCategory { get; set; }
        public DbSet<RolePermission> RolePermission { get; set; }
        public DbSet<State> State { get; set; }
        public DbSet<Tax> Tax { get; set; }
        //public DbSet<ActivityType> ActivityType { get; set; }
        public DbSet<Currency> Currency { get; set; }
        public DbSet<Customer> Customer { get; set; }
        public DbSet<Invoice> Invoice { get; set; }
        public DbSet<InvoiceItem> InvoiceItem { get; set; }
        public DbSet<InvoiceStatus> InvoiceStatus { get; set; }
        public DbSet<Lead> Lead { get; set; }
        public DbSet<LeadActivity> LeadActivity { get; set; }
        public DbSet<Opportunity> Opportunity { get; set; }
        public DbSet<OpportunityStaged> OpportunityStaged { get; set; }
        public DbSet<PaymentReceipt> PaymentReceipt { get; set; }
        public DbSet<Quotation> Quotation { get; set; }
        public DbSet<QuotationStatus> QuotationStatus { get; set; }
        public DbSet<QuotationItem> QuotationItem { get; set; }
        public DbSet<SalesOrder> SalesOrder { get; set; }
        public DbSet<SalesOrderStatus> SalesOrderStatus { get; set; }
        public DbSet<SalesOrderItem> SalesOrderItem { get; set; }
        public DbSet<Services> Services { get; set; }
        

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

        }

       
    }
}