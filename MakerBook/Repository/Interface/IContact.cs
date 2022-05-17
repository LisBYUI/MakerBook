using MakerBook.Models;

namespace MakerBook.Repository.Interface
{
    public interface IContactRepository
    {
        ContactModel Create(ContactModel contactModel);
    }
}
