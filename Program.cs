using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace ConsoleApp1
{
    internal class Program
    {

        static void Main(string[] args)
        {
            Console.WriteLine("Presione una tecla para continuar");
            Console.ReadKey();

            //Ejercicio 4
            //Utilizando el archivo visualizaciones.txt, donde se tiene información mensual de varios años con
            //el total de visualizaciones de películas de una plataforma. Generar un archivo resultante
            //registrando el total por año.La restricción es que se tiene desde 2015 al 2022.
            //1.Controlar si el archivo no existe.
            //2.Escribir el archivo que indique los resultados obtenidos.Recuerde que para obtener el
            //año puede utilizar cadena.Substring(posición inicial, cantidad de caracteres); y retorna la
            //porción de cadena requerida.

            string texto = string.Empty;
            //string path = $"{Environment.CurrentDirectory}\\visualizaciones.txt";
            string path = "C:\\Users\\pablo\\Desktop\\Treeview\\ejercicioArchivos\\ConsoleApp1\\visualizaciones\\visualizaciones.txt";
            string pathDestino = $"{Environment.CurrentDirectory}\\ArchivoSalida.txt";
            Console.WriteLine(path);
            Console.WriteLine(pathDestino); 

            int total2015 = 0;
            int total2016 = 0;
            int total2017 = 0;
            int total2018 = 0;
            int total2019 = 0;
            int total2020 = 0;
            int total2021 = 0;
            int total2022 = 0; 
             
        try { 
                using (StreamReader archivo = new StreamReader(path))

                {               
                    while (!archivo.EndOfStream)
                    {
                        texto = archivo.ReadLine();

                        string[] linea = texto.Split(',');

                        if (Int32.Parse(texto.Substring(0, 4)) == 2015)
                        {
                            total2015 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2016)
                        {
                            total2016 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2017)
                        {
                            total2017 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2018)
                        {
                            total2018 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2019)
                        {
                            total2019 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2020)
                        {
                            total2020 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2021)
                        {
                            total2021 += Int32.Parse(linea[1].Trim());
                        }
                        else if (Int32.Parse(texto.Substring(0, 4)) == 2022)
                        {
                            total2022 += Int32.Parse(linea[1].Trim());
                        }

                    }
                 
                }

                Console.WriteLine("------------------- TOTAL DE VISUALIZACIONES POR ANIO --------------------");
                Console.WriteLine("");
                Console.WriteLine($"El Total de visualizaciones en el 2015: {total2015}");
                Console.WriteLine($"El Total de visualizaciones en el 2016: {total2016}");
                Console.WriteLine($"El Total de visualizaciones en el 2017: {total2017}");
                Console.WriteLine($"El Total de visualizaciones en el 2018: {total2018}");
                Console.WriteLine($"El Total de visualizaciones en el 2019: {total2019}");
                Console.WriteLine($"El Total de visualizaciones en el 2020: {total2020}");
                Console.WriteLine($"El Total de visualizaciones en el 2021: {total2021}");
                Console.WriteLine($"El Total de visualizaciones en el 2022: {total2022}");
                Console.WriteLine("");
                Console.WriteLine("------------------- TOTAL DE VISUALIZACIONES --------------------");
                Console.WriteLine("");
                Console.WriteLine($"La cantidad total de visualizaciones entre todos los anios suma: {total2015 + total2016 + total2017 + total2018 + total2019 + total2020 + total2021 + total2022}");

                Console.WriteLine("");
                Console.WriteLine("Presione una tecla para continuar...");
                Console.ReadKey();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                
            }

            try
            {

                Console.WriteLine("Desea Guardar los datos en un archivo de texto? Y/N");
                var resp = Console.ReadLine();

                if (resp.ToUpper() == "Y")
                {
                    if (!File.Exists(pathDestino))
                    {
                        using (StreamWriter archivoSalida = new StreamWriter(pathDestino, false, System.Text.Encoding.Default))
                        {
                            archivoSalida.WriteLine("------------------- TOTAL DE VISUALIZACIONES POR ANIO --------------------");
                            archivoSalida.WriteLine("");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2015: {total2015}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2016: {total2016}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2017: {total2017}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2018: {total2018}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2019: {total2019}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2020: {total2020}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2021: {total2021}");
                            archivoSalida.WriteLine($"El Total de visualizaciones en el 2022: {total2022}");
                            archivoSalida.WriteLine("");
                            archivoSalida.WriteLine("------------------- TOTAL DE VISUALIZACIONES --------------------");
                            archivoSalida.WriteLine("");
                            archivoSalida.WriteLine($"La cantidad total de visualizaciones entre todos los anios suma: {total2015 + total2016 + total2017 + total2018 + total2019 + total2020 + total2021 + total2022}");

                            Console.WriteLine("Desea ABRIR el archivo ahora? Y/N");
                            var resp2 = Console.ReadLine();

                            if (resp2.ToUpper() == "Y")
                            {
                                Process.Start(pathDestino);

                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("El archivo ya existe!! Desea sobreescribirlo? Y/N");
                        var resp3 = Console.ReadLine();

                        if (resp3.ToUpper() == "Y")
                        {
                            using (StreamWriter archivoSalida = new StreamWriter(pathDestino, false, System.Text.Encoding.Default))
                            {
                                archivoSalida.WriteLine("------------------- TOTAL DE VISUALIZACIONES POR ANIO --------------------");
                                archivoSalida.WriteLine("");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2015: {total2015}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2016: {total2016}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2017: {total2017}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2018: {total2018}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2019: {total2019}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2020: {total2020}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2021: {total2021}");
                                archivoSalida.WriteLine($"El Total de visualizaciones en el 2022: {total2022}");
                                archivoSalida.WriteLine("");
                                archivoSalida.WriteLine("------------------- TOTAL DE VISUALIZACIONES --------------------");
                                archivoSalida.WriteLine("");
                                archivoSalida.WriteLine($"La cantidad total de visualizaciones entre todos los anios suma: {total2015 + total2016 + total2017 + total2018 + total2019 + total2020 + total2021 + total2022}");

                                Console.WriteLine("Desea ABRIR el archivo ahora? Y/N");
                                var resp2 = Console.ReadLine();

                                if (resp2.ToUpper() == "Y")
                                {
                                    Process.Start(pathDestino);

                                }
                            }
                        }

                    }

                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
            }


            Console.WriteLine("Programa finalizado, presione una tecla para salir");
            Console.ReadKey();

        }

    }
   
}
   


