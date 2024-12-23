﻿using LibraryData.Data;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace LibraryView.Controllers
{
    public class AuthorController : Controller
    {
        private readonly HttpClient _httpClient;
        private readonly string url = "https://localhost:7026/api/Author";
        public AuthorController(HttpClient httpClient)
        {
                _httpClient = httpClient;
        }
        public async Task<IActionResult> Index()
        {
            var response = await _httpClient.GetAsync(url);
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var lstAuthor = JsonConvert.DeserializeObject<List<Author>>(result);
                return View(lstAuthor);
            }
            return BadRequest();
        }
        public async Task<IActionResult> Details(Guid id)
        {
            var response = await _httpClient.GetAsync(url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var lstAuthor = JsonConvert.DeserializeObject<Author>(result);
                return View(lstAuthor);
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            return View();  
        }
        [HttpPost]
        public async Task<IActionResult> Create(Author author)
        {
            author.AuthorId = Guid.NewGuid();
            var content = new StringContent(JsonConvert.SerializeObject(author), 
                System.Text.Encoding.UTF8, "Application/json");
            var response = await _httpClient.PostAsync(url, content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        [HttpGet]
        public async Task<IActionResult> Edit(Guid id)
        {
            var response = await _httpClient.GetAsync(url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                var result = await response.Content.ReadAsStringAsync();
                var lstAuthor = JsonConvert.DeserializeObject<Author>(result);
                return View(lstAuthor);
            }
            return BadRequest();
        }
        [HttpPost]
        public async Task<IActionResult> Edit(Author authorUpdate)
        {
            var content = new StringContent(JsonConvert.SerializeObject(authorUpdate),
                System.Text.Encoding.UTF8, "Application/json");
            var response = await _httpClient.PutAsync(url + $"/{authorUpdate.AuthorId}", content);
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
        public async Task<IActionResult> Delete(Guid id)
        {
            var response = await _httpClient.DeleteAsync(url + $"/{id}");
            if (response.IsSuccessStatusCode)
            {
                return RedirectToAction("Index");
            }
            return BadRequest();
        }
    }
}
