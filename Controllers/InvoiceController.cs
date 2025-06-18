using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using supply.Models;
using supply.Models.Repositorie;
using supply.ViewModels;

namespace supply.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly AppDBContext _context;
        private readonly IRepositorie<Product> productRep;
        private readonly IRepositorie<Invoice> invoiceRep;
        private readonly IRepositorie<InvoiceItem> invoiceItemRep;

        public InvoiceController(IRepositorie<Product> productRepo,
                                 IRepositorie<Invoice> invoiceRepo,
                                 IRepositorie<InvoiceItem> invoiceItemRepo,
            AppDBContext context)
        {
            productRep = productRepo;
            invoiceRep = invoiceRepo;
            invoiceItemRep = invoiceItemRepo;
            _context = context;
        }

        // GET: Invoice
        public IActionResult Index()
        {
            var invoices = invoiceRep.View();
            return View(invoices);
        }

        // GET: Invoice/Details/5
        public IActionResult Details(int id)
        {
            var invoice = _context.Invoice
        .Include(i => i.InvoiceItems)
        .FirstOrDefault(i => i.InvoiceId == id);

            if (invoice == null)
                return NotFound();

            var vm = new VmInvoiceModel
            {
                Invoice = invoice,
                InvoiceItems = invoice.InvoiceItems.Select(ii => new VmInvoiceProduct
                {
                    ProductId = ii.ProductId,
                    Qty = ii.Qty,
                    Vprice = ii.Vprice,
                    Tprice = ii.Tprice
                }).ToList(),
                ProductList = _context.Product.ToList()
            };
            invoice.TotalAmount = invoice.InvoiceItems.Sum(item => item.Qty * item.Vprice);
            return View(vm);
        }
        // GET: Invoice/Create
        public IActionResult Create()
        {
            var products = productRep.View()
                                      .Where(p => p != null && p.Supplier != null && p.Category != null)
                                      .ToList();

            var vm = new VmInvoiceModel
            {
                Invoice = new Invoice
                {
                    InvoiceDate = DateTime.Today,
                    InvoiceItems = new List<InvoiceItem>()
                },
                InvoiceItems = new List<VmInvoiceProduct>
                {
                    new VmInvoiceProduct() // start with one item row
                },
                ProductList = products
            };

            return View(vm);
        }

        // POST: Invoice/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(VmInvoiceModel model)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in model.InvoiceItems)
                {
                    item.Tprice = item.Qty * item.Vprice;
                }

                // إنشاء كائن الفاتورة
                var invoice = model.Invoice;

                // ربط العناصر بالفاتورة
                invoice.InvoiceItems = model.InvoiceItems.Select(item => new InvoiceItem
                {
                    ProductId = item.ProductId,
                    Qty = item.Qty,
                    Vprice = item.Vprice,
                    Tprice = item.Tprice
                }).ToList();

                _context.Invoice.Add(invoice);
                _context.SaveChanges();

                return RedirectToAction(nameof(Index));
            }

            // إعادة تعبئة قائمة المنتجات في حال حدوث خطأ في النموذج
            model.ProductList = productRep.View().ToList();
            return View(model);
        }

        // GET: Invoice/Edit/5
        public IActionResult Edit(int id)
        {
            var invoice = _context.Invoice.Include(i => i.InvoiceItems).FirstOrDefault(i => i.InvoiceId == id);
            var invoiceItems = invoice.InvoiceItems.Select(item => new VmInvoiceProduct
            {
                InvoiceItemId = item.InvoiceItemId,
                ProductId = item.ProductId,
                Qty = item.Qty,
                Vprice = item.Vprice,
                Tprice = item.Tprice
            }).ToList();

            var vm = new VmInvoiceModel
            {
                Invoice = invoice,
                InvoiceItems = invoiceItems,
                ProductList = productRep.View().ToList()
            };
            invoice.TotalAmount = invoice.InvoiceItems.Sum(item => item.Qty * item.Vprice);
            return View(vm);
        }

        // POST: Invoice/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        [HttpPost]
        public IActionResult Edit(VmInvoiceModel vm)
        {
            if (!ModelState.IsValid)
            {
                // أعد تحميل المنتجات إذا فشل النموذج
                vm.ProductList = productRep.View().ToList();
                return View(vm);
            }

            // التأكد من أن الفاتورة موجودة
            var invoice = _context.Invoice
                .Include(i => i.InvoiceItems)
                .FirstOrDefault(i => i.InvoiceId == vm.Invoice.InvoiceId);

            if (invoice == null)
            {
                return NotFound();
            }

            // تحديث الفاتورة
            invoice.InvoiceNumber = vm.Invoice.InvoiceNumber;
            invoice.InvoiceDate = vm.Invoice.InvoiceDate;

            // حذف العناصر القديمة
            _context.InvoiceItem.RemoveRange(invoice.InvoiceItems);

            // إضافة العناصر الجديدة
            foreach (var item in vm.InvoiceItems)
            {
                _context.InvoiceItem.Add(new InvoiceItem
                {
                    InvoiceId = invoice.InvoiceId,
                    ProductId = item.ProductId,
                    Qty = item.Qty,
                    Vprice = item.Vprice,
                    Tprice = item.Qty * item.Vprice
                });
            }

            _context.SaveChanges();
            return RedirectToAction("Index");
        }


        // GET: Invoice/Delete/5
        public IActionResult Delete(int id)
        {
            var invoice = invoiceRep.Find(id);
            if (invoice == null) return NotFound();
            return View(invoice);
        }

        // POST: Invoice/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var invoice = invoiceRep.Find(id);
            if (invoice != null)
            {
                invoiceRep.Delete(id, invoice);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
