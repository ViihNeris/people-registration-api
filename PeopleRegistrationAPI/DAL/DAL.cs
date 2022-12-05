using PeopleRegistrationAPI.Models;

namespace PeopleRegistrationAPI.DAL
{
    public class ListUsersDAL
    {
        private static Dictionary<long, ListUsersModel> listUsersDatabase = new Dictionary<long, ListUsersModel>();
        private static int databaseCount = 2;

        static ListUsersDAL()
        {
            ListUsersModel User = new ListUsersModel();

            User.IdUser = 1;
            User.UserName = "Viih Neris";
            User.UserAddress = "Rua The Best Dev, 200";
            listUsersDatabase.Add(1, User);
        }   
        public void Insert(ListUsersModel listUser)
        {
            databaseCount++;
            listUser.IdUser = databaseCount;
            listUsersDatabase.Add(databaseCount, listUser);
        }

        public ListUsersModel GetListUsers(int IdUser) // Consultando...
        {
            return listUsersDatabase[IdUser];
        }

        public IList<ListUsersModel> ToList() {
            return new List<ListUsersModel>(listUsersDatabase.Values); 
        }

        public void Delete(int IdUser)
        {
            listUsersDatabase.Remove(IdUser);
        }

        public void Update(ListUsersModel listUser)
        {
            listUsersDatabase[listUser.IdUser] = listUser;
        }

    }
}
