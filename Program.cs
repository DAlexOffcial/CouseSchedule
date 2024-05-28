using System;
using System.Collections.Generic;
using static System.Console;

namespace CouseSchedule
{
    class Program
    {
        private static Dictionary<int, List<int>> preMap = new Dictionary<int, List<int>>();
        private static HashSet<int> visitSet = new HashSet<int>();

        public static void Main(string[] args)
        {

            //crear la lista de prerequsitos 
            int[][] prerequisit = new int[][]
            {
               new int[] {0, 1},
               new int[] {0, 2},
               new int[] {1, 3},
               new int[] {1, 4},
               new int[] {3, 4},
            };

            // resultado de la busqueda dfs 
            bool result = CanFinish(5, prerequisit);
            WriteLine($"Can finish: {result}");
        }

        public static bool CanFinish(int numCourses, int[][] prerequisites)
        {
            // Crear el diccionario preMap
            preMap = new Dictionary<int, List<int>>();

            for (int i = 0; i < numCourses; i++)
            {
                preMap[i] = new List<int>();
            }

            // Llenar el diccionario con los prerequisitos
            foreach (var pre in prerequisites)
            {
                int crs = pre[0];
                int prerequisite = pre[1];
                preMap[crs].Add(prerequisite);
            }

            foreach (var kvp in preMap)
            {
                int curso = kvp.Key;
                List<int> requisitos = kvp.Value;

                Write($"Curso {curso}: Requisitos previos: ");
                foreach (int requisito in requisitos)
                {
                    Write($"{requisito} ");
                }
                WriteLine();
            }

            // Crear el conjunto visitSet
            visitSet = new HashSet<int>();

            // Verificar si se pueden completar todos los cursos
            for (int i = 0; i < numCourses; i++)
            {
                if (!dfs(i))
                {

                    return false;
                }
                WriteLine("cursos" +!dfs(i));
            }

            return true;
        }

        private static bool dfs(int crs)
        {
            if (visitSet.Contains(crs))
            {
                return false;
            }

            if (preMap[crs].Count == 0)
            {
                return true;
            }

            visitSet.Add(crs);

            foreach (int pre in preMap[crs])
            {
                if (!dfs(pre))
                {
                    return false;
                }
            }

            visitSet.Remove(crs);
            preMap[crs].Clear();
            return true;
        }
    }
}
