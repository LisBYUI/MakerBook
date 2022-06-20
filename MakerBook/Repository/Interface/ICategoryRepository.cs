using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface ICategoryRepository
    {
        /// <summary>
        /// Get
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        CategoryModel Get(int id);

        /// <summary>
        /// GetAll
        /// </summary>
        /// <returns></returns>
        List<CategoryModel> GetAll();

        /// <summary>
        /// Create
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        CategoryModel Create(CategoryModel categoryModel);

        /// <summary>
        /// Update
        /// </summary>
        /// <param name="categoryModel"></param>
        /// <returns></returns>
        CategoryModel Update(CategoryModel categoryModel);

        /// <summary>
        /// Delete
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        bool Delete(int id);
    }
}
