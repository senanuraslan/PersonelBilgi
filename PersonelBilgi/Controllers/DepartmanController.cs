using PersonelBilgi.Models;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PersonelBilgi.Controllers
{
    public class DepartmanController : ApiController
    {
        public HttpResponseMessage Get()  //metot oluşturduk
        {
            string query = @"
                             select DepartmanId,DepartmanAd from dbo.DEPARTMAN";
            DataTable table = new DataTable();
            using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonelAppDB"].ConnectionString))
            using (var cmd = new SqlCommand(query, con))
            using (var da = new SqlDataAdapter(cmd)) // veritabanından dönen sonuçları DataTable objesine doldurmak için kulllanılır
            //"using" yapısı veritabanına bağlantı yaparken ve sorguyu çalıştırırken açılan bağlantıları otomatik olarak kapatır.
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table); // Fill metodu ile sorgunun sonucu tablo nesnesine doldurulur.
            }
            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
        public string Post(Departman dep)
        {
            try
            {
                string query = @"
                           insert into dbo.DEPARTMAN values('" + dep.DepartmanAd + @"')
            ";
                DataTable table = new DataTable();

                using (var con = new SqlConnection(ConfigurationManager.
               ConnectionStrings["PersonelAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Ekleme Başarılı";
            }
            catch (Exception)
            {
                return "Ekleme Başarısız";

            }
        }

        public string Put(Departman dep)
        {
            try
            {
                string query = @"
                                update dbo.DEPARTMAN set DepartmanAd=
                                '" + dep.DepartmanAd + @"'
                                where DepartmanId=" + dep.DepartmanId + @"
                                ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonelAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table); // Fill metodu ile sorgunun sonucu tablo nesnesine doldurulur.
                }
                return "Güncelleme Başarılı";
            }
            catch (Exception)
            {
                return "Güncelleme Başarısız";
            }
        }

        public string Delete(int id)
        {
            try
            {
                string query = @"
                                delete from dbo.DEPARTMAN
                                where DepartmanId=" + id + @"
                                ";
                DataTable table = new DataTable();
                using (var con = new SqlConnection(ConfigurationManager.ConnectionStrings["PersonelAppDB"].ConnectionString))
                using (var cmd = new SqlCommand(query, con))
                using (var da = new SqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table); // Fill metodu ile sorgunun sonucu tablo nesnesine doldurulur.
                }
                return "Silme Başarılı";
            }
            catch (Exception)
            {
                return "Silme Başarısız";
            }

        }
    }
}
