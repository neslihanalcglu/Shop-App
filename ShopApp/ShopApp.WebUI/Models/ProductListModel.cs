using ShopApp.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ShopApp.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; } //toplam eleman sayısı
        public int ItemsPerPage { get; set; } //her sayfada kaç eleman olacak
        public int CurrentPage { get; set; }// o anda hangi sayfada
        public string CurrentCategory { get; set; }//varsa aktif olan category bilgisi

        public int TotalPages()
        {
            return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage);
        }
    }
    public class ProductListModel
    {
        public PagingInfo PagingInfo { get; set; }
        public List<Product> Products { get; set; }
    }
}
