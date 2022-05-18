using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IContactRepository
    {
        ContactModel Create(ContactModel contactModel);
               List<ContactModel> GetAll();
        bool Delete(int id);
        ContactModel Get(int id);
        ContactModel Update(ContactModel contactModel); 
    }
}
