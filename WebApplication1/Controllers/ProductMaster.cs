namespace WebApplication1.Controllers
{
    public class ProductCategoria
    {
       public string type { get; set; }
    }
    public class ProductMaster { 
        
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public List<int> role { get; set; }
        public String cDate { get; set; }
        public ProductCategoria productCategoria { get; set; }
    }

    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int age { get; set; }
    }
}
