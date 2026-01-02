using System;
using System.Collections.Generic;

using PerpustakaanAppMVC.Model.Entity;
using PerpustakaanAppMVC.Model.Repository;
using PerpustakaanAppMVC.Model.Context;
using System.Windows.Forms;

namespace PerpustakaanAppMVC.Controller
{
    public class MahasiswaController
    {
        // deklarasi objek Repository untuk menjalankan operasi CRUD
        private MahasiswaRepository _repository;

        /// <summary>
        /// Method untuk menampilkan data mahasiwa berdasarkan nama
        /// </summary>
        /// <param name="nama"></param>
        /// <returns></returns>
        public List<Mahasiswa> ReadByNama(string nama)
        {
            // membuat objek collection
            List<Mahasiswa> list = new List<Mahasiswa>();

            // membuat objek context menggunakan blok using
            var repo = new MahasiswaRestApiRepository();
            return repo.ReadByNama(nama);

           
        }

        /// <summary>
        /// Method untuk menampilkan semua data mahasiswa
        /// </summary>
        /// <returns></returns>
        public List<Mahasiswa> ReadAll()
        {
            // membuat objek collection
            List<Mahasiswa> list = new List<Mahasiswa>();

            var repo = new MahasiswaRestApiRepository();
            list = repo.ReadAll();

            return list;
        }

        public int Create(Mahasiswa mhs)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                throw new ArgumentException("NPM harus diisi !!!");
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                throw new ArgumentException("Nama harus diisi !!!");
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                throw new ArgumentException("Angkatan harus diisi !!!");
            }

            var repo = new MahasiswaRestApiRepository();
            result = repo.Create(mhs);

            if (result > 0)
            {
                MessageBox.Show("Data mahasiswa berhasil disimpan !", "Informasi",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show("Data mahasiswa gagal disimpan !!!", "Peringatan",
                    MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                return result;
        }

        public int Update(Mahasiswa mhs)
        {
            int result = 0;

            // cek npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                throw new ArgumentException("NPM harus diisi !!!");
            }

            // cek nama yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Nama))
            {
                throw new ArgumentException("Nama harus diisi !!!");
            }

            // cek angkatan yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Angkatan))
            {
                throw new ArgumentException("Angkatan harus diisi !!!");
            }

            

            // Membuat objek repository REST API
            var repo = new MahasiswaRestApiRepository();

            // Memanggil method Update dari repository API
            result = repo.Update(mhs);

            return result;

           
        }

        public int Delete(Mahasiswa mhs)
        {
            int result = 0;

            // cek nilai npm yang diinputkan tidak boleh kosong
            if (string.IsNullOrEmpty(mhs.Npm))
            {
                throw new ArgumentException("NPM harus diisi !!!");
            }

            // Membuat objek repository REST API
            var repo = new MahasiswaRestApiRepository();

            // Memanggil method Delete dari repository API
            result = repo.Delete(mhs);

            return result;

        }
    }
}
