using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.Data;
using WebApplication1.features.coffe.entity;
using WebApplication1.features.coffe.Mapper;

namespace WebApplication1.features.coffe.controller;

[Route("api/[controller]")]
[ApiController]
public class CoffeeController(ApplicationDbContext context) : ControllerBase
{
    [HttpGet("index")]
    public IActionResult index()
    {
        return Ok("CoffeController");
    }

    [HttpGet]
    public IActionResult GetAllCoffeeSize()
    {
        List<CoffeEntity> entity = context.Coffes.Select(s => s.ToCoffeEntity(HttpContext)).ToList();
        return Ok(entity);
    }


    [HttpGet("{id:int}")]
    public async Task<IActionResult> GetCoffeeById([FromRoute] long id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var result = await context.Coffes.FindAsync(id);
        if (result == null)
        {
            return NotFound();
        }

        return Ok(result.ToCoffeEntity(HttpContext));
    }

    [HttpPost]
    public async Task<IActionResult> CreateCoffeeSize([FromForm] CoffeCreateEntity request, [Required] IFormFile image)
    {
        if (image.Length == 0)
        {
            return BadRequest("Изображение не предоставлено или файл пуст.");
        }

        // Генерация пути для сохранения изображения
        var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        var stateCreateFile = await CreateFile(image);

        if (!stateCreateFile.isCheck)
        {
            return BadRequest("Ошибка создания файла");
        }

        // // Пример создания сущности для записи в базу данных (Entity Framework)
        var model = request.ToCoffeFromCreateEntity(stateCreateFile.path);

        // Сохранение данных в базу
        var result = await context.Coffes.AddAsync(model);
        await context.SaveChangesAsync();

        // Возврат успешного ответа с информацией о созданном объекте
        return CreatedAtAction(nameof(GetCoffeeById), new { id = model.id }, model.ToCoffeEntity(HttpContext));
    }


    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateCoffeeSize([FromRoute] long id, [FromForm] CoffeCreateEntity request,
        [Required] IFormFile image)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var coffee = await context.Coffes.FindAsync(id);
        if (coffee == null)
        {
            return NotFound("Кофе с указанным ID не найден.");
        }

        // Обновление данных кофе на основе переданного запроса
        coffee.name = request.name;
        coffee.price = request.price;

        // Если есть новое изображение, обновляем его
        if (image.Length > 0)
        {
            if (!DeleteFile(coffee.path))
            {
                return BadRequest("Ошибка удаления файла");
            }

            var stateCreate = await CreateFile(image);
            if (!stateCreate.isCheck)
            {
                if (!DeleteFile(coffee.path))
                {
                    return BadRequest("Ошибка создания файла");
                }
            }

            // Обновляем путь к изображению в сущности
            coffee.path = stateCreate.path;
        }

        // Сохранение изменений в базе данных
        context.Coffes.Update(coffee);
        await context.SaveChangesAsync();

        return Ok(coffee.ToCoffeEntity(HttpContext));
    }


    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteCoffeeSize([FromRoute] long id)
    {
        if (!ModelState.IsValid)
            return BadRequest(ModelState);

        var coffee = await context.Coffes.FindAsync(id);
        if (coffee == null)
        {
            return NotFound("Кофе с указанным ID не найден.");
        }

        if (!DeleteFile(coffee.path))
        {
            return BadRequest("Ошибка удаления файла");
        }

        // Удаление записи из базы данных
        context.Coffes.Remove(coffee);
        await context.SaveChangesAsync();

        return Ok($"Кофе с ID {id} и файл {coffee.path} успешно удалены.");
    }

    /// <summary>
    /// Метод для создания нового файла
    /// </summary>
    /// <param name="image">Файл</param>
    /// <returns>isCheck=Статус выполения метода, path=уникальное имя файла</returns>
    private async Task<(bool isCheck, string path)> CreateFile(IFormFile image)
    {
        // Генерация пути для сохранения изображения
        var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");

        // Проверяем, что папка для изображений существует, и создаем её, если нужно
        if (!Directory.Exists(uploadsFolderPath))
        {
            Directory.CreateDirectory(uploadsFolderPath);
            return (false, "");
        }

        // Генерация уникального имени для нового файла
        var uniqueFileName = Guid.NewGuid().ToString() + "_" + image.FileName;
        var filePath = Path.Combine(uploadsFolderPath, uniqueFileName);

        // Сохранение нового файла изображения на диск
        await using (var fileStream = new FileStream(filePath, FileMode.Create))
        {
            await image.CopyToAsync(fileStream);
        }

        return (true, uniqueFileName);
    }

    /// <summary>
    ///  Метод удаления файла 
    /// </summary>
    /// <param name="path">Путь к файлу</param>
    /// <returns>Статус выполения метода</returns>
    private bool DeleteFile(String path)
    {
        // Удаление файла изображения, если он существует
        if (!string.IsNullOrEmpty(path))
        {
            var uploadsFolderPath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images");
            var filePath = Path.Combine(uploadsFolderPath, path);

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath); // Удаление файла
                return true;
            }
        }

        return false;
    }
}