using MakerBook.Data;
using MakerBook.Models;
using MakerBook.Repository.Interface;

namespace MakerBook.Repository
{
    public class ContactRepository: IContactRepository
    {
        private readonly DatabaseContext _context;

        public ContactRepository(DatabaseContext context)
        {
            _context = context;
        }

        public ContactModel Create(ContactModel contactModel)
        {
            _context.Add(contactModel);
            _context.SaveChanges();

            return contactModel;
        }

    }
}
