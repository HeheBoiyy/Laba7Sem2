using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Logic
    {
        public async static Task<string> GenerateText(int stringsCount)
        {
            string saveText = string.Empty;
            for (int i = 0; i < stringsCount; i++)
            {
                await Task.Delay(100);
                saveText += "[" + i + "] Тестовая строка\n";
            }
            return saveText;
        }
        public static async Task WriteToFileAsync(string data)
        {
            string rootPath = Application.StartupPath;
            string filePath = Path.Combine(rootPath, "Bufer.txt");
            if (data == string.Empty)
            {
                MessageBox.Show("В чём смысл сохранять пустую строку?");
            }
            else 
            {
                try
                {

                    if (!File.Exists(filePath))
                    {

                        using (var fileStream = File.Create(filePath))
                        {
                            fileStream.Close();
                            MessageBox.Show("Так как файл отсутствовал, он был создан.");
                        }
                    }

                    using (var writer = new StreamWriter(filePath, false))
                    {
                        await writer.WriteAsync(data);
                    }

                    MessageBox.Show("Успешное сохранение!");

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Произошла ошибка: {ex.Message}");
                }
            }
            
        }
        public static async Task<string> ReadOrCreateFileAsync()
        {
            string rootPath = Application.StartupPath;
            string filePath = Path.Combine(rootPath, "Bufer.txt");
            string text = string.Empty;
            try
            {

                if (!File.Exists(filePath))
                {

                    using (var fileStream = File.Create(filePath))
                    {
                        fileStream.Close();
                    }
                    MessageBox.Show("Так как файл отсутствовал, он был создан.");
                    return text;
                }
                else
                {
                    // Если файл существует, читаем и возвращаем его содержимое
                    using (var reader = new StreamReader(filePath))
                    {
                        text = await reader.ReadToEndAsync();
                        return text;
                    }
                }
            }
            catch (Exception ex)
            {
                // В случае ошибки возвращаем информацию об ошибке
                MessageBox.Show($"Произошла ошибка: {ex.Message}");
                return text;

            }
        }
    }
}
