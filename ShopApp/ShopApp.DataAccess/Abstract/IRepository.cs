using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ShopApp.DataAccess.Abstract
{
    public interface IRepository<T>//Generic Repository
    {
        T GetById(int id); //Kullanıcı bir id gönderdiği zaman T tablosundan bulup geri gönderecek
        T GetOne(Expression<Func<T, bool>> filter);//Kullanıcı geriye tek bir eleman döndürürse, bulduğu ilk kayıt
        List<T> GetAll(Expression<Func<T, bool>> filter=null); //Bulduğu bütün kayıtları geri alsın
                                                                     //varsayılan null
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
    }
}
