using supply.Models;

namespace supply.ViewModels
{
    public class VmProductCateSupp
    {
        public int ProductId { get; set; }
        public  string Name { get; set; }
        public  int QtyStock { get; set; }
        public  decimal Price { get; set; }
        public int CategoryId { get; set; }
        public int SupplierId { get; set; }

        public  Category Category { get; set; }
        public List<Category> ListCategory { get; set; }

        public  Supplier Supplier { get; set; }
        public List<Supplier> ListSupplier { get; set; }

    }
}
