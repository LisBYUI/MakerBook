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
            _context.Contact.Add(contactModel);
            _context.SaveChanges();

            return contactModel;
        }

        public bool Delete(int id)
        {
            ContactModel contactDb = Get(id);
            if (contactDb == null)
                throw new Exception("Record not Found");

            _context.Contact.Remove(contactDb);
            _context.SaveChanges();

            return true;
        }

        public ContactModel Get(int id)
        {
            return _context.Contact.FirstOrDefault(_ => _.Id == id);
        }

        public List<ContactModel> GetAll()
        {
            return _context.Contact.ToList();
        }

        public ContactModel Update(ContactModel contactModel)
        {
            ContactModel contactDb = Get(contactModel.Id);
            if (contactDb == null)
                throw new Exception("Record not Found");
            contactDb.Name = contactModel.Name;
            contactDb.Email= contactModel.Email;

            _context.Contact.Update(contactDb);
            _context.SaveChanges();

            return contactDb;
        }
    }
}
