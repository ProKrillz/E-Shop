using DataLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ServiceLayer.I_R;
using WebLayer.Pages.Shared.Helpers.Files;

namespace WebLayer.Pages.Users;
public class AdminModel : PageModel
{
    private readonly IProduct _productService;
    private readonly IFileHelper _fileHelper;

    public AdminModel(IProduct pService, IFileHelper fileHelper )
    {
        _productService = pService;
        _fileHelper = fileHelper;
    }
    [BindProperty(SupportsGet = true)]
    public string? SearchString { get; set; }
    [BindProperty]
    public int ProductId { get; set; }
    [BindProperty]
    public Product Product { get; set; }
    [BindProperty]
    public IFormFile UploadImage { get; set; }
    public IQueryable<Product> Products { get; set; }
    public List<SelectListItem>? Catagories { get; set; }
    public List<SelectListItem>? Brands { get; set; }
    public List<SelectListItem>? Sets { get; set; }
    [BindProperty(SupportsGet = true)]
    public int SelectCat { get; set; }
    [BindProperty(SupportsGet = true)]
    public string SelectSet { get; set; }

    public async Task OnGet()
    {
        List<Category> catagoriesTypeModels = await _productService.GetAllCategories();
        List<Brand> brandTypeModels = await _productService.GetAllBrandsAsync();
        List<Set> setTypeModels = await _productService.GetAllSetsAsync();
        Catagories = catagoriesTypeModels.Select(ctm => new SelectListItem
        {
            Value = ctm.CategoryId.ToString(),
            Text = ctm.Name.ToString()
        }).ToList();
        Brands = brandTypeModels.Select(b => new SelectListItem
        {
            Value = b.BrandId.ToString(),
            Text = b.Name.ToString()
        }).ToList();
        Sets = setTypeModels.Select(s => new SelectListItem
        {
            Value = s.SetId.ToString(),
            Text = s.SetName.ToString()
        }).ToList();
        if (!string.IsNullOrEmpty(SearchString))
        {
            Products = _productService.FindAllPage(_productService.FindAll().Where(s => s.Name.Contains(SearchString)).Include(p => p.Image).Include(p => p.Brand).Include(p => p.Category), 1, 9);
        }
        if (SelectCat > 0)
        {
            Products = _productService.FindAllPage(_productService.FindAll().Where(s => s.Fk_CategoryId == SelectCat).Include(p => p.Image).Include(p => p.Brand).Include(p => p.Category), 1, 9);
        }
        if (!string.IsNullOrEmpty(SelectSet))
        {
            Products = _productService.FindAllPage(_productService.FindAll().Where(s => s.Fk_SetId == SelectSet).Include(p => p.Image).Include(p => p.Brand).Include(p => p.Category), 1, 9);
        }
        if(string.IsNullOrEmpty(SelectSet) && SelectCat < 1 && string.IsNullOrEmpty(SearchString))
        {
            Products = _productService.FindAllPage(_productService.FindAll().Include(p => p.Image).Include(p => p.Brand).Include(p => p.Category), 1, 9);
        }
    }
    public async Task OnPostCreate()
    {
        string checkImage = UploadImage.FileName.Split('.').Last().ToUpper();
        if (checkImage == "JPG" | checkImage == "JPEG" | checkImage == "PNG")
        {
            await _fileHelper.UploadFileAsync(UploadImage);
            Product.Image = new ();
            Product.Image.Path = $"\\Image\\Card\\{UploadImage.FileName}";
            await _productService.AddItemAsync(Product);
            await _productService.CommitAsync();
            await OnGet();
        }
    }
    public async Task<IActionResult> OnPostDelete()
    {
        Product foundProduct = await _productService.FindByIdAsync(ProductId);
        _productService.Delete(foundProduct);
        await _productService.CommitAsync();
        return RedirectToPage("User/Admin");
    }
}
