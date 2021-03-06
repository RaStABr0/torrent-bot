﻿using System;
using System.IO;
using System.Text.Json;

namespace TorrentBot.Tools
{
    public class DataSerializer
    {
        /// <summary>
        /// Сериализует промежуточные данные.
        /// </summary>
        public static void Serialize<T>(T obj)
        {
            var json = JsonSerializer.Serialize(obj);
            var path = PathHelper.GetFilePath(Infrastructure.DataStore.CONFIG_FILE_NAME);
            File.WriteAllText(path, json);
        }

        /// <summary>
        /// Десериализует промежуточные данные.
        /// </summary>
        public static T Deserialize<T>() where T : new()
        {
            var path = PathHelper.GetFilePath(Infrastructure.DataStore.CONFIG_FILE_NAME);

            T obj;

            try
            {
                var json = File.ReadAllText(path);
                obj = JsonSerializer.Deserialize<T>(json);

            }
            catch (Exception e)
            {
                obj = new T();
            }

            return obj;
        }
    }
}