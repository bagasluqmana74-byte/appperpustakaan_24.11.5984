using PerpustakaanAppMVC.Model.Entity;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PerpustakaanAppMVC.Model.Repository
{
    public class MahasiswaRestApiRepository
    {
        public int Create (Mahasiswa mhs)
        {
            string baseurl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/mahasiswa";

            var client = new RestClient(baseurl);
            var request = new RestRequest(endpoint, Method.POST);
            request.AddJsonBody(mhs);
            var response = client.Execute(request);
            var resault = response.Content.IndexOf("1") > -0 ? 1 : 0;

            return resault;
        }
        public int Update (Mahasiswa mhs)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
          
            string endpoint = "api/mahasiswa/" + mhs.Npm;

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.PUT);
            request.AddJsonBody(mhs);
            var response = client.Execute(request);
            return response.Content.Contains("1") ? 1 : 0;
        }

        public int Delete (Mahasiswa mhs)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/mahasiswa/" + mhs.Npm;

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.DELETE);
            var response = client.Execute(request);
            return response.Content.Contains("1") ? 1 : 0;
        }

        public List<Mahasiswa> ReadAll()
        {
            string baseurl = "http://latihan.coding4ever.net:5555/";
            string endpoint = "api/mahasiswa";

            var client = new RestClient(baseurl);
            var request = new RestRequest(endpoint, Method.GET);
            var response = client.Execute<List<Mahasiswa>>(request);

            return response.Data;
        }

        public List<Mahasiswa> ReadByNama (string nama)
        {
            string baseUrl = "http://latihan.coding4ever.net:5555/";

            
            string endpoint = "api/mahasiswa?nama=" + nama;

            var client = new RestClient(baseUrl);
            var request = new RestRequest(endpoint, Method.GET);
            var response = client.Execute<List<Mahasiswa>>(request);

            return response.Data;
        }

    }
}
