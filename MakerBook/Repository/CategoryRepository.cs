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
        public CategoryModel Create(CategoryModel CategoryModel)
        {
            _context.Category.Add(CategoryModel);
            _context.SaveChanges();

            return CategoryModel;
        }

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="CategoryModel"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public CategoryModel Update(CategoryModel CategoryModel)
        {
            CategoryModel CategoryDb = Get(CategoryModel.CategoryId);
            if (CategoryDb == null)
                throw new Exception("Record not Found");
            CategoryDb.Name = CategoryModel.Name;
            CategoryDb.Description = CategoryModel.Description;
            CategoryDb.Image = CategoryModel.Image;
            CategoryDb.UpdatedAt = CategoryModel.UpdatedAt;
            CategoryDb.UserAt = CategoryModel.UserAt;

            _context.Category.Update(CategoryDb);
            _context.SaveChanges();

            return CategoryDb;
        }

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="Exception"></exception>
        public bool Delete(int id)
        {
            CategoryModel CategoryDb = Get(id);
            if (CategoryDb == null)
                throw new Exception("Record not Found");

            _context.Category.Remove(CategoryDb);
            _context.SaveChanges();

            return true;
        } 
    }
}
