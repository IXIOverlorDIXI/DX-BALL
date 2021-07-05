using System;
using System.Collections.Generic;
using System.IO;
using Core;
using Newtonsoft.Json;

namespace DAL
{

    public class Repository
    {

         public bool Change<T>(List<T> collection, string path, string _log)
                   {
                       try
                       {
                           var fileInfo = new FileInfo(path);
                           if (!fileInfo.Exists)
                           {
                               var newFile = fileInfo.Create();
                               newFile.Close();
                           }
                           using (StreamWriter file = File.CreateText(path))
                           {
                               JsonSerializer serializer = new JsonSerializer();
                               serializer.Serialize(file, collection);
                           }
                           return true;
                       }
                       catch (Exception e)
                       {
                           // Log.Write(e, _log);
                           return false;
                       }
          
                   }
         public List<T> Read<T>(string path, string _log)
         {
             var collection = new List<T>();
             try
             {
                 var fileInfo = new FileInfo(path);
                 if (!fileInfo.Exists)
                 {
                     fileInfo.Create();
                     return collection;
                 }
                 using (StreamReader file = File.OpenText(path))
                 {
                     JsonSerializer serializer = new JsonSerializer();
                     collection = (List<T>)serializer.Deserialize(file, typeof(List<T>));
                 }
             }
             catch (Exception e)
             {
                 // Log.Write(e, _log);
             }
             return collection ?? new List<T>();
         }
    }
}
