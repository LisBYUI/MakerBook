using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly DatabaseContext _context;

        /// <summary>
        /// Constructor - CategoryRepository
        /// </summary>
        /// <param name="context"></param>
        public CategoryRepository(DatabaseContext context)
        {
            _context = context;
        }

        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public CategoryModel Get(int id)
        {
            return _context.Category.FirstOrDefault(i => i.CategoryId == id);
        }

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        public List<CategoryModel> GetAll()
        {
            return _context.Category.ToList();
        }

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="CategoryModel"></param>
        /// <returns></returns>
        public CategoryModel Create(CategoryModel categoryModel)
        {
            _context.Category.Add(categoryModel);
            _context.SaveChanges();

            return categoryModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="CategoryModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CategoryModel Update(CategoryModel categoryModel)
        {
            CategoryModel categoryDb = Get(categoryModel.CategoryId);
            if (categoryDb == null)
                throw new Exception("Record not Found");
            categoryDb.Name = categoryModel.Name;
            categoryDb.Description = categoryModel.Description;
            categoryDb.Image = categoryModel.Image;
            categoryDb.ImageName = categoryModel.ImageName;
            categoryDb.ImageExtension = categoryModel.ImageExtension;
            categoryDb.UpdatedAt = categoryModel.UpdatedAt;
            categoryDb.UserAt = categoryModel.UserAt;

            _context.Category.Update(categoryDb);
            _context.SaveChanges();

            return categoryDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            CategoryModel categoryDb = Get(id);
            if (categoryDb == null)
                throw new Exception("Record not Found");

            _context.Category.Remove(categoryDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
